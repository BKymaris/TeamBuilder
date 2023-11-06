using ASP.NETCoreWebApplication2.Code;
using ASP.NETCoreWebApplication2.Code.Exception;
using ASP.NETCoreWebApplication2.Mapper;
using ASP.NETCoreWebApplication2.Models;
using ASP.NETCoreWebApplication2.Player;
using ASP.NETCoreWebApplication2.Player.Entity;
using ASP.NETCoreWebApplication2.Player.Values;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ASP.NETCoreWebApplication2.Controllers;

[ApiController]
[Route("[controller]")]
public class HockeyController : ControllerBase
{
	private readonly ILogger<HockeyController> _logger;

	public HockeyController(ILogger<HockeyController> logger)
	{
		_logger = logger;
	}

	[HttpGet]
	public async Task<IEnumerable<HockeyPlayerViewModel>> Get(DataContext context, CancellationToken cancellationToken)
	{
		return await context.Players
			.AsNoTracking()
			.OrderBy(entity => entity.Role)
			.ThenBy(entity => entity.Name)
			.Select(entity => PlayerMapper.MapToDto(entity))
			.ToListAsync(cancellationToken);
	}

	[HttpPost]
	public async Task<IActionResult> Post(
		PostedModel postedModel,
		DataContext context,
		CancellationToken cancellationToken
	)
	{
		var dtoDict = postedModel.Players.ToDictionary(player => player.Id);

		var players = await context.Players
			.AsNoTracking()
			.Where(entity => dtoDict.Keys.Contains(entity.Id))
			.Select(entity => PlayerMapper.MapToDs(entity))
			.Select(entity => OverrideRole(entity, dtoDict[entity.Id]))
			.ToArrayAsync(cancellationToken);

		try
		{
			var builder = new TeamBuilder(players);

			var result = CombinationMapper.MapToViewModel(builder.Build(postedModel.PreferredSide));

			await context.History.AddAsync(
				new BuildHistory
				{
					CreateUtcTime = DateTime.UtcNow,
					IpAddress = Request.Headers["X-Forwarded-For"].ToString()
				},
				cancellationToken
			);

			await context.SaveChangesAsync(cancellationToken);

			return Ok(result);
		}
		catch (TeamBuildException exception)
		{
			return Ok(new ErrorViewModel(exception.Message));
		}
		catch
		{
			return Ok(new ErrorViewModel("Что-то пошло не так"));
		}
	}

	private static HockeyPlayer OverrideRole(HockeyPlayer entity, HockeyPlayerViewModel viewModel)
	{
		return entity with { Role = (Role)viewModel.Role };
	}
}
