namespace Franky.Playground.Weather.Data
{
	using System;
	using Franky.Playground.Base.Helpers;
	using Newtonsoft.Json;

	public class WeatherData
	{
		[JsonProperty("dt")]
		private long timestamp;

		[JsonProperty("id")]
		public int Id { get; set; }

		[JsonIgnore]
		public DateTime DateTime
		{
			get { return DateTimeHelper.FromUnixTimeStamp(this.timestamp); }
		}

		[JsonProperty("name")]
		public string Name { get; set; }

		[JsonProperty("coord")]
		public Coordinates Coordinates { get; set; }

		[JsonProperty("sys")]
		public SystemData SystemData { get; set; }
		
		public Main main { get; set; }
		
		public Wind wind { get; set; }
		
		public Weather[] weather { get; set; }
		
		public Clouds clouds { get; set; }
		
		public Rain rain { get; set; }
		
		public Snow snow { get; set; }
	}

	public class Coordinates
	{
		[JsonProperty("lat")]
		public float Latitude { get; set; }

		[JsonProperty("lon")]
		public float Longitude { get; set; }
	}

	public class SystemData
	{
		public float message { get; set; }
		public string country { get; set; }
		public long sunrise { get; set; }
		public long sunset { get; set; }
	}

	public class Main
	{
		public float temp { get; set; }
		public float pressure { get; set; }
		public float humidity { get; set; }
		public float temp_min { get; set; }
		public float temp_max { get; set; }
		public float sea_level { get; set; }
		public float grnd_level { get; set; }
	}

	public class Wind
	{
		public float speed { get; set; }
		public float deg { get; set; }
		public float gust { get; set; }
	}

	public class Clouds
	{
		public int all { get; set; }
	}

	public class Rain
	{
		public int _3h { get; set; }
	}

	public class Snow
	{
		public int _3h { get; set; }
	}

	public class Weather
	{
		public int id { get; set; }
		public string main { get; set; }
		public string description { get; set; }
		public string icon { get; set; }
	}

}
