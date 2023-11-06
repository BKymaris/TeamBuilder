using System.Reflection;
using ASP.NETCoreWebApplication2.Code.Exception;
using ASP.NETCoreWebApplication2.Code.Helper;
using ASP.NETCoreWebApplication2.Player;
using ASP.NETCoreWebApplication2.Player.Values;
using ASP.NETCoreWebApplication2.Team;
using Eleview;

namespace ASP.NETCoreWebApplication2.Code
{
	public class TeamBuilder
	{
		private const int _TEAM_QTY = 2;

		private readonly HockeyPlayer[] _sourcePlayers;
		private readonly decimal _teamForwardsQty;
		private readonly decimal _teamDefendersQty;

		private static readonly string[] _playerSkillProperties =
			typeof(PlayerSkill)
				.GetProperties()
				.Where(property => property.GetCustomAttribute<CompareOrderAttribute>() is not null)
				.OrderBy(property => property.GetCustomAttribute<CompareOrderAttribute>()!.Order)
				.Select(property => property.Name)
				.ToArray();

		private static IEnumerable<List<T>> CollectPlayersCombinations<T>(IReadOnlyCollection<T> source)
		{
			for (var i = 0; i < Math.Pow(2, source.Count); i++)
			{
				yield return source.Where((_, j) => (i & (int)Math.Pow(2, j)) != 0).ToList();
			}
		}

		private bool CheckVeterans(IEnumerable<HockeyPlayer> firstTeam, IEnumerable<HockeyPlayer> secondTeam)
		{
			if (!_sourcePlayers.Any(player => player.IsVeteran) ||
			    _sourcePlayers.Count(player => player.IsVeteran) == 1)
				return true;

			var veteransQty = _sourcePlayers.Count(player => player.IsVeteran);

			return firstTeam.Count(player => player.IsVeteran) != veteransQty &&
			       secondTeam.Count(player => player.IsVeteran) != veteransQty;
		}

		private static int CreateTeamSnapshot(IEnumerable<HockeyPlayer> source)
		{
			return source.Aggregate(0, (result, player) => result | player.UniqueKey);
		}

		private bool CombinationPassedByQty(IReadOnlyCollection<HockeyPlayer> source)
		{
			if (source.Count == 0)
				return false;
			
			var combinationForwardsQty = source.Count(player => player.Role == Role.Forward);
			var combinationDefendersQty = source.Count(player => player.Role == Role.Defender);

			return (combinationForwardsQty == Math.Ceiling(_teamForwardsQty) ||
			        combinationForwardsQty == Math.Floor(_teamForwardsQty)) &&
			       (combinationDefendersQty == Math.Ceiling(_teamDefendersQty) ||
			        combinationDefendersQty == Math.Floor(_teamDefendersQty));

		}

		private IEnumerable<TeamCombination> CollectTeamCombinations(IReadOnlyCollection<HockeyPlayer> players)
		{
			var unique = new HashSet<int>();

			foreach (var firstPlayers in CollectPlayersCombinations(players))
			{
				if (!CombinationPassedByQty(firstPlayers))
					continue;

				var secondPlayers = _sourcePlayers.Where(player => !firstPlayers.Contains(player)).ToList();

				if (!unique.Add(CreateTeamSnapshot(firstPlayers)) || !unique.Add(CreateTeamSnapshot(secondPlayers)))
					continue;

				if (!CheckVeterans(firstPlayers, secondPlayers))
					continue;

				yield return new TeamCombination(new HockeyTeam(firstPlayers), new HockeyTeam(secondPlayers));
			}
		}
		
		public static IEnumerable<decimal> CollectSkillDifferences(TeamCombination src)
		{
			var team1 = src.FirstTeam;
			var team2 = src.SecondTeam;
			foreach (var property in _playerSkillProperties)
			{
				decimal sumSelector(HockeyPlayer player) => (decimal)player.Skill.GetPropertyValue(property);

				yield return
					Math.Abs(
						(team1.Forwards.Any() ? team1.Forwards.Sum(sumSelector) / team1.Forwards.Count() : 0) -
						(team2.Forwards.Any() ? team2.Forwards.Sum(sumSelector) / team2.Forwards.Count() : 0)
					);

				yield return
					Math.Abs(
						(team1.Defenders.Any() ? team1.Defenders.Sum(sumSelector) / team1.Defenders.Count() : 0) -
						(team2.Defenders.Any() ? team2.Defenders.Sum(sumSelector) / team2.Defenders.Count() : 0)
					);
			}
		}

		public TeamCombination Build(bool takeIntoPreferredSide)
		{
			if (_sourcePlayers.Length <= 1)
			{
				throw new TeamBuildException($"Выбрано слишком мало игроков");
			}

			var combinations = CollectTeamCombinations(_sourcePlayers)
				.Where(comb => Math.Abs(comb.FirstTeam.Players.Count - comb.SecondTeam.Players.Count) <= 1)
				.OrderBy(p => p, new CombinationComparer(_playerSkillProperties))
				.ToArray();

			if (combinations.Length == 0)
			{
				throw new TeamBuildException("Не удалось построить сбалансированные команды");
			}
			
			var result = combinations
				.Where(combination =>
				{
					var first = combinations.First();
					return combination.Differences.SequenceEqual(first.Differences) &&
					       combination.TeamDifferent == first.TeamDifferent;
				})
				.ToArray();

			if (takeIntoPreferredSide)
			{
				var maxPreferredSidePlayers = result.Max(combination => combination.MaxPreferredSidePlayers);
				result = result
					.Where(combination => combination.MaxPreferredSidePlayers == maxPreferredSidePlayers)
					.ToArray();
			}

			var randomIndex = new Random().Next(0, result.Length);

			return result[randomIndex];
		}

		public TeamBuilder(HockeyPlayer[] source)
		{
			_sourcePlayers = source;
			_teamForwardsQty = (decimal)_sourcePlayers.Count(player => player.Role == Role.Forward) / _TEAM_QTY;
			_teamDefendersQty = (decimal)_sourcePlayers.Count(player => player.Role == Role.Defender) / _TEAM_QTY;
		}
	}
}
