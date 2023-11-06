using ASP.NETCoreWebApplication2.Team;

namespace ASP.NETCoreWebApplication2.Code.Helper
{
	public class CombinationComparer
		: IComparer<TeamCombination>
	{
		private readonly string[] _properties;

		public CombinationComparer(IEnumerable<string> properties)
		{
			_properties = properties
				.Select(property => new[] { $"Forward{property}", $"Defender{property}" })
				.SelectMany(props => props)
				.ToArray();
		}

		public int Compare(TeamCombination? x, TeamCombination? y)
		{
			if (x is null || y is null)
				return 0;

			for (var index = 0; index < _properties.Length; index++)
			{
				if (x.Differences[index] != y.Differences[index])
				{
					return x.Differences[index].CompareTo(y.Differences[index]);
				}
			}

			return x.TeamDifferent.CompareTo(y.TeamDifferent);
		}
	}
}
