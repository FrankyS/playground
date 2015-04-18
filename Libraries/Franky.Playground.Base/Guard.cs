namespace Franky.Playground.Base
{
	using System;

	/// <summary>
	/// Guard for parameter contraints.
	/// </summary>
	public static class Guard
	{
		/// <summary>
		/// Checks that the given value is not null.
		/// </summary>
		public static void NotNull(object value, string paramterName)
		{
			if (value == null)
			{
				throw new ArgumentNullException(paramterName);
			}
		}
	}
}