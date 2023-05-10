using NUnit.Framework;
using EarlyBirdTest.DAL.Repositories;

namespace EarlyBirdTest.Tests.DAL
{
    [TestFixture]
    public class KolliRepositoryTest
    {
        private KolliRepository systemUnderTest;

        [SetUp]
        public void SetUp()
        {
            systemUnderTest = new KolliRepository();
        }

        [Test]
        public void GetAllKollis_Returns_ListOFKollis()
        {
            var target = systemUnderTest.GetAllKollis();

            CollectionAssert.IsNotEmpty(target);
        }

        [Test]
        public void GetKolliById_IncorrectId_ReturnsNull()
        {
            string kolliId = "incorrect";

            var target = systemUnderTest.GetKolliById(kolliId);

            Assert.IsNull(target);
        }

        [Test]
        public void GetKolliById_CorrectId_ReturnsKolli()
        {
            string kolliId = "999111111111111111";

            var target = systemUnderTest.GetKolliById(kolliId);

            Assert.IsNotNull(target);
            Assert.AreEqual(target.KolliId, kolliId);
        }
    }
}
