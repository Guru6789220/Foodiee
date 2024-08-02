namespace Foodiee.FrontEnd.Models
{
    public class Response
    {
        public object? Result { get; set; }
        public bool Success { get; set; } = false;
        public string? Message { get; set; } = "";
    }
}
