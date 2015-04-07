namespace Franky.Playground.DataAccess
{
	using System;
	using System.Data.Entity;
	using System.Linq;
	using Franky.Playground.DataAccess.Conventions;
	using Franky.Playground.DataAccess.Entities;
	using log4net;

	public class PlaygroundContext : DbContext
	{
		private static readonly ILog logger = LogManager.GetLogger(typeof(PlaygroundContext));
		private static readonly string[] prefixToIgnore = { "-- p__linq__0", "-- Executing at" };

		private readonly Guid guid = Guid.NewGuid();

		public PlaygroundContext()
			: base("DefaultConnection")
		{
			this.Database.Log = s => LogMessage(s, this.guid);
		}

		public DbSet<Item> Items { get; set; }

		protected override void OnModelCreating(DbModelBuilder modelBuilder)
		{
			modelBuilder.Conventions.Add(new DateTimeConvention());
		}

		private static void LogMessage(string message, Guid guid)
		{
			message = message.Replace(Environment.NewLine, string.Empty);
			if (!string.IsNullOrEmpty(message) && !prefixToIgnore.Any(x => message.StartsWith(x)))
			{
				logger.DebugFormat("{0}: {1}", guid, message);
			}
		}
	}
}