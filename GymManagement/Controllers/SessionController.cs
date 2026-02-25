using GymBusinessLogic.Services.Clasess;
using GymBusinessLogic.Services.Interfaces;
using GymBusinessLogic.ViewModels.SessionViewModels;
using GymDataAccsess.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.VisualStudio.Web.CodeGenerators.Mvc.Templates.Blazor;

namespace GymManagement.Controllers
{
    public class SessionController : Controller
    {
        private readonly ISeesionService _seesionService;


        public SessionController(ISeesionService seesionService)
        {
            _seesionService = seesionService;
        }
        public IActionResult Index()
        {
            var sessions = _seesionService.GetAllSessions();
            return View(sessions);
        }



        public IActionResult Details(int id) {

            if (id <= 0)
            {
                TempData["ErrorMassege"] = "Id Must Be not negative or 0 ";
                return RedirectToAction(nameof(Index));
            }
            var session = _seesionService.GetSessionById(id);

            if (session == null)
            {

                TempData["ErrorMassege"] = " session not Found ";
                return RedirectToAction(nameof(Index));
            }

            return View(session);

        }



        public IActionResult Create() {

            var Catgeories = _seesionService.GetAllCategoriesdrop();

            ViewBag.Catgeories = new SelectList(Catgeories, "Id", "Name");


            var Trainers = _seesionService.GetAllTrainersdrop();
            ViewBag.Trainers = new SelectList(Trainers, "Id", "Name");

            return View();

        }


        [HttpPost]
        public IActionResult Create(CreateSessionViewModel sessions) {

            var result = _seesionService.CreateSession(sessions);
            if (!result)
            {

                TempData["ErrorMassege"] = "Created Field";


            }
            else
            {


                TempData["SuccsessMassege"] = "session Created successfully ";
            }
            return RedirectToAction(nameof(Index));


        }



        public IActionResult Edit(int id) {

            if (id <= 0) {

                TempData["ErrorMassege"] = "invalied session ";
                return RedirectToAction(nameof(Index));

            }

            var sessions = _seesionService.GetSessionById(id);
            if (sessions == null) {


                TempData["ErrorMassege"] = " session not found  ";
                return RedirectToAction(nameof(Index));

            }


            var Trainers = _seesionService.GetAllTrainersdrop();
            ViewBag.Trainers = new SelectList(Trainers, "Id", "Name");
            return View();

        }



        [HttpPost]
        public IActionResult Edit([FromRoute] int id, UpdateSessionViewModel session) {

            if (!ModelState.IsValid)
            {
                return View(session);
            }

            var result = _seesionService.UpdateSession(session, id);
            if (!result)
            {

                TempData["ErrorMassege"] = "updated Field Field";


            }
            else
            {


                TempData["SuccsessMassege"] = "session updated successfully ";
            }


            return RedirectToAction(nameof(Index));


        }





        public IActionResult Delete(int id) {

            if (id <= 0)
            {

                TempData["ErrorMassege"] = "invalied session ";
                return RedirectToAction(nameof(Index));

            }

            var sessions = _seesionService.GetSessionById(id);

            if (sessions is null)
            {
                TempData["ErrorMassege"] = " session not found  ";
                return RedirectToAction(nameof(Index));
            }

            ViewBag.SessionId = id;

            return View(sessions);
        }


        [HttpPost]
        public IActionResult DeleteConfirmed ( [FromForm]int id)  {
            
            
                    var result = _seesionService.DeleteSession(id);
            if (!result)
            {

                TempData["ErrorMassege"] = "delete Field";


            }
            else
            {


                TempData["SuccsessMassege"] = "session delete successfully ";
            }
            return RedirectToAction(nameof(Index));


        }

    }
    

   
}
