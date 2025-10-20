using GymBusinessLogic.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace GymManagement.Controllers
{
    public class MemberController : Controller
    {
        private readonly ImemberService _members;

        public MemberController(ImemberService members)
        {
            _members = members;
        }
        public IActionResult Index()
        {
            var members=_members.GetAll();
            return View(members);
        }


        public IActionResult Details(int id ) { 
            
            if (id <= 0)
            {
                return RedirectToAction(nameof(Index));
            }

            var member = _members.GetMemberDetails(id);
        
        
         return View(member);
        }


        public IActionResult showMemberHelthRecord(int id)
        {
            if (id <= 0) {

                return RedirectToAction(nameof(Index));
            
            }

            var memberHelathrecord = _members.HelthRecordMember(id);

            return View(memberHelathrecord);
        }
    }
}
