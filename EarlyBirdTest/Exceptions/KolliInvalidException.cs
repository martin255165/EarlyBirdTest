namespace EarlyBirdTest.Exceptions
{
    public class KolliInvalidException : Exception
    {
        private const string MessageTemplate = "The supplied kolli is invalid please recheck the dimensions, kolliId and weight. Errors:\n";

        public KolliInvalidException(string kolliIdErrors, string kolliErrors) 
            : base(
                  MessageTemplate +
                  (!string.IsNullOrEmpty(kolliIdErrors) ? "KolliId errors:\n" + kolliIdErrors + "\n": "") +
                  (!string.IsNullOrEmpty(kolliErrors) ? "Kolli errors:\n" + kolliErrors : "")
              ) { }
    }
}
