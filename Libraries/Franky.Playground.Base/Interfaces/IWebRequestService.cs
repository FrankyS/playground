namespace Franky.Playground.Base.Interfaces
{
	using System.Collections.Generic;
	using System.IO;

	public interface IWebRequestService
	{
		Stream Get(string url, IDictionary<string, string> queryValues = null, IDictionary<string, string> additionalHeaders = null);
	}
}