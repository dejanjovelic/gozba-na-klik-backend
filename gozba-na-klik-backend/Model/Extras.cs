using gozba_na_klik_backend.Enum;

namespace gozba_na_klik_backend.Model
{
    public class Extras
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public double? Price { get; set; }
        public ExtrasType Type { get; set; }
    }
}
