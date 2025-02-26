using Microsoft.VisualStudio.TestTools.UnitTesting;
using Microsoft.Playwright;
using System;
using System.Threading.Tasks;
using System.IO;

namespace PlaywrightTestProject
{
    [TestClass]
    public class Test1 : PageTest
    {
        private const string BaseUrl = "http://localhost:64412/";

        [TestMethod]
        public async Task TestAccountOrPasswordErrorValidation()
        {
            await Page.GotoAsync(BaseUrl);

            await Page.FillAsync("#fUserId", "admin@ceec.edu.tw");
            await Page.FillAsync("#fPwd", "123");

            await Page.ClickAsync("input[type='submit']");

            // 等待並獲取錯誤訊息
            var errorMessage = await Page.Locator(".col-md-offset-2.col-md-10").TextContentAsync();
            Console.WriteLine($"錯誤訊息: {errorMessage}");

            await Page.ScreenshotAsync(new PageScreenshotOptions
            {
                Path = "TestResults/login_error.png",
                FullPage = true
            });
        }
        [TestMethod]
        public async Task TestLoginAndFormValidation()
        {
            await Page.GotoAsync(BaseUrl);

            await Page.FillAsync("#fUserId", "admin@ceec.edu.tw");
            await Page.FillAsync("#fPwd", "123456");

            await Page.ClickAsync("input[type='submit']");

            // 等待Page跳轉
            await Page.WaitForURLAsync("**/Default/Index");

            await Page.FillAsync("#Name", "Ren");
            await Page.FillAsync("#Email", "adminceec.edu.tw");

            await Page.WaitForTimeoutAsync(1000);

            // 讓Email欄位失去Focus後觸發驗證
            await Page.Locator("#Email").BlurAsync();

            // 等待驗證訊息出現
            await Page.WaitForSelectorAsync("[data-valmsg-for='Email']", new PageWaitForSelectorOptions
            {
                State = WaitForSelectorState.Attached
            });

            await Page.ClickAsync("input[value='Create']");
            
            // 獲取錯誤訊息
            var emailInput = Page.Locator("#Email");
            var validationMessage = await emailInput.EvaluateAsync<string>("el => el.validationMessage");

            Console.WriteLine($"驗證訊息: {validationMessage}");

            await Page.WaitForTimeoutAsync(1000);

            await Page.ScreenshotAsync(new PageScreenshotOptions
            {
                Path = "TestResults/email_validation_error.png",
                FullPage = true
            });
        }

        [TestMethod]
        public async Task TestSuccessfulSubmission()
        {
            await Page.GotoAsync(BaseUrl);
            await Page.FillAsync("#fUserId", "admin@ceec.edu.tw");
            await Page.FillAsync("#fPwd", "123456");
            await Page.ClickAsync("input[type='submit']");

            // 等待Page跳轉
            await Page.WaitForURLAsync("**/Default/Index");

            await Page.FillAsync("#Name", "Ren");
            await Page.FillAsync("#Email", "admin@ceec.edu.tw");

            await Page.ClickAsync("input[value='Create']");

            // 等待驗證成功
            var successMessage = await Page.TextContentAsync("body");
            Console.WriteLine($"成功訊息: {successMessage}");

            await Page.ScreenshotAsync(new PageScreenshotOptions
            {
                Path = "TestResults/successful_submission.png",
                FullPage = true
            });
        }
    }
}
