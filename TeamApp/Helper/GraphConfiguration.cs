using Azure.Identity;
using Microsoft.Graph;
using Microsoft.Identity.Client;

namespace TeamApp.Helper
{
    public static class GraphConfiguration
    {
        //Called in Startup - services.ConfigureGraphComponent(configuration)
        public static IServiceCollection ConfigureGraphComponent(this IServiceCollection services, IConfiguration configuration)
        {
            string[] scopes = new string[] { "https://graph.microsoft.com/.default" };
            var options = new TokenCredentialOptions
            {
                AuthorityHost = AzureAuthorityHosts.AzurePublicCloud
            };

            var clientSecretCredential = new ClientSecretCredential(
             configuration.GetValue<string>("AzureAd:TenantId"), configuration.GetValue<string>("AzureAd:ClientId"), configuration.GetValue<string>("AzureAd:ClientSecret"), options);


            services.AddScoped<GraphServiceClient>(sp =>
            {
                return new GraphServiceClient(clientSecretCredential);
            });

            return services;
        }
    }
}
