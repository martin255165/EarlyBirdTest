using EarlyBirdTest.DAL.Models;
using NUnit.Framework;

namespace EarlyBirdTest.Tests.DAL
{
    [TestFixture]
    public  class KolliTest
    {
        [Test]
        public void Kolli_TooHeavy_NotValid()
        {
            var target = new Kolli
            {
                Weight = Kolli.MaxWeight + 1,
                Length = Kolli.MaxLength,
                Height = Kolli.MaxHeight,
                Width = Kolli.MaxWidth
            };

            var isValid = target.IsValid;

            Assert.IsFalse(isValid);
        }


        [Test]
        public void Kolli_TooLong_NotValid()
        {
            var target = new Kolli
            {
                Weight = Kolli.MaxWeight,
                Length = Kolli.MaxLength + 1,
                Height = Kolli.MaxHeight,
                Width = Kolli.MaxWidth
            };

            var isValid = target.IsValid;

            Assert.IsFalse(isValid);
        }

        [Test]
        public void Kolli_TooHigh_NotValid()
        {
            var target = new Kolli
            {
                Weight = Kolli.MaxWeight,
                Length = Kolli.MaxLength,
                Height = Kolli.MaxHeight + 1,
                Width = Kolli.MaxWidth
            };

            var isValid = target.IsValid;

            Assert.IsFalse(isValid);
        }

        [Test]
        public void Kolli_TooWide_NotValid()
        {
            var target = new Kolli
            {
                Weight = Kolli.MaxWeight,
                Length = Kolli.MaxLength,
                Height = Kolli.MaxHeight,
                Width = Kolli.MaxWidth + 1
            };

            var isValid = target.IsValid;

            Assert.IsFalse(isValid);
        }


        [Test]
        public void Kolli_WithinParams_Valid()
        {
            var target = new Kolli
            {
                Weight = Kolli.MaxWeight,
                Length = Kolli.MaxLength,
                Height = Kolli.MaxHeight,
                Width = Kolli.MaxWidth
            };

            var isValid = target.IsValid;

            Assert.IsTrue(isValid);
        }
    }
}
