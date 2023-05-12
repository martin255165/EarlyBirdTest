using EarlyBirdTest.DAL.Models;

namespace EarlyBirdTest.DAL.Repositories
{
    public class KolliRepository : IKolliRepository
    {
        public List<Kolli> GetAllKollis()
        {
            return DataSource.dataSource.ToList();
        }

        public Kolli? GetKolliById(string kolliId)
        {
            return DataSource.dataSource.Where(k => k.KolliId == kolliId).FirstOrDefault();
        }

        public void InsertKolli(Kolli kolli)
        {
            DataSource.dataSource.Add(kolli);
        }

        public bool KolliExists(string kolliId)
        {
            return DataSource.dataSource.Any(k => k.KolliId == kolliId);
        }
    }
}
