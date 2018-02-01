namespace Travix.Services.Core.Routing
{
	public static class Routes
	{
		public const string Default = "api/[controller]";
		public const string DefaultWithVersion = "api/v{version:apiVersion}/[controller]";

		public const string Id = "{id}";

		public static class Versioning
		{
			public const string DefaultVersion = "1.0";
		}
	}
}
