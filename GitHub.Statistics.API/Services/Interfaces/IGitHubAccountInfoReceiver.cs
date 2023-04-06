using GitHub.Statistics.API.Models.Interfaces;

namespace GitHub.Statistics.API.Services.Interfaces
{
    /// <summary>
    /// Service, which is responsible for retrieving information about GitHub account
    /// </summary>
    public interface IGitHubAccountInfoReceiver
    {
        /// <summary>
        /// Gets information about GitHub account
        /// </summary>
        /// <returns>Information about GitHub account</returns>
        Task<IGitHubAccountInfo> GetGitHubAccountInfo();
    }
}
