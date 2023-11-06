namespace ASP.NETCoreWebApplication2.Code.Helper
{
	[AttributeUsage(AttributeTargets.Property)]
	public class CompareOrderAttribute : Attribute
	{
		public int Order { get; }

		public CompareOrderAttribute(int order)
		{
			Order = order;
		}
	}
}
