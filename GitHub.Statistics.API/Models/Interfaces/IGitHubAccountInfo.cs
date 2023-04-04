namespace GitHub.Statistics.API.Models.Interfaces
{
    public interface IGitHubAccountInfo
    {
        string Name { get; }

        string AvatarUrl { get; }

        string Bio { get; }

        string Company { get; }

        string Email { get; }

        string Location { get; }
    }
}
