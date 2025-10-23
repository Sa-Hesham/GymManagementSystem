using GymBusinessLogic.Services.Clasess;
using GymBusinessLogic.Services.Interfaces;
using GymDataAccsess.Models;
using Microsoft.AspNetCore.Mvc;

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
          var sessions=  _seesionService.GetAllSessions();
            return View(sessions);
        }



        public IActionResult Details(int id) {

            if (id <= 0)
            {
                TempData["ErrorMassege"] = "Id Must Be not negative or 0 ";
                return RedirectToAction(nameof(Index));
            }
            var session= _seesionService.GetSessionById(id);

            if (session == null)
            {

                TempData["ErrorMassege"] = " session not Found ";
                return RedirectToAction(nameof(Index));
            }

            return View(session);
        
        }



        public IActionResult Create() { 
        
        
        
        return View();  
        
        }
    }
}
