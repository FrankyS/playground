namespace Franky.Playground.Base.Helpers
{
	using System;

	public static class DateTimeHelper
	{
		public static DateTime FromUnixTimeStamp(long unixTimeStamp)
		{
			DateTime epochDateTime = new DateTime(1970, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc);
			return epochDateTime.AddSeconds(unixTimeStamp);
		}
	}
}
