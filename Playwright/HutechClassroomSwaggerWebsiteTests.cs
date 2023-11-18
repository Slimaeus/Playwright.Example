using Microsoft.Playwright;
using Microsoft.Playwright.NUnit;
using System.Text.RegularExpressions;

namespace Playwright;
[Parallelizable(ParallelScope.Self)]
[TestFixture]
public class HutechClassroomSwaggerWebsiteTests : PageTest
{
    [SetUp]
    public async Task SetUp()
    {
        // Set environment variable HEADED = 1

        await Page.GotoAsync("https://hutechclassroom.azurewebsites.net/swagger/index.html");
    }
    [Test]
    public async Task TestExampleLicenseLinkNavigation()
    {
        // Arrange
        var exampleLicense = Page.GetByRole(AriaRole.Link, new() { Name = "Example License" });

        // Act
        await exampleLicense.ClickAsync();

        // Assert
        await Expect(exampleLicense).ToHaveAttributeAsync("href", "https://example.com/license");
    }

    [Test]
    public async Task TestAuthorizationModal()
    {
        // Arrange
        await Page.Locator("section").Filter(new() { HasTextRegex = new Regex("^Authorize$") }).Locator("div").ClickAsync();

        await Page.GetByRole(AriaRole.Button, new() { Name = "Authorize", Exact = true }).ClickAsync();

        await Page.GetByLabel("auth-bearer-value").FillAsync("Token");

        await Page.GetByRole(AriaRole.Button, new() { Name = "Authorize" }).Nth(1).ClickAsync();

        await Page.GetByRole(AriaRole.Button, new() { Name = "Close" }).ClickAsync();

        await Page.GetByRole(AriaRole.Button, new() { Name = "Authorize", Exact = true }).ClickAsync();

        var authorizationModal = Page.GetByRole(AriaRole.Heading, new() { Name = "Available authorizations" });
        // Act


        // Assert
        await Expect(authorizationModal).ToBeVisibleAsync(new() { Visible = true });
    }
}
