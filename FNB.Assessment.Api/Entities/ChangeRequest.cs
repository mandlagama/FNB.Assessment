using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FNB.Assessment.Services.Api.Entities
{
    public class ChangeRequest
    {
        [Required(ErrorMessage = "Amount is required.")]
        [Range(1, double.MaxValue)]
        public decimal Amount { get; set; }

        [Required(ErrorMessage = "Denominations is required.")]
        public int[] Denominations { get; set; }
    }
}
