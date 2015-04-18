namespace Franky.Playground.Base.Factories
{
	using System;
	using System.Collections.Generic;
	using System.Net;
	using Franky.Playground.Base.Interfaces;

	public class WebRequestFactory : IWebRequestFactory
	{
		public WebRequest Create(Uri uri, IDictionary<string, string> additionalHeaders = null)
		{
			Guard.NotNull(uri, "uri");

			WebRequest webRequest = WebRequest.Create(uri);
			if (additionalHeaders != null)
			{
				foreach (KeyValuePair<string, string> additionalHeader in additionalHeaders)
				{
					webRequest.Headers.Add(additionalHeader.Key, additionalHeader.Value);
				}
			}

			return webRequest;
		}
	}
}
