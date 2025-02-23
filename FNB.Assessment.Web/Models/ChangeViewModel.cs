using System.ComponentModel.DataAnnotations;

namespace FNB.Assessment.Web.Models
{
    public class ChangeViewModel
    {
        [Range(1, double.MaxValue)]
        public decimal Amount { get; set; }
        public string Denominations { get; set; }
    }
}
