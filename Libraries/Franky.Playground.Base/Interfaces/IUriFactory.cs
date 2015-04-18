namespace Franky.Playground.Base.Interfaces
{
	using System;
	using System.Collections.Generic;

	public interface IUriFactory
	{
		Uri Create(string url, IDictionary<string, string> queryValues = null);
	}
}