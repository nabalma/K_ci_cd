using Xunit;
using FluentAssertions;
using Kolyya.Api;
using Kolyya.Api.Models;

namespace Kolyya.Api.Tests
{
    public class SampleItemTests
    {
        [Fact]
        public void SampleItem_Should_Set_Name_Correctly()
        {
            var item = new SampleItem
            {
                Name = "Test"
            };

            item.Name.Should().Be("Test");
        }
    }
}
