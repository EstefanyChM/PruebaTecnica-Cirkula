namespace Cirkula.WebApi.Exceptions
{
    public class CustomException : Exception
    {
        public string Code { get; }

        public CustomException(string code, string message) : base(message)
        {
            Code = code;
        }
    }
}
