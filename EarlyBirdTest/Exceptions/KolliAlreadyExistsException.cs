namespace EarlyBirdTest.Exceptions
{
    public class KolliAlreadyExistsException : Exception
    {
        private const string MessageTemplate = "A kolli with id {0} already exists in the database";

        public KolliAlreadyExistsException(string kolliId) : base(string.Format(MessageTemplate, kolliId)) { }
    }
}
