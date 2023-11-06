using ASP.NETCoreWebApplication2.Models;
using ASP.NETCoreWebApplication2.Player.Values;
using ASP.NETCoreWebApplication2.Team;

namespace ASP.NETCoreWebApplication2.Mapper
{
	public static class CombinationMapper
	{
		public static TeamCombinationViewModel MapToViewModel(TeamCombination team)
		{
			var showTeamSkill = team.FirstTeam.Players.Count >= 4 && team.SecondTeam.Players.Count >= 4;
			var showRoleSkill =
				team.FirstTeam.Players.Count(player => player.Role == Role.Forward) >= 3 &&
				team.SecondTeam.Players.Count(player => player.Role == Role.Forward) >= 3 &&
				team.FirstTeam.Players.Count(player => player.Role == Role.Defender) >= 2 &&
				team.SecondTeam.Players.Count(player => player.Role == Role.Defender) >= 2;

			return new TeamCombinationViewModel(
				MapToViewModel(team.FirstTeam, showTeamSkill, showRoleSkill),
				MapToViewModel(team.SecondTeam, showTeamSkill, showRoleSkill)
			);
		}

		private static TeamViewModel MapToViewModel(HockeyTeam team, bool showTeamSkill, bool showRoleSkill)
		{
			var teamSkillViewModel = new TeamSkillViewModel(null, null, null
				// showTeamSkill
				// 	? team.Players.Sum(q => q.Skill)
				// 	: null,
				// showRoleSkill
				// 	? team.Players.Where(player => player.Role == Role.Forward).Sum(q => q.Skill)
				// 	: null,
				// showRoleSkill
				// 	? team.Players.Where(player => player.Role == Role.Defender).Sum(q => q.Skill)
				// 	: null
			);

			return new TeamViewModel(
				team.Players.Select(PlayerMapper.MapToDto).OrderBy(player => player.Role).ThenBy(player => player.Name),
				(int)team.TeamSide,
				teamSkillViewModel
			);
		}
	}
}
