using System.Net;

namespace gitProfilePOC1.Models
{
    public class GitUserProfile
    {
        public HttpStatusCode httpStatus { get; set; }
        public int id { get; set; }
        public string name { get; set; }
        public string? location { get; set; }
        public string avatar_url { get; set; }
        public string repos_url { get; set; }

        public List<GitUserRepos>? repos { get; set;}
    }
}
