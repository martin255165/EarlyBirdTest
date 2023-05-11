namespace EarlyBirdTest.DAL.Models
{
    public class Kolli
    {
        public const int MaxWeight = 20000;
        public const int MaxLength = 60;
        public const int MaxHeight = 60;
        public const int MaxWidth = 60;

        public string KolliId { get; set; }
        public int Weight { get; set; }
        public int Length { get; set;}
        public int Height { get; set; }
        public int Width { get; set; }
        public bool IsValid 
        { 
            get
            {
                var x =
                Weight <= MaxWeight &&
                Length <= MaxLength &&
                Height <= MaxHeight &&
                Width <= MaxWidth;
                return x;
            } 
        }
    }
}
