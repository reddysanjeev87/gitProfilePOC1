namespace gitProfilePOC1.Models
{
    public class GitUserRepos
    {
        public long id { get; set; }
        public string name { get; set; }
        public string html_url { get; set; }
        public string description { get; set; }
        public int stargazers_count { get; set; }
    }
}
