using System;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.AspNetCore.TestHost;
using RestEase;

namespace Blueprint.Api.IntegrationTests.Infrastructure
{
    public class BaseIntegrationTests<TApi> where TApi : IDisposable
    {
        protected readonly TApi Api;
        private readonly WebApplicationFactory<Startup> _factory;
        
        public BaseIntegrationTests()
        {
            _factory = new WebApplicationFactory<Startup>()
                .WithWebHostBuilder(
                    builder =>
                    {
                        builder.ConfigureTestServices(services =>
                        {

                        });
                    });

            var httpClient = _factory.CreateClient();
            Api = RestClient.For<TApi>(httpClient);
        }
    }
}