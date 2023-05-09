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
                    KolliId = "0r5aTbreiGAbs0SjEP",
                    Height = Kolli.MaxHeight,
                    Length = Kolli.MaxLength,
                    Weight = Kolli.MaxWeight,
                    Width = Kolli.MaxWidth
                },
                new Kolli()  //invalid kolli
                {
                    KolliId = "li2D2mUnjgOydnTQgd",
                    Height = Kolli.MaxHeight,
                    Length = Kolli.MaxLength + 1,
                    Weight = Kolli.MaxWeight,
                    Width = Kolli.MaxWidth
                }
            };
        }
    }
}
