using GymBusinessLogic.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace GymManagement.Controllers
{
    public class TrainerController : Controller
    {
        private readonly ITrainerService _trainer;

        public TrainerController(ITrainerService trainer)
        {
            _trainer = trainer;
        }


        public IActionResult Index()
        {
            var trainers = _trainer.Getall();
            return View(trainers);
        }



        public IActionResult Create() { 
        
        
        
         return View();
        }
    }
}
