namespace Authentication_API.Models.DTO
{
    public class ResponseDTO
    {
        public object? Result { get; set; }
        public bool Success { get; set; } = false;
        public string Message { get; set; } = "";
    }
}
