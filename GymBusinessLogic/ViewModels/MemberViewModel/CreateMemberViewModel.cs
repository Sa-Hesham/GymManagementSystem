using GymDataAccsess.Models.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GymBusinessLogic.ViewModels.MemberViewModel
{
    public class CreateMemberViewModel
    {

        [Required(ErrorMessage = "Name Is requierd")]
        [StringLength(50, MinimumLength = 3, ErrorMessage = "name must be max 50 char and min 3 ")]
        [RegularExpression(@"^[A-Za-z\s]+$", ErrorMessage = "Name must be one or more letters")]
       public  string Name { get; set; } = null!;


        [Required(ErrorMessage ="Email is Requierd")]
        [EmailAddress (ErrorMessage ="InvalidEmail")] //validation
       [ DataType(DataType.EmailAddress)]  //ui hint 
        [StringLength (100,MinimumLength =5,ErrorMessage ="Email must be 5 char of more ")]
        public string Email { get; set; } =null!;



        [Required (ErrorMessage = "phone is requierd")]
        [Phone(ErrorMessage ="Invalid phoneNumber ")]
        [DataType(DataType.PhoneNumber)]
        [RegularExpression (@"^(010|011|012|015)\d{8}$",ErrorMessage ="number must be Epyotion Phone number ")]
        public  string phone {  get; set; } =null!;


        [Required(ErrorMessage = "DateOfBirth Is requeird")]
        [DataType(DataType.Date)]
        public DateOnly DateOfBirth { get; set; }


        [Required(ErrorMessage = "Gendar is requierd")]
        public Gendar Gendar { get; set; }



        [Required(ErrorMessage = " BuildingNumber  is requierd")]
        [Range(1,900 ,ErrorMessage ="invalid building number ")]
        public int BuildingNumber { get; set; }


        [Required(ErrorMessage = " City  is requierd")]
        [StringLength(30, MinimumLength = 3, ErrorMessage = "City must be max 50 char and min 3 ")]
        [RegularExpression(@"^[A-Za-z\s]+$", ErrorMessage = "City must be one or more letters")]
        public string City { get; set; } = null!;

        [Required(ErrorMessage = " Street  is requierd")]
        [StringLength(30, MinimumLength = 3, ErrorMessage = "Street must be max 50 char and min 3 ")]
        public string Street { get; set; } = null!;



        [Required (ErrorMessage ="Health record is requierd ")]
      public  HelthRecordView HelthRecordView { get; set; }=null!;
    }
}
