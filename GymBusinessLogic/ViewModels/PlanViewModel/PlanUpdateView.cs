using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GymBusinessLogic.ViewModels.PlanViewModel
{
    public class PlanUpdateView
    {
        [Required (ErrorMessage ="Name is requierd")]
        [StringLength (50 ,ErrorMessage = "planName Must Be 50") ]
        public string PlanName { get; set; } = null!;

        [Required(ErrorMessage = "Description is requierd")]
        [StringLength(200,MinimumLength =20, ErrorMessage = "planName Must  Be 20 to 200")]
        public string Description { get; set; }= null!;

        [Required(ErrorMessage = " DurationDays is requierd")]
        [Range(1,365 ,ErrorMessage = "invalid DurationDays must be from 1 to 365")]
        public int DurationDays { get; set; }
        [Required(ErrorMessage = "PRice  is requierd")]
        [Range(0.1, 10000, ErrorMessage = "invalid price must be from 1 to 10000")]
        public decimal Price { get; set; }
    }
}
