using System.Threading.Tasks;
using Shouldly;
using Xunit;

namespace MultipleDbContextDemo.Pages;

public class Index_Tests : MultipleDbContextDemoWebTestBase
{
    [Fact]
    public async Task Welcome_Page()
    {
        var response = await GetResponseAsStringAsync("/");
        response.ShouldNotBeNull();
    }
}
