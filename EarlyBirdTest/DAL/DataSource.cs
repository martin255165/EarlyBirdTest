using EarlyBirdTest.DAL.Models;

namespace EarlyBirdTest.DAL
{
    public static class DataSource
    {
        public static List<Kolli> dataSource;

        static DataSource()
        {
            dataSource = new List<Kolli>
            {
                new Kolli()  //valid kolli
                {
                    KolliId = "999111111111111111",
                    Height = Kolli.MaxHeight,
                    Length = Kolli.MaxLength,
                    Weight = Kolli.MaxWeight,
                    Width = Kolli.MaxWidth
                },
                new Kolli()  //invalid kolli
                {
                    KolliId = "999222222222222222",
                    Height = Kolli.MaxHeight,
                    Length = Kolli.MaxLength + 1,
                    Weight = Kolli.MaxWeight,
                    Width = Kolli.MaxWidth
                }
            };
        }
    }
}
