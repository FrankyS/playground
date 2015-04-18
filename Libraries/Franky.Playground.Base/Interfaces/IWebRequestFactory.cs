namespace Franky.Playground.Base.Interfaces
{
	using System;
	using System.Collections.Generic;
	using System.Net;

	public interface IWebRequestFactory
	{
		WebRequest Create(Uri uri, IDictionary<string, string> additionalHeaders = null);
	}
}