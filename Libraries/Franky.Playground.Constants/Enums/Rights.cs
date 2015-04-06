namespace Franky.Playground.Constants.Enums
{
	using System;

	[Flags]
	public enum Rights
	{
		None = 0,
		
		Read = 1,
		
		Update = 2,

		Delete = 4
	}
}