using Microsoft.Graph;

namespace TeamApp.ViewModels
{
    public class ChannelVM
    {
        public string Id { get; set; }
        public string Description { get; set; }

        public string DisplayName { get; set; }

        public string Email { get; set; }

        public DateTimeOffset? CreatedDateTime { get; set; }

        public string WebUrl { get; set; }
        
        public ChannelVM(Channel model) {
            this.Id = model.Id;
            this.Description = model.Description;
            this.DisplayName = model.DisplayName;
            this.Email = model.Email;
            this.CreatedDateTime = model.CreatedDateTime;
            this.WebUrl = model.WebUrl;
        }
    }
}
