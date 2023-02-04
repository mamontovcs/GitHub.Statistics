namespace GitHub.Statistics.Services.MediatR.Requests
{
    internal abstract class BaseRequest
    {
        protected BaseRequest(string accessToken)
        {
            AccessToken = accessToken;
        }

        public string AccessToken { get; set; }
    }
}
