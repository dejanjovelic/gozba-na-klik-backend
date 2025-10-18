namespace gozba_na_klik_backend.Model
{
    public class Administrator: User
    {
        public override Role Role => Role.Administrator;
    }
}
