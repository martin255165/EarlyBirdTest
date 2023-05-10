namespace EarlyBirdTest.Exceptions
{
    public class MalformedKolliIdException : Exception
    {
        private const string MessageTemplate = "The KolliID is invalid, errors:\n{0}";
        public MalformedKolliIdException(string kolliIdErrors) :base (string.Format(MessageTemplate, kolliIdErrors)) { }
    }
}
