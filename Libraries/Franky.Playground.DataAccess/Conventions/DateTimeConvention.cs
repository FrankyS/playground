namespace Franky.Playground.DataAccess.Conventions
{
	using System;
	using System.Data.Entity.ModelConfiguration.Conventions;

	/// <summary>The date time convention.</summary>
	public class DateTimeConvention : Convention
	{
		/// <summary>Initializes a new instance of the <see cref="DateTimeConvention"/> class.</summary>
		public DateTimeConvention()
		{
			this.Properties<DateTime>()
				.Configure(c => c.HasColumnType("datetime2"));
		}
	}
}