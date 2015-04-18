namespace Franky.Playground.BaseTests.Services
{
	using System;
	using System.Collections.Generic;
	using System.IO;
	using System.Net;
	using Franky.Playground.Base.Interfaces;
	using Franky.Playground.Base.Services;
	using NUnit.Framework;
	using Rhino.Mocks;

	[TestFixture]
	public class WebRequestServiceTests
	{
		private WebRequestService service;

		private IUriFactory mockedUriFactory;
		private IWebRequestFactory mockedWebRequestFactory;

		[SetUp]
		public void SetUp()
		{
			this.mockedUriFactory = MockRepository.GenerateMock<IUriFactory>();
			this.mockedWebRequestFactory = MockRepository.GenerateMock<IWebRequestFactory>();

			this.service = new WebRequestService(this.mockedUriFactory, this.mockedWebRequestFactory);
		}

		[Test]
		public void GetCreatesUriWithGivenUrlAndQueryValues()
		{
			// Arrange
			IDictionary<string, string> queryValues = new Dictionary<string, string>();

			// Act
			this.service.Get("url", queryValues);

			// Assert
			this.mockedUriFactory.AssertWasCalled(x => x.Create(Arg<string>.Is.Equal("url"), 
				Arg<IDictionary<string, string>>.Is.Equal(queryValues)));
		}

		[Test]
		public void GetCreatesWebRequestWithUriFromFactoryAndGivenHeaders()
		{
			// Arrange
			IDictionary<string, string> additionalHeaders = new Dictionary<string, string>();
			Uri mockedUri = this.StubCreateUri();

			// Act
			this.service.Get(null, null, additionalHeaders);

			// Assert
			this.mockedWebRequestFactory.AssertWasCalled(x => x.Create(mockedUri, additionalHeaders));
		}

		[Test]
		public void GetRetrievesWebResponseFromWebRequest()
		{
			// Arrange
			this.StubCreateUri();
			WebRequest mockedWebRequest = this.StubWebRequest();
			mockedWebRequest.Expect(x => x.GetResponse())
				.Return(MockRepository.GenerateMock<WebResponse>());

			// Act
			this.service.Get(null);

			// Assert
			mockedWebRequest.VerifyAllExpectations();
		}

		[Test]
		public void GetReturnsResponseStreamFromWebResponse()
		{
			// Arrange
			this.StubCreateUri();
			WebRequest mockedWebRequest = this.StubWebRequest();

			WebResponse mockedWebResponse = MockRepository.GenerateMock<WebResponse>();
			mockedWebRequest.Stub(x => x.GetResponse())
				.Return(mockedWebResponse);

			Stream expectedStream = new MemoryStream();
			mockedWebResponse.Expect(x => x.GetResponseStream())
				.Return(expectedStream);

			// Act
			Stream stream = this.service.Get(null);

			// Assert
			Assert.AreEqual(expectedStream, stream);
			mockedWebResponse.VerifyAllExpectations();
		}

		private Uri StubCreateUri()
		{
			Uri mockedUri = MockRepository.GenerateMock<Uri>("http://www.google.de");
			this.mockedUriFactory.Stub(x => x.Create(Arg<string>.Is.Anything, Arg<IDictionary<string, string>>.Is.Anything))
				.Return(mockedUri);

			return mockedUri;
		}

		private WebRequest StubWebRequest()
		{
			WebRequest mockedWebRequest = MockRepository.GenerateMock<WebRequest>();
			this.mockedWebRequestFactory.Stub(x => x.Create(Arg<Uri>.Is.Anything, Arg<IDictionary<string, string>>.Is.Anything))
				.Return(mockedWebRequest);

			return mockedWebRequest;
		}
	}
}
