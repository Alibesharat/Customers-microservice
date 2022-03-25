using Microsoft.AspNetCore.Http;
using System.Net;
using System.Threading.Tasks;
using Xunit;

namespace CustomerService.IntegrationTest
{
    public class CustomerControllerTest : AbstractIntegrationTest
    {
        [Fact]
        public async Task Get_WithOut_Parameter_Should_Response_Badrequest()
        {

            var response = await TestClient.GetAsync("Customer");

            var errormesage = await response.Content.ReadAsStringAsync();
            Assert.Equal(HttpStatusCode.BadRequest, response.StatusCode);
            Assert.Equal("[\"'Email' must not be empty.\"]", errormesage);
        }


        [Fact]
        public async Task Get_With_Wrong_Email_Should_Response_Badrequest()
        {

            var response = await TestClient.GetAsync("Customer?Email=test");

            var errormesage = await response.Content.ReadAsStringAsync();
            Assert.Equal(HttpStatusCode.BadRequest, response.StatusCode);
            Assert.Equal("[\"'Email' is not a valid email address.\"]", errormesage);
        }




    }
}
