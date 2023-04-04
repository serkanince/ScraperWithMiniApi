using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Interactions;
using ScraperWithMiniApi.Helper.Notion.Model;
using WebDriverManager;
using WebDriverManager.DriverConfigs.Impl;
using WebDriverManager.Helpers;

namespace ScraperWithMiniApi.Helper
{
    public interface IBotHelper
    {
        CreateNotionPageRequest GetDataFromTargetSite();
    }

    public class BotHelper : IBotHelper
    {
        ChromeDriver driver;

        public BotHelper()
        {
            if (driver == null)
            {
                new DriverManager().SetUpDriver(new ChromeConfig(), "Latest", Architecture.X32);
                driver = new ChromeDriver(new ChromeOptions() { });
            }
        }

        public CreateNotionPageRequest GetDataFromTargetSite()
        {
            driver.Navigate().GoToUrl("https://sarisitedotcom/arazi-suv-pickup-peugeot-3008-1.6-puretech-active-prime-edition");

            driver.FindElement(By.Id("advancedSorting")).Click();
            {
                var element = driver.FindElement(By.LinkText("Fiyata göre (Önce en düşük)"));
                Actions builder = new Actions(driver);
                builder.MoveToElement(element).Perform();
            }
            driver.FindElement(By.LinkText("Fiyata göre (Önce en düşük)")).Click();
            var minPrice = driver.FindElement(By.CssSelector(".searchResultsItem:nth-child(1) > .searchResultsPriceValue span")).Text;
            Console.WriteLine(minPrice);
            {
                var element = driver.FindElement(By.Id("advancedSorting"));
                Actions builder = new Actions(driver);
                builder.MoveToElement(element).Perform();
            }

            Thread.Sleep(3000);
            driver.FindElement(By.Id("advancedSorting")).Click();
            {
                var element = driver.FindElement(By.TagName("body"));
                Actions builder = new Actions(driver);
                builder.MoveToElement(element, 0, 0).Perform();
            }
            driver.FindElement(By.LinkText("Fiyata göre (Önce en yüksek)")).Click();
            Thread.Sleep(3000);
            var maxPrice = driver.FindElement(By.CssSelector(".searchResultsItem:nth-child(1) > .searchResultsPriceValue span")).Text;
            Console.WriteLine(maxPrice);

            return new CreateNotionPageRequest()
            {
                Title = "peugeot-3008-1.6-puretech-active-prime-edition",
                MinPrice = minPrice,
                MaxPrice = maxPrice
            };
        }
    }
}
