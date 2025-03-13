namespace Foodies.APIs.Errors
{
    public class ServerErrorApiResponse : BaseErrorApiResponse
    {
        public string? Details { get; set; }

        public ServerErrorApiResponse(int code, string? message = null, string? details = null) : base(code, message)
        {
            Details = details;
        }
    }
}
