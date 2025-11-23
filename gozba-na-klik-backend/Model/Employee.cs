namespace gozba_na_klik_backend.Model
{
    public class Employee
    {
        public string Id { get; set; }
        public ApplicationUser? ApplicationUser { get; set; }
        public bool IsSuspended { get; set; } = false;
    }
}
