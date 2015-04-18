namespace Franky.Playground.WeatherTests.Services
{
	using System;
	using System.Collections.Generic;
	using System.IO;
	using System.Text;
	using Franky.Playground.Base.Interfaces;
	using Franky.Playground.Weather.Data;
	using Franky.Playground.Weather.Services;
	using NUnit.Framework;
	using Rhino.Mocks;

	[TestFixture]
	public class OpenWeatherServiceTests
	{
		private OpenWeatherService service;

		private IWebRequestService mockedWebRequestService;

		[SetUp]
		public void SetUp()
		{
			this.mockedWebRequestService = MockRepository.GenerateMock<IWebRequestService>();

			this.service = new OpenWeatherService(this.mockedWebRequestService);
		}

		[Test]
		public void GetWeatherCallsGetWithQueryValuesAndHeaders()
		{
			// Arrange
			IDictionary<string, string> queryValues = new Dictionary<string, string>
				{
					{ "q", "Bremen,de" },
					{ "lang", "de" },
					{ "units", "metric" }
				};
			IDictionary<string, string> additionalHeaders = new Dictionary<string, string>
				{
					{ "x-api-key", "" }
				};

			// Act
			this.service.GetWeather("Bremen,de", "de", "metric");

			// Assert
			this.mockedWebRequestService.AssertWasCalled(x => x.Get("http://api.openweathermap.org/data/2.5/weather", queryValues, additionalHeaders));
		}

		[Test]
		public void GetWeatherJsonDeserializesTheResponse()
		{
			// Arrange
			this.mockedWebRequestService.Stub(x => x.Get(Arg<string>.Is.Anything, Arg<IDictionary<string, string>>.Is.Anything,
					Arg<IDictionary<string, string>>.Is.Anything))
				.Return(GetExampleResponse());

			// Act
			WeatherData weatherData = this.service.GetWeather(null, null, null);

			// Assert
			Assert.IsNotNull(weatherData);
		}

		private static Stream GetExampleResponse()
		{
			const string jsonResponse = "{\"coord\":{\"lon\":8.81,\"lat\":53.08},\"sys\":{\"message\":0.0119,\"country\":\"DE\",\"sunrise\":1429330741,\"sunset\":1429381817},\"weather\":[{\"id\":800,\"main\":\"Clear\",\"description\":\"klarer Himmel\",\"icon\":\"02d\"}],\"base\":\"stations\",\"main\":{\"temp\":11.59,\"temp_min\":11.59,\"temp_max\":11.59,\"pressure\":1037.8,\"sea_level\":1041.88,\"grnd_level\":1037.8,\"humidity\":88},\"wind\":{\"speed\":2.52,\"deg\":16.0013},\"clouds\":{\"all\":8},\"dt\":1429357756,\"id\":2944388,\"name\":\"Bremen\",\"cod\":200}";
			byte[] bytes = Encoding.UTF8.GetBytes(jsonResponse);

			MemoryStream memoryStream = new MemoryStream();
			memoryStream.Write(bytes, 0, bytes.Length);
			memoryStream.Position = 0;

			return memoryStream;
		}
	}
}
