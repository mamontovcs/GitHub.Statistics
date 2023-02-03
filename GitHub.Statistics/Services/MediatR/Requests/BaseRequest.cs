namespace GitHub.Statistics.Services.MediatR.Requests
{
    internal abstract class BaseRequest
    {
        protected BaseRequest(string accessToken)
        {
            AccessToken = accessToken;
        }

        protected string AccessToken { get; set; }
    }
}
