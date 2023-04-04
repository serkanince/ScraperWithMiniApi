using ScraperWithMiniApi.Helper;
using ScraperWithMiniApi.Helper.Notion;
using ScraperWithMiniApi.Helper.Notion.Model;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddTransient<IBotHelper, BotHelper>();

var app = builder.Build();

app.MapGet("/", (IBotHelper helper) =>
{
    var request = helper.GetDataFromTargetSite();

    var notion = NotionHelperFactory.Create(new NotionOptions("YOUR_DABASE_ID", "YOUR_AUTH_TOKEN"));
    notion?.CreatePage(request);

    return request;
});

app.Run();
