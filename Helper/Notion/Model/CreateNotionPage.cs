using System.Text.Json.Serialization;

namespace ScraperWithMiniApi.Helper.Notion.Model
{

    public class CreateNotionPage
    {
        [JsonPropertyName("parent")]
        public ParentDatabase Parent { get; set; }

        [JsonPropertyName("properties")]
        public PageProperties Properties { get; set; }
    }

    public class PageProperties
    {
        [JsonPropertyName("Title")]
        public PageTitle Title { get; set; }

        [JsonPropertyName("Date")]
        public PageDate Date { get; set; }

        [JsonPropertyName("MinPrice")]
        public PageRichText MinPrice { get; set; }

        [JsonPropertyName("MaxPrice")]
        public PageRichText MaxPrice { get; set; }
    }

    public class ParentDatabase
    {
        [JsonPropertyName("database_id")]
        public string DatabaseId { get; set; }
    }

    public class PageTitle
    {
        [JsonPropertyName("title")]
        public Title[] Title { get; set; }
    }

    public class Title
    {
        [JsonPropertyName("text")]
        public PageTitleText Text { get; set; }
    }

    public class PageTitleText
    {
        [JsonPropertyName("content")]
        public string Content { get; set; }
    }

    public class PageDate
    {
        [JsonPropertyName("date")]
        public PageDateValue Date { get; set; }
    }

    public class PageDateValue
    {
        [JsonPropertyName("start")]
        public string Start { get; set; }
    }

    public class PageRichText
    {
        [JsonPropertyName("rich_text")]
        public PageRichTextValue[] RichText { get; set; }
    }

    public class PageRichTextValue
    {
        [JsonPropertyName("text")]
        public PageRichTextContent Text { get; set; }
    }

    public class PageRichTextContent
    {
        [JsonPropertyName("content")]
        public string Content { get; set; }
    }


}
