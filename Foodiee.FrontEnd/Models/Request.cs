

using static Foodiee.FrontEnd.Utility.SD;

namespace Foodiee.FrontEnd.Models
{
    public class Request
    {
        public Apitype ApiMethod { get; set; } = Apitype.GET;
        public string? Url { get; set; }

        public object? Data { get; set; }

        public string? AccessToken { get; set; }
    }
}
