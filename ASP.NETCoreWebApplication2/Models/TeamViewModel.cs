namespace ASP.NETCoreWebApplication2.Models
{
	public record TeamViewModel(IEnumerable<HockeyPlayerViewModel> Players, int TeamSide, TeamSkillViewModel Skill);
}
