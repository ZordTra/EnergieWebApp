namespace EnergieWebApp.Models
{
    public class Account
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public User? User { get; set; }
        public Admin? Admin { get; set; }

    }
}
