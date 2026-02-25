using GymBusinessLogic.Services.Interfaces;
using GymBusinessLogic.ViewModels.PlanViewModel;
using Microsoft.AspNetCore.Mvc;

namespace GymManagement.Controllers
{
    public class PlanController : Controller
    {
        private readonly IPlanServices _planService;

        public PlanController(IPlanServices planService)
        {
            _planService = planService;
        }
        public IActionResult Index()
        {
           var plans= _planService.GetPlans();
            return View(plans);
        }


        public IActionResult Details(int id ) {

            if (id <= 0) {

                TempData["ErrorMassege"] = "Id is not Avilable must be not zero or negative";
                return RedirectToAction(nameof(Index));
            
            
            }
            var plan = _planService.getplanById(id);

            if(plan is null)
            {
                TempData["ErrorMassege"] = "plan not found ";
                return RedirectToAction(nameof(Index));
            }




            return View(plan);
        
        
        
        
        }




        public IActionResult Edit(int id )
        {
            if (id <= 0)
            {

                TempData["ErrorMassege"] = "Id is not Avilable must be not zero or negative";
                return RedirectToAction(nameof(Index));


            }


           var plan = _planService.ReturnplanViewToupdate (id);
            if (plan is null) {

                TempData["ErrorMassege"] = "plan can not updated ";
                return RedirectToAction(nameof(Index));



            }



            return View(plan);  
        }




        [HttpPost]
        public IActionResult Edit ( [FromRoute]int id , PlanUpdateView planView)
        {

            if (!ModelState.IsValid) {

                ModelState.AddModelError("WrongData", "cheak your data ");
                return View(planView);
            
            
            }

            var result = _planService.updatePlan(id, planView);


            if (!result)
                TempData["ErrorMassege"] = "Faild to updated ";
            else
                TempData["SuccsessMassege"] = "Plan Updated successfully ";





            return RedirectToAction(nameof(Index));
        }









        [HttpPost]
        public IActionResult Delete(int id) { 
        
        var result = _planService.status(id);
           


            if (!result)
                TempData["ErrorMassege"] = "Faild to change ";
            else
                TempData["SuccsessMassege"] = "Plan changed successfully ";

            return RedirectToAction(nameof(Index));

        }

    }
}
