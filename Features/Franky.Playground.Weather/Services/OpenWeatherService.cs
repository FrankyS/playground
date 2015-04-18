namespace Franky.Playground.Weather.Services
{
	using System.Collections.Generic;
	using System.IO;
	using Franky.Playground.Base.Interfaces;
	using Franky.Playground.Weather.Data;
	using Franky.Playground.Weather.Interfaces;
	using Newtonsoft.Json;

	public class OpenWeatherService : IWeatherService
	{
		private const string AppKey = "";
		private const string Url = "http://api.openweathermap.org/data/2.5/weather";

		private readonly IWebRequestService webRequestService;
		
		public OpenWeatherService(IWebRequestService webRequestService)
		{
			this.webRequestService = webRequestService;
		}

		/// <summary>
		/// Query the open weather map api with the given city, locale and unit format
		/// </summary>
		/// <param name="cityName">The name of the city to query for.</param>
		/// <param name="locale">The locale to be used for the result.</param>
		/// <param name="unitFormat">The unit to be returned ('internal', 'metric' or 'imperial').</param>
		/// <returns>The <see cref="WeatherData"/> from http://openweathermap.org/ .</returns>
		public WeatherData GetWeather(string cityName, string locale, string unitFormat)
		{
			WeatherData weatherData = new WeatherData();

			IDictionary<string, string> queryValues = GetQueryValues(cityName, locale, unitFormat);
			IDictionary<string, string> additionalHeaders = GetAdditionalHeaders();
			using (Stream stream = this.webRequestService.Get(Url, queryValues, additionalHeaders))
			{
				if (stream != null)
				{
					using (StreamReader streamReader = new StreamReader(stream))
					{
						using (JsonTextReader jsonTextReader = new JsonTextReader(streamReader))
						{
							JsonSerializer jsonSerializer = new JsonSerializer();
							weatherData = jsonSerializer.Deserialize<WeatherData>(jsonTextReader);
						}
					}
				}
			}

			return weatherData;
		}

		private static IDictionary<string, string> GetQueryValues(string cityName, string locale, string unitFormat)
		{
			return new Dictionary<string, string>
				{
					{ "q", cityName },
					{ "lang", locale },
					{ "units", unitFormat }
				};
		}

		private static IDictionary<string, string> GetAdditionalHeaders()
		{
			return new Dictionary<string, string>
				{
					{ "x-api-key", AppKey }
				};
		}
	}
}
