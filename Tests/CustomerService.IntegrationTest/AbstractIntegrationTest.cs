using AggregateGateway;
using Microsoft.AspNetCore.Mvc.Testing;
using System.Net.Http;

namespace CustomerService.IntegrationTest
{
    public abstract class AbstractIntegrationTest
    {


        protected readonly HttpClient TestClient;
        public AbstractIntegrationTest()
        {
            var appfactory = new WebApplicationFactory<Startup>();
            TestClient = appfactory.CreateClient();
        }
    }
}
