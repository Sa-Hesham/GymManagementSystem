using GymBusinessLogic.ViewModels.MemberViewModel;
using GymDataAccsess.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GymBusinessLogic.Services.Interfaces
{
    public interface ImemberService
    {

        IEnumerable<GetAllMembersView> GetAll();

        bool CreateMember(CreateMemberViewModel createMember);


        GetAllMembersView? GetMemberDetails(int Memberid);



       HelthRecordView? HelthRecordMember (int Memberid);



       MemberDataUpdateViewModel? upatedMember ( int Memberid);

        bool UpdateMember(int id , MemberDataUpdateViewModel updateMember);


        bool DeleteMember(int Memberid);
    }
}
