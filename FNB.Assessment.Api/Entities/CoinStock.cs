using System.ComponentModel.DataAnnotations;

namespace FNB.Assessment.Services.Api.Entities
{
    public class CoinStock : AuditableEntity
    {
        public int CoinStockId { get; set; }

        [Required(ErrorMessage = "CoinId is required.")]
        public short CoinId { get; set; }

        [Required(ErrorMessage = "Available stock is required.")]
        public long Available { get; set; }
    }
}
