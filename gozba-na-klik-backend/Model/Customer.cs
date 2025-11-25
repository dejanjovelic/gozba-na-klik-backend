using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace gozba_na_klik_backend.Model
{
    public class Customer 
    {
        [Key]
        public string Id { get; set; }
        [ForeignKey(nameof(Id))]
        public ApplicationUser?  ApplicationUser { get; set; }
        public List<Allergen>? Allergens { get; set; } = new List<Allergen>();
        public List<Address>? Addresses { get; set; } = new List<Address>();
        public List<Order>? Orders { get; set; } = new List<Order>();
    }
}
