using EarlyBirdTest.DAL.Models;

namespace EarlyBirdTest.DAL.Repositories
{
    public class KolliRepository
    {
        public List<Kolli> GetAllKollis()
        {
            return DataSource.dataSource.ToList();
        }

        public Kolli? GetKolliById(string kolliId)
        {
            return DataSource.dataSource.Where(k => k.KolliId == kolliId).FirstOrDefault();
        }
    }
}
