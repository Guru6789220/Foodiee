namespace Foodiee.FrontEnd.Services.IServices
{
    public interface ITokenProvider
    {
        void SetToken(string name,string token);
        string? GetToken();
        void ClearToken(string name);
    }
}
