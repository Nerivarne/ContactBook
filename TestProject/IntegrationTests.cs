using System.Net.Http;
using Microsoft.AspNetCore.Mvc.Testing;
using Xunit;

namespace TestProject
{
    public class IntegrationTests : IClassFixture<WebApplicationFactory<Program>>
    {
        private readonly HttpClient _httpClient;

        public IntegrationTests(WebApplicationFactory<Program> factory)
        {
            _httpClient = factory.CreateClient();
        }

        [Fact]
        public void MainPageLoadsSuccessfully()
        {
            var responseMessage = _httpClient.GetAsync("/").Result;
            var actualStatusCode = (int)responseMessage.StatusCode;
            var expectedStatusCode = 200;

            Assert.Equal(expectedStatusCode, actualStatusCode);
        }
    }
}