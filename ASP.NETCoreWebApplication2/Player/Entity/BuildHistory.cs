namespace ASP.NETCoreWebApplication2.Player.Entity
{
	public class BuildHistory
	{
		public int Id { get; set; }

		public DateTime CreateUtcTime { get; set; }

		public string IpAddress { get; set; } = default!;
	}
}
