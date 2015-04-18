namespace Franky.Playground.BaseTests
{
	using System;
	using NUnit.Framework;
	using Guard = Franky.Playground.Base.Guard;

	[TestFixture]
	public class GuardTests
	{
		[Test]
		public void NotNullThrowExceptionWithMessage()
		{
			// Act
			ArgumentNullException exception = Assert.Throws<ArgumentNullException>(() => Guard.NotNull(null, "Parameter"));

			// Assert
			Assert.AreEqual("Parameter", exception.ParamName);
		}

		[Test]
		public void NotNullThrowsExceptionEvenIfParamNameIsNull()
		{
			// Act
			ArgumentNullException exception = Assert.Throws<ArgumentNullException>(() => Guard.NotNull(null, null));

			// Assert
			Assert.IsNull(exception.ParamName);
		}

		[TestCase("")]
		[TestCase(1)]
		[TestCase(1L)]
		[TestCase(true)]
		public void NotNullDoesNotThrowExceptionIfValueIsNotNull(object value)
		{
			// Act
			Assert.DoesNotThrow(() => Guard.NotNull(value, null));
		}
	}
}
