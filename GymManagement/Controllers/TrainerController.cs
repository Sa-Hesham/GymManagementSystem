using GymBusinessLogic.Services.Interfaces;
using GymBusinessLogic.ViewModels.TrainerViewModel;
using GymDataAccsess.Models;
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



        public IActionResult Create()
        {



            return View();
        }



        [HttpPost]

        public IActionResult CreateMember(CreatTrainerViewModel trainerViewModel)
        {

            if (!ModelState.IsValid)
            {

                ModelState.AddModelError("InvalidData", "Cheak Data And Missing Field");
                return View(nameof(Create), trainerViewModel);

            }


            bool IsCreate = _trainer.CreatTrainer(trainerViewModel);

            if (!IsCreate)
            {

                TempData["ErrorMassege"] = "Created Field";


            }
            else
            {


                TempData["SuccsessMassege"] = "Trainer Created successfully ";
            }




            return RedirectToAction(nameof(Index));
        }




        public IActionResult Details(int id)
        {
            if (id <= 0)
            {
                TempData["ErrorMassege"] = "Id Must Be not negative or 0 ";
                return RedirectToAction(nameof(Index));
            }
            var trainer = _trainer.GetTrainerDetails(id);
            if (trainer == null)
            {

                TempData["ErrorMassege"] = " Trainer not Found ";
                return RedirectToAction(nameof(Index));
            }

            return View(trainer);
        }



        public IActionResult Edit(int id)
        {

            ViewBag.TrainerId = id;

            if (id <= 0)
                {
                    TempData["ErrorMassege"] = "Id Must Be not negative or 0 ";
                    return RedirectToAction(nameof(Index));
                }

                var trainer = _trainer.UpdateTrainerView(id);
                if (trainer == null)
                {

                    TempData["ErrorMassege"] = " Trainer not Found ";
                    return RedirectToAction(nameof(Index));
                }

       
                return View(trainer);

            
        }

        [HttpPost]

        public IActionResult EditTrainer([FromForm] int id, UpdateTrainerViewModelcs trainerView) {
            
            if (!ModelState.IsValid)
            {
                ModelState.AddModelError("InvalidData", "Cheak Data And Missing Field");
                return View(nameof(Edit),trainerView);

            }

            var result = _trainer.UpdateTrainer(id, trainerView);
            if (!result)
                TempData["ErrorMassege"] = "Faild to updated ";
            else
                TempData["SuccsessMassege"] = "Member Updated successfully ";




            return RedirectToAction(nameof(Index));
        
        
        }
        
        
        
        
        
    }
}
