namespace ASP.NETCoreWebApplication2.Models
{
	public record PostedModel(IEnumerable<HockeyPlayerViewModel> Players, bool PreferredSide);
}
