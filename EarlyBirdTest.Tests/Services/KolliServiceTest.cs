using Moq;
using NUnit.Framework;
using EarlyBirdTest.DAL.Models;
using EarlyBirdTest.DAL.Repositories;
using EarlyBirdTest.Exceptions;
using EarlyBirdTest.Services;

namespace EarlyBirdTest.Tests.Services
{
    [TestFixture]
    public class KolliServiceTest
    {
        [Test]
        public void GetKolliById_IncorrectId_Throws_MalformedKolliIdException()
        {
            var kolliId = "9891111111a";

            var mock = new Mock<IKolliRepository>();

            var systemUnderTest = new KolliService(mock.Object);

            Assert.Throws<MalformedKolliIdException>(
                () => systemUnderTest.GetKolliById(kolliId)
            );
        }

        [Test]
        public void GetKolliById_NoKolliFound_Throws_KolliNotFoundException()
        {
            var kolliId = "999111111111111113";

            var mock = new Mock<IKolliRepository>();
            mock.Setup(p => p.GetKolliById(It.IsAny<string>())).Returns(null as Kolli);

            var systemUnderTest = new KolliService(mock.Object);

            Assert.Throws<KolliNotFoundException>(
               () => systemUnderTest.GetKolliById(kolliId)
           );
        }

        [Test]
        public void GetKolliById_KolliFound_Return_Kolli()
        {
            var kolliId = "999111111111111111";

            var mock = new Mock<IKolliRepository>();
            mock.Setup(p => p.GetKolliById(It.IsAny<string>())).Returns(new Kolli {
                KolliId = kolliId,
                Height = Kolli.MaxHeight,
                Length = Kolli.MaxLength,
                Weight = Kolli.MaxWeight,
                Width = Kolli.MaxWidth
            });

            var systemUnderTest = new KolliService(mock.Object);

            var kolli = systemUnderTest.GetKolliById(kolliId);

            Assert.IsNotNull(kolli);
            Assert.AreEqual(kolli.KolliId, kolliId);
        }

        [Test]
        public void InsertKolli_InvlaidKolliId_Throws_KolliInvalidException()
        {
            var kolli = new Kolli
            {
                KolliId = "9891111111a",
                Height = Kolli.MaxHeight,
                Length = Kolli.MaxLength,
                Weight = Kolli.MaxWeight,
                Width = Kolli.MaxWidth
            };

            var mock = new Mock<IKolliRepository>();

            var systemUnderTest = new KolliService(mock.Object);

            var ex = Assert.Throws<KolliInvalidException>(
                () => systemUnderTest.InsertKolli(kolli)
            );
        }


        [Test]
        public void InsertKolli_InvlaidKolli_Throws_KolliInvalidException()
        {
            var kolli = new Kolli
            {
                KolliId = "999111111111111111",
                Height = Kolli.MaxHeight,
                Length = Kolli.MaxLength,
                Weight = Kolli.MaxWeight + 1,
                Width = Kolli.MaxWidth
            };

            var mock = new Mock<IKolliRepository>();

            var systemUnderTest = new KolliService(mock.Object);

            var ex = Assert.Throws<KolliInvalidException>(
                () => systemUnderTest.InsertKolli(kolli)
            );
        }


        [Test]
        public void InsertKolli_ValidKolli_InsertKolli_Called()
        {
            var kolli = new Kolli
            {
                KolliId = "999111111111111111",
                Height = Kolli.MaxHeight,
                Length = Kolli.MaxLength,
                Weight = Kolli.MaxWeight,
                Width = Kolli.MaxWidth
            };

            var mock = new Mock<IKolliRepository>();
            mock.Setup(p => p.InsertKolli(kolli)).Verifiable();

            var systemUnderTest = new KolliService(mock.Object);

            systemUnderTest.InsertKolli(kolli);

            mock.Verify(p => p.InsertKolli(kolli));
        }
    }
}
