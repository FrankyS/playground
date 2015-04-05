namespace Franky.Playground.WebApi.Formatter
{
	using System;
	using System.Net.Http.Formatting;
	using System.Net.Http.Headers;

	public class DefaultJsonFormatter : JsonMediaTypeFormatter
	{
		public DefaultJsonFormatter()
		{
			this.SupportedMediaTypes.Add(new MediaTypeHeaderValue("text/html"));
		}

		public override void SetDefaultContentHeaders(Type type, HttpContentHeaders headers, MediaTypeHeaderValue mediaType)
		{
			base.SetDefaultContentHeaders(type, headers, mediaType);
			headers.ContentType = new MediaTypeHeaderValue("application/json");
		}
	}
}