namespace EarlyBirdTest.Exceptions
{
    public class KolliNotFoundException : Exception
    {
        private const string MessageTemplate = "Could not find kolli with id {0}";

        public KolliNotFoundException(string kolliId): base(string.Format(MessageTemplate, kolliId)) { }
    }
}
