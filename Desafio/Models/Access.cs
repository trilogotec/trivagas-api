namespace Desafio.Models
{
    public class Access : Register
    {
        public string Token { get; set; }
        public int UserId { get; set; }
        public User User { get; set; }
    }
}
