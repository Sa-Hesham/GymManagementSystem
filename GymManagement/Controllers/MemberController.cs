using GymBusinessLogic.Services.Interfaces;
using GymBusinessLogic.ViewModels.MemberViewModel;
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
                TempData["ErrorMassege"] = "Id Must Be not negative or 0 ";
                return RedirectToAction(nameof(Index));
            }

            var member = _members.GetMemberDetails(id);

            if (member is null)
            {
                TempData["ErrorMassege"] = "member not found  ";
                return RedirectToAction(nameof(Index));
            }

            return View(member);
        }


        public IActionResult showMemberHelthRecord(int id)
        {
            if (id <= 0) {

                TempData["ErrorMassege"] = "Id Must Be not negative or 0 ";

                return RedirectToAction(nameof(Index));
            
            }

            var memberHelathrecord = _members.HelthRecordMember(id);

            return View(memberHelathrecord);
        }

        public IActionResult Create()
        {
            return View();
        }

        public IActionResult CreateMember(CreateMemberViewModel CreatedMember)
        {
            if (!ModelState.IsValid)
            {
                ModelState.AddModelError("InvalidData", "Cheak Data And Missing Field");
                return View(nameof(Create),CreateMember);
            }
           bool  IsCreated =  _members.CreateMember(CreatedMember);
            if (!IsCreated)
                TempData["ErrorMassege"] = "Member not Created ";
            else
                TempData["SuccsessMassege"] = "Member Created successfully ";

            return RedirectToAction(nameof(Index));



        }
    }
}
