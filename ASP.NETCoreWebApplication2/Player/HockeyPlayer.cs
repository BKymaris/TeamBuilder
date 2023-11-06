using ASP.NETCoreWebApplication2.Player.Values;

namespace ASP.NETCoreWebApplication2.Player
{
	public record HockeyPlayer(
		int Id,
		string Name,
		PlayerSkill Skill,
		Role Role,
		TeamSide PreferredTeam,
		bool IsVeteran
	)
	{
		public readonly int UniqueKey = 1 << Id;
	};
}
