namespace gozba_na_klik_backend.Model
{
    public class Courier : User
    {
        public override Role Role => Role.Courier;
        public List<WorkingHours>? WorkingHours { get; set; } = new List<WorkingHours>();
        public bool active { get; set; }

    }
}