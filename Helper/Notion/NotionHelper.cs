using ScraperWithMiniApi.Helper.Notion.Model;
using System.Text;
using System.Text.Json;

namespace ScraperWithMiniApi.Helper.Notion
{
    public interface INotionHelper
    {
        Task<bool?> CreatePage(CreateNotionPageRequest request);
    }

    public class NotionHelper : INotionHelper
    {
        private readonly HttpClient _httpClient;
        private readonly NotionOptions _options;

        public NotionHelper(NotionOptions options)
        {
            _httpClient = new HttpClient();
            _options = options;
        }

        public async Task<bool?> CreatePage(CreateNotionPageRequest request)
        {
            var endpoint = $"{_options.Url}pages/";
            var httpRequest = new HttpRequestMessage(HttpMethod.Post, endpoint);

            httpRequest.Headers.Add("Notion-Version", _options.Version);
            httpRequest.Headers.Add("Authorization", $"Bearer {_options.AuthToken}");

            var page = new CreateNotionPage()
            {
                Parent = new ParentDatabase()
                {
                    DatabaseId = _options.DatabaseId
                },
                Properties = new PageProperties()
                {
                    Title = new PageTitle()
                    {
                        Title = new[] { new Title() { Text = new PageTitleText() { Content = request.Title }, } }
                    },
                    Date = new PageDate()
                    {
                        Date = new PageDateValue()
                        {
                            Start = DateTime.Now.ToString("yyyy-MM-dd"),
                        }
                    },
                    MinPrice = new PageRichText()
                    {
                        RichText = new[] { new PageRichTextValue() { Text = new PageRichTextContent() { Content = request.MinPrice } } }
                    },
                    MaxPrice = new PageRichText()
                    {
                        RichText = new[] { new PageRichTextValue() { Text = new PageRichTextContent() { Content = request.MaxPrice } } }

                    }
                }
            };

            var json = JsonSerializer.Serialize(page);
            httpRequest.Content = new StringContent(json, Encoding.UTF8, "application/json");

            var response = await _httpClient.SendAsync(httpRequest);
            response.EnsureSuccessStatusCode();


            return true;
        }
    }
}
