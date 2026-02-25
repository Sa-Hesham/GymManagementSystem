using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GymBusinessLogic.ViewModels.MemberViewModel
{
    public class GetAllMembersView
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;

        public string ?photo { get; set; } 

        public string Email { get; set; } = null!;

        public string phoneNumber {  get; set; } = null!;   

        public string Gendar {  get; set; } = null!;    


        public string ?PlanName { get; set; } 


        public string? DateOfBirth { get; set; }   
        
        public string ? MemberShipStartDate { get; set; }

        public string? MemberShipEndDate { get; set; }

        public string? Address { get; set; }
    }
}
