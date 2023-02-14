namespace Conduit.Contracts.JWT
{
    public class RefreshTokenDto
    {
        public int UserId { get; set; }
        public string RefreshedToken { get; set; }
    }
}
