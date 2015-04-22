namespace Franky.Playground.WebApi.Formatter
{
	using System;
	using System.Collections.Generic;
	using System.IO;
	using System.Net;
	using System.Net.Http;
	using System.Net.Http.Formatting;
	using System.Net.Http.Headers;
	using System.Text;
	using System.Threading.Tasks;
	using Newtonsoft.Json;
	using Newtonsoft.Json.Converters;

	public class DefaultJsonFormatter : JsonMediaTypeFormatter
	{
		private static readonly JsonSerializerSettings settings = new JsonSerializerSettings
			{
#if DEBUG
				Formatting = Formatting.Indented,
#else
				Formatting = Formatting.None,
#endif
				NullValueHandling = NullValueHandling.Ignore,
				Converters = new List<JsonConverter>
					{
						new IsoDateTimeConverter()
					}
			};

		public DefaultJsonFormatter()
		{
			this.SupportedMediaTypes.Add(new MediaTypeHeaderValue("text/html"));
		}

		public override void SetDefaultContentHeaders(Type type, HttpContentHeaders headers, MediaTypeHeaderValue mediaType)
		{
			base.SetDefaultContentHeaders(type, headers, mediaType);
			headers.ContentType = new MediaTypeHeaderValue("application/json");
		}

		public override Task<object> ReadFromStreamAsync(Type type, Stream readStream, HttpContent content, IFormatterLogger formatterLogger)
		{
			Task<object> task = Task<object>.Factory.StartNew(() =>
				{
					object value;
					using (StreamReader streamReader = new StreamReader(readStream))
					{
						string json = streamReader.ReadToEnd();
						value = JsonConvert.DeserializeObject(json, settings);
					}

					return value;
				});

			return task;
		}

		public override Task WriteToStreamAsync(Type type, object value, Stream writeStream, HttpContent content, TransportContext transportContext)
		{
			Task task = Task.Factory.StartNew(() =>
				{
					string json = JsonConvert.SerializeObject(value, settings);

					byte[] bytes = Encoding.Default.GetBytes(json);
					writeStream.Write(bytes, 0, bytes.Length);
					writeStream.Flush();
				});

			return task;
		}
	}
}