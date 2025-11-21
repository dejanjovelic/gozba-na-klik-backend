namespace gozba_na_klik_backend.Model
{
    public class Courier
    {
        public string Id { get; set; }
        public ApplicationUser? ApplicationUser { get; set; }
        public List<WorkingHours>? WorkingHours { get; set; } = new List<WorkingHours>();
        public bool Active { get; set; }

    }
}