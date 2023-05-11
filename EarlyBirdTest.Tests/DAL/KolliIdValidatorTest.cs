using NUnit.Framework;
using EarlyBirdTest.Validations;

namespace EarlyBirdTest.Tests.DAL
{
    [TestFixture]
    public class KolliIdValidatorTest
    {
        private KolliIdValidator systemUnderTest;

        [SetUp]
        public void SetUp()
        {
            systemUnderTest = new KolliIdValidator();
        }

        [Test]
        public void KolliId_NotNumeric_ValidationFails()
        {
            var kolliId = "99911111111111111a";

            var results = systemUnderTest.Validate(kolliId);
             
            Assert.IsNotNull(results);
            Assert.IsFalse(results.IsValid);
            Assert.AreEqual(results.GetValidationErrors(), "KolliId must be numeric.");
        }


        [Test]
        public void KolliId_TooShort_ValidationFails()
        {
            var kolliId = "99911111111111111";

            var results = systemUnderTest.Validate(kolliId);

            Assert.IsNotNull(results);
            Assert.IsFalse(results.IsValid);
            Assert.AreEqual(results.GetValidationErrors(), "KolliId must be exactly 18 characters long.");
        }

        [Test]
        public void KolliId_TooLong_ValidationFails()
        {
            var kolliId = "9991111111111111111";

            var results = systemUnderTest.Validate(kolliId);

            Assert.IsNotNull(results);
            Assert.IsFalse(results.IsValid);
            Assert.AreEqual(results.GetValidationErrors(), "KolliId must be exactly 18 characters long.");
        }

        [Test]
        public void KolliId_IncorrectPrefix_ValidationFails()
        {
            var kolliId = "989111111111111111";

            var results = systemUnderTest.Validate(kolliId);

            Assert.IsNotNull(results);
            Assert.IsFalse(results.IsValid);
            Assert.AreEqual(results.GetValidationErrors(), "KolliId must start with 999.");
        }

        [Test]
        public void KolliId_3Errors_ValidationFailsWith3ErrorMessages()
        {
            var kolliId = "9891111111111111a";

            var results = systemUnderTest.Validate(kolliId);

            Assert.IsNotNull(results);
            Assert.IsFalse(results.IsValid);
            Assert.IsTrue(results.Errors.Count == 3);
        }

       [Test]
        public void KolliId_Correct_ValidationSucceeds()
        {
            var kolliId = "999111111111111111";

            var results = systemUnderTest.Validate(kolliId);

            Assert.IsNotNull(results);
            Assert.IsTrue(results.IsValid);
        }

    }
}
