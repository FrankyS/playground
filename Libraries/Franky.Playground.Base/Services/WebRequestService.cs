namespace Franky.Playground.Base.Services
{
	using System;
	using System.Collections.Generic;
	using System.IO;
	using System.Net;
	using Franky.Playground.Base.Interfaces;

	public class WebRequestService : IWebRequestService
	{
		private readonly IUriFactory uriFactory;
		private readonly IWebRequestFactory webRequestFactory;

		public WebRequestService(IUriFactory uriFactory, IWebRequestFactory webRequestFactory)
		{
			this.uriFactory = uriFactory;
			this.webRequestFactory = webRequestFactory;
		}

		public Stream Get(string url, IDictionary<string, string> queryValues = null, IDictionary<string, string> additionalHeaders = null)
		{
			Stream stream = null;
			Uri uri = this.uriFactory.Create(url, queryValues);
			if (uri != null)
			{
				WebRequest webRequest = this.webRequestFactory.Create(uri, additionalHeaders);
				if (webRequest != null)
				{
					WebResponse webResponse = webRequest.GetResponse();
					stream = webResponse.GetResponseStream();
				}
			}

			return stream;
		}
	}
}
