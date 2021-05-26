using System.Net;
using System.Threading.Tasks;
using Xunit;

namespace Holiday.Integration.Tests
{
    public class HolidayControllerTests : IntegrationTest
    {
        [Fact]
        public async Task GetTopCountryHolidaysCnt_ReturnsEmpty()
        {
            // Act
            var response = await TestClient.GetAsync("holiday/GetCntCountry");

            // Assert
            Assert.Equal(HttpStatusCode.NotFound, response.StatusCode);
        }
        [Fact]
        public async Task GetTopMonthHolidaysCnt_ReturnsEmpty()
        {
            // Act
            var response = await TestClient.GetAsync("holiday/GetCntMonth");

            // Assert
            Assert.Equal(HttpStatusCode.NotFound, response.StatusCode);
        }
        [Fact]
        public async Task GetTopDistinctHolidaysCnt_ReturnsEmpty()
        {
            // Act
            var response = await TestClient.GetAsync("holiday/GetCntDistinct");

            // Assert
            Assert.Equal(HttpStatusCode.NotFound, response.StatusCode);
        }


    }

   
}
