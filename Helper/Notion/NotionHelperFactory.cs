using ScraperWithMiniApi.Helper.Notion.Model;

namespace ScraperWithMiniApi.Helper.Notion
{
    public static class NotionHelperFactory
    {
        public static NotionHelper Create(NotionOptions options)
        {
            return new NotionHelper(options);
        }
    }
}
