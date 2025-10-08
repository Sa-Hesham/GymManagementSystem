using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GymBusinessLogic.ViewModels.MemberViewModel
{
   public class HelthRecordView
    {

        [Required (ErrorMessage ="Height is requierd ")]
        [Range(0.1 ,300,ErrorMessage ="invalied Height")]
        public decimal Heigth { get; set; }


        [Required(ErrorMessage = "Weight is requierd ")]
        [Range(30, 500, ErrorMessage = "invalied weight")]
        
        public decimal weigth { get; set; }


        [Required(ErrorMessage = " BloodType is requierd ")]
        [StringLength(3,ErrorMessage ="invalid Blood Type ")]
        public string BloodType { get; set; } = null!;



        public string ?Note {  get; set; } 
    }
}
