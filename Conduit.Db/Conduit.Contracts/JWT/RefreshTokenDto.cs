namespace Conduit.Web.JWT
{
    public class RefreshTokenDto
    {
        public int UserId { get; set; }
        public string Token { get; set; }
        public string refreshToken { get; set; }
        public bool IsActive { get; set; }
    }
}
