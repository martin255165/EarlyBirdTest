using NUnit.Framework;
using EarlyBirdTest.DAL.Models;
using EarlyBirdTest.Validations;

namespace EarlyBirdTest.Tests.DAL
{
    [TestFixture]
    public class KolliValidatorTest
    {
        private KolliValidator systemUnderTest;

        [SetUp]
        public void SetUp()
        {
            systemUnderTest = new KolliValidator();
        }

        [Test]
        public void Kolli_TooHeavy_ValidationFails()
        {
            var target = new Kolli
            {
                Weight = Kolli.MaxWeight + 1,
                Length = Kolli.MaxLength,
                Height = Kolli.MaxHeight,
                Width = Kolli.MaxWidth
            };

            var results = systemUnderTest.Validate(target);

            Assert.IsNotNull(results);
            Assert.IsFalse(results.IsValid);
            Assert.AreEqual(results.GetValidationErrors(), $"A kolli can only weigh {Kolli.MaxWeight} grams.");
        }

        [Test]
        public void Kolli_TooWide_ValidationFails()
        {
            var target = new Kolli
            {
                Weight = Kolli.MaxWeight,
                Length = Kolli.MaxLength,
                Height = Kolli.MaxHeight,
                Width = Kolli.MaxWidth + 1
            };

            var results = systemUnderTest.Validate(target);

            Assert.IsNotNull(results);
            Assert.IsFalse(results.IsValid);
            Assert.AreEqual(results.GetValidationErrors(), $"A kolli can only be {Kolli.MaxWidth} cm wide.");
        }

        [Test]
        public void Kolli_TooHigh_ValidationFails()
        {
            var target = new Kolli
            {
                Weight = Kolli.MaxWeight,
                Length = Kolli.MaxLength,
                Height = Kolli.MaxHeight + 1,
                Width = Kolli.MaxWidth
            };

            var results = systemUnderTest.Validate(target);

            Assert.IsNotNull(results);
            Assert.IsFalse(results.IsValid);
            Assert.AreEqual(results.GetValidationErrors(), $"A kolli can only be {Kolli.MaxHeight} cm high.");
        }

        [Test]
        public void Kolli_TooLong_ValidationFails()
        {
            var target = new Kolli
            {
                Weight = Kolli.MaxWeight,
                Length = Kolli.MaxLength + 1,
                Height = Kolli.MaxHeight,
                Width = Kolli.MaxWidth
            };

            var results = systemUnderTest.Validate(target);

            Assert.IsNotNull(results);
            Assert.IsFalse(results.IsValid);
            Assert.AreEqual(results.GetValidationErrors(), $"A kolli can only be {Kolli.MaxLength} cm long.");
        }

        [Test]
        public void Kolli_WithinParams_ValidationSucceeds()
        {
            var target = new Kolli
            {
                Weight = Kolli.MaxWeight,
                Length = Kolli.MaxLength,
                Height = Kolli.MaxHeight,
                Width = Kolli.MaxWidth
            };

            var results = systemUnderTest.Validate(target);

            Assert.IsNotNull(results);
            Assert.IsTrue(results.IsValid);
        }
    }
}
