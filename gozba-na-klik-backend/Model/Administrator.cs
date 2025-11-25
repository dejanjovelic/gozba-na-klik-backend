using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace gozba_na_klik_backend.Model
{
    public class Administrator
    {
        [Key]
        public string Id { get; set; }
        [ForeignKey(nameof(Id))]
        public ApplicationUser? ApplicationUser { get; set; }
    }
}
