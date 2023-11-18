using Microsoft.Playwright;
using Microsoft.Playwright.NUnit;
using System.Text.RegularExpressions;

namespace Playwright;

[Parallelizable(ParallelScope.Self)]
[TestFixture]
public partial class PlaywrigtWebsiteTests : PageTest
{

    [SetUp]
    public async Task Setup()
    {
        await Page.GotoAsync("https://playwright.dev");
    }


    [Test]
    public void MyTestMethod()
    {
        // Arrange
        var num = 3;

        // Act
        num += 1;

        // Assert
        Assert.That(num, Is.EqualTo(4));
    }


    [Test]
    public void ArraysAreEqualTest()
    {
        // Arrange
        var a = new int[] { 5, 67 };

        // Act

        // Assert
        CollectionAssert.AreEqual(a, new int[] { 5, 67 });
    }

    [Test]
    public async Task TestGetStartedLinkNavigationAndAttributes()
    {
        // Expect a title "to contain" a substring.
        await Expect(Page).ToHaveTitleAsync(new Regex("Playwright"));

        // create a locator
        var getStarted = Page.GetByRole(AriaRole.Link, new() { Name = "Get started" });

        // Expect an attribute "to be strictly equal" to the value.
        await Expect(getStarted).ToHaveAttributeAsync("href", "/docs/intro");

        // Click the get started link.
        await getStarted.ClickAsync();

        // Expects the URL to contain intro.
        await Expect(Page).ToHaveURLAsync(new Regex(".*intro"));
    }

    [Test]
    public async Task TestCommunityLinkNavigationAndAttributes()
    {
        // Expect a title "to contain" a substring.
        await Expect(Page).ToHaveTitleAsync(new Regex("Playwright"));

        // create a locator
        var welcome = Page.GetByRole(AriaRole.Link, new() { Name = "Community" });

        // Expect an attribute "to be strictly equal" to the value.
        await Expect(welcome).ToHaveAttributeAsync("href", "/community/welcome");

        // Click the get started link.
        await welcome.ClickAsync();

        // Expects the URL to contain intro.
        await Expect(Page).ToHaveURLAsync(new Regex(".*welcome"));
    }
}