namespace ScraperWithMiniApi.Helper.Notion.Model
{
    public class NotionOptions
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="databaseId">YOUR_DABASE_ID</param>
        /// <param name="token">YOUR_AUTH_TOKEN</param>
        public NotionOptions(string databaseId,string token)
        {
            DatabaseId = databaseId;
            AuthToken = token;
        }

        /// <summary>
        /// YOUR_DABASE_ID
        /// </summary>
        public string DatabaseId { get; set; }
        /// <summary>
        /// YOUR_AUTH_TOKEN
        /// </summary>
        public string AuthToken { get; set; }
        public string Version { get; set; } = "2022-02-22";
        public string Url { get; set; } = "https://api.notion.com/v1/";
    }
}
