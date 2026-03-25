namespace gozba_na_klik_backend.Services.Exceptions
{
    public class NotAuthorizedAccessException : Exception
    {
        public NotAuthorizedAccessException(string message) : base(message)
        {
        }
    }
}
