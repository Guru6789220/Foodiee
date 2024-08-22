namespace Foodiee.FrontEnd.Utility
{
    public class SD
    {
        public enum Apitype
            { 
            GET,POST,PUT,DELETE
            }
        public static string CouponApiBase { get; set; }
        public static string AuthApiBase { get; set; }

        public const string TokenCookie = "JWTToken";
    }
}
