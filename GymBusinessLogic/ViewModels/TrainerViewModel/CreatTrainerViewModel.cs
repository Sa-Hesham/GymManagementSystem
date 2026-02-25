using GymDataAccsess.Models.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GymBusinessLogic.ViewModels.TrainerViewModel
{
    public  class CreatTrainerViewModel
    {

        [Required (ErrorMessage ="Name is requierd")]
        [StringLength(50, MinimumLength = 4 , ErrorMessage = "Name must be between 4 and 50 ")]
        [RegularExpression(@"^[a-zA-z\s]+$" ,ErrorMessage ="inavlied Name")]
         public string Name { get; set; } = null!;


        [Required(ErrorMessage = "Email is requierd")]
        [EmailAddress(ErrorMessage ="Invalid Mail")]
        [DataType (DataType.EmailAddress)]
        [StringLength(100, MinimumLength = 5, ErrorMessage = "Email must be 5 char of more ")]
        public string Email { get; set; } = null!;

        


        [Required(ErrorMessage = "phone is requierd")]
        [Phone]
        [DataType (DataType.PhoneNumber)]
        [RegularExpression (@"^(011|012|010|015)\d{8}$" ,ErrorMessage ="invalid Phone Number")]

      public string Phone {  get; set; } =null!;




        [Required(ErrorMessage = "Specialites  is requierd")]
        public Specialites Specialites { get; set; }

        [Required(ErrorMessage = "Data of Birth  is requierd")]
        [DataType (DataType.Date)]

        public DateOnly DateOfdBirth { get; set; }


        [Required(ErrorMessage = "Gendar is requierd")]
        public Gendar Gendar { get; set; }





        [Required(ErrorMessage = " BuildingNumber  is requierd")]
        [Range(1, 900, ErrorMessage = "invalid building number ")]
        public int BuildingNumber { get; set; }


        [Required(ErrorMessage = " City  is requierd")]
        [StringLength(30, MinimumLength = 3, ErrorMessage = "City must be max 50 char and min 3 ")]
        [RegularExpression(@"^[A-Za-z\s]+$", ErrorMessage = "City must be one or more letters")]
        public string City { get; set; } = null!;

        [Required(ErrorMessage = " Street  is requierd")]
        [StringLength(30, MinimumLength = 3, ErrorMessage = "Street must be max 50 char and min 3 ")]
        public string Street { get; set; } = null!;

    }
}
