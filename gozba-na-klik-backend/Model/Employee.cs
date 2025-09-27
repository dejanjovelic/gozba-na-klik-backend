using gozba_na_klik_backend.Enum;

namespace gozba_na_klik_backend.Model
{
    public class Employee : User
    {
        public override Role Role => Role.Employee;
        public bool IsSuspended { get; set; } = false;
    }
}
