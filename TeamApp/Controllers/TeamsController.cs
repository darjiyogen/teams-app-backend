using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Graph;
using TeamApp.ViewModels;

namespace TeamApp.Controllers
{
    [ApiController]
    public class TeamsController : Controller
    {
        private readonly GraphServiceClient _graphServiceClient;
        private readonly IConfiguration _configuration;

        public TeamsController(GraphServiceClient graphServiceClient, IConfiguration configuration) {
            this._graphServiceClient = graphServiceClient;
            this._configuration = configuration;
        }


        [HttpGet]
        [Route("/GetChannels")]
        public async Task<List<ChannelVM>> GetAsync()
        {
            string teamId = _configuration.GetValue<string>("TeamId");

            var channels = await _graphServiceClient.Teams[teamId].Channels.Request().GetAsync();

            return channels.Select(x => new ChannelVM(x)).ToList();

        }

    }
}
