using System.ComponentModel.DataAnnotations;

namespace FNB.Assessment.Services.Api.Entities
{
    public class Coin : AuditableEntity
    {
        public short CoinId { get; set; }

        [Required(ErrorMessage = "Name is required.")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Rand value is required.")]
        [Range(5, 500)]
        public double RandValue { get; set; }
    }
}
