namespace gozba_na_klik_backend.Model
{
    public abstract class User
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Email { get; set; }
        public string ContactNumber { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string? ProfileImageUrl { get; set; }
        public abstract Role Role { get; }

    }
}
