namespace Franky.Playground.Base.Factories
{
	using System;
	using System.Collections.Generic;
	using System.Linq;
	using Franky.Playground.Base.Interfaces;

	public class UriFactory : IUriFactory
	{
		public Uri Create(string url, IDictionary<string, string> queryValues = null)
		{
			Guard.NotNull(url, "url");

			if (queryValues != null && queryValues.Any())
			{
				IEnumerable<string> values = queryValues.Select(x => string.Format("{0}={1}", x.Key, x.Value));
				url += "?" + string.Join("&", values);
			}

			return new Uri(url);
		}
	}
}