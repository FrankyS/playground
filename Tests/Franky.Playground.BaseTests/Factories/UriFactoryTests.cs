namespace Franky.Playground.BaseTests.Factories
{
	using System;
	using System.Collections.Generic;
	using Franky.Playground.Base.Factories;
	using NUnit.Framework;

	[TestFixture]
	public class UriFactoryTests
	{
		private UriFactory factory;

		[SetUp]
		public void SetUp()
		{
			this.factory = new UriFactory();
		}

		[Test]
		public void CreateThrowsExceptionIfUrlIsNull()
		{
			// Act
			ArgumentNullException exception = Assert.Throws<ArgumentNullException>(() => this.factory.Create(null));

			// Assert
			Assert.IsNotNull(exception);
			Assert.AreEqual("url", exception.ParamName);
		}

		[TestCase("http://google.de", "http://google.de/")]
		[TestCase("http://google.de/", "http://google.de/")]
		[TestCase("http://google.de/subdomain", "http://google.de/subdomain")]
		[TestCase("http://www.google.de", "http://www.google.de/")]
		[TestCase("http://www.google.de/subdomain", "http://www.google.de/subdomain")]
		public void CreateCanHandleSimpleUrl(string url, string expectedUrl)
		{
			// Act
			Uri uri = this.factory.Create(url);

			// Assert
			Assert.AreEqual(expectedUrl, uri.AbsoluteUri);
		}

		[Test]
		public void CreateCanHandleSingleQueryValue()
		{
			// Arrange
			Dictionary<string, string> queryValues = new Dictionary<string, string> { { "key", "value" } };

			// Act
			Uri uri = this.factory.Create("http://google.de", queryValues);

			// Assert
			Assert.AreEqual("?key=value", uri.Query);
		}

		[Test]
		public void CreateCanHandleMultipleQueryValues()
		{
			// Arrange
			Dictionary<string, string> queryValues = new Dictionary<string, string>
				{
					{ "key1", "value1" },
					{ "key2", "value2" }
				};

			// Act
			Uri uri = this.factory.Create("http://google.de", queryValues);

			// Assert
			Assert.AreEqual("?key1=value1&key2=value2", uri.Query);
		}
	}
}
