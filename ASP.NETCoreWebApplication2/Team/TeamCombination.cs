using ASP.NETCoreWebApplication2.Code;
using ASP.NETCoreWebApplication2.Player.Values;

namespace ASP.NETCoreWebApplication2.Team
{
	public record TeamCombination
	{
		public HockeyTeam FirstTeam { get; }

		public HockeyTeam SecondTeam { get; }
		
		public decimal TeamDifferent { get; }

		public decimal[] Differences { get; }

		public int MaxPreferredSidePlayers { get; }

		public TeamCombination(HockeyTeam firstTeam, HockeyTeam secondTeam)
		{
			FirstTeam = firstTeam;
			SecondTeam = secondTeam;
			TeamDifferent = Math.Abs(
				FirstTeam.Players.Sum(player => player.Skill.Skill) / FirstTeam.Players.Count -
				SecondTeam.Players.Sum(player => player.Skill.Skill) / SecondTeam.Players.Count
			);;
			Differences = TeamBuilder.CollectSkillDifferences(this).ToArray();
			MaxPreferredSidePlayers =
				Math.Max(firstTeam.MaxPreferredSidePlayers, secondTeam.MaxPreferredSidePlayers);

			if (firstTeam.TeamSide != secondTeam.TeamSide)
				return;

			if (firstTeam.MaxPreferredSidePlayers >= secondTeam.MaxPreferredSidePlayers)
				secondTeam.TeamSide = Enum.GetValues<TeamSide>().First(value => value != firstTeam.TeamSide);
			else if (secondTeam.MaxPreferredSidePlayers > firstTeam.MaxPreferredSidePlayers)
				firstTeam.TeamSide = Enum.GetValues<TeamSide>().First(value => value != firstTeam.TeamSide);
		}
	}
}
