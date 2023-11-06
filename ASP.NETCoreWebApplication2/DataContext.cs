using ASP.NETCoreWebApplication2.Player.Entity;
using Microsoft.EntityFrameworkCore;

namespace ASP.NETCoreWebApplication2
{
	public class DataContext
		: DbContext
	{
		public DataContext(DbContextOptions<DataContext> options)
			: base(options)
		{
		}

		public DbSet<HockeyPlayerData> Players => Set<HockeyPlayerData>();

		public DbSet<BuildHistory> History => Set<BuildHistory>();
	}
}
