using ASP.NETCoreWebApplication2.Player;
using ASP.NETCoreWebApplication2.Player.Values;

namespace ASP.NETCoreWebApplication2.Team
{
	public record HockeyTeam
	{
		public List<HockeyPlayer> Players { get; }
		
		public IEnumerable<HockeyPlayer> Forwards { get; }

		public IEnumerable<HockeyPlayer> Defenders { get; }

		public TeamSide TeamSide { get; set; }

		public int MaxPreferredSidePlayers { get; }

		private static TeamSide IdentifyTeamSide(int preferredWhiteQty, int preferredBlackQty)
		{
			if (preferredWhiteQty > preferredBlackQty)
				return TeamSide.White;

			if (preferredBlackQty > preferredWhiteQty)
				return TeamSide.Black;

			return (TeamSide)new Random().Next(1, 3);
		}

		public HockeyTeam(List<HockeyPlayer> players)
		{
			var preferredWhiteQty = players.Count(player => player.PreferredTeam == TeamSide.White);
			var preferredBlackQty = players.Count(player => player.PreferredTeam == TeamSide.Black);

			Players = players;
			Forwards = players.Where(player => player.Role == Role.Forward);
			Defenders = players.Where(player => player.Role == Role.Defender);
			TeamSide = IdentifyTeamSide(preferredWhiteQty, preferredBlackQty);
			MaxPreferredSidePlayers = Math.Max(preferredWhiteQty, preferredBlackQty);
		}
	};
}
