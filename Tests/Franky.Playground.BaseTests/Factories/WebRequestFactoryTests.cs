namespace Franky.Playground.BaseTests.Factories
{
	using System;
	using System.Collections.Generic;
	using System.Net;
	using Franky.Playground.Base.Factories;
	using NUnit.Framework;

	[TestFixture]
	public class WebRequestFactoryTests
	{
		private WebRequestFactory factory;

		[SetUp]
		public void SetUp()
		{
			this.factory = new WebRequestFactory();
		}

		[Test]
		public void CreateThrowsExceptionIfUriIsNull()
		{
			// Act
			ArgumentNullException exception = Assert.Throws<ArgumentNullException>(() => this.factory.Create(null));

			// Assert
			Assert.AreEqual("uri", exception.ParamName);
		}

		[Test]
		public void CreateReturnWebRequestWithGivenUri()
		{
			// Arrange
			Uri uri = new Uri("http://www.google.de");

			// Act
			WebRequest webRequest = this.factory.Create(uri);

			// Assert
			Assert.AreEqual(uri, webRequest.RequestUri);
		}

		[Test]
		public void CreateAppendsHeadersIfGiven()
		{
			// Arrange
			Uri uri = new Uri("http://www.google.de");
			IDictionary<string, string> additionalHeaders = new Dictionary<string, string> { { "header", "value" } };

			// Act
			WebRequest webRequest = this.factory.Create(uri, additionalHeaders);

			// Assert
			Assert.AreEqual("value", webRequest.Headers["header"]);
		}
	}
}
