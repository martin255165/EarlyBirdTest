using EarlyBirdTest.DAL.Models;

namespace EarlyBirdTest.DAL.Repositories
{
    public interface IKolliRepository
    {
        List<Kolli> GetAllKollis();
        Kolli? GetKolliById(string kolliId);
        void InsertKolli(Kolli kolli);
        bool KolliExists(string kolliId);
    }
}
