using GymBusinessLogic.Services.Interfaces;
using GymBusinessLogic.ViewModels.PlanViewModel;
using GymDataAccsess.Models;
using GymDataAccsess.Repositres.Interfaces;
using Microsoft.EntityFrameworkCore.Metadata;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GymBusinessLogic.Services.Clasess
{
    public class PlanService : IPlanServices
    {
        private readonly IUnitOfWork unitOfWork;

        public PlanService(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }
        public GetPlanView? getplanById(int id)
        {
            var plan = unitOfWork.GetRepositry<Plan>().GetById(id);
            if(plan == null) return null;
             return    new GetPlanView()
            {
                Id= plan.Id,
                Name= plan.Name,
                Description= plan.Description,
                Price= plan.Price,
                DurationDays= plan.DurationDays,
                IsActive= plan.IsActive,

            };

        
        }

        public IEnumerable<GetPlanView> GetPlans()
        {
            var plan = unitOfWork.GetRepositry<Plan>().GetAll();
            if (plan == null || !plan.Any()) return [];

           return plan.Select(x => new GetPlanView() {
               Id= x.Id,
               Description= x.Description,  
               Price= x.Price,  
               DurationDays= x.DurationDays,
               IsActive= x.IsActive,
               Name= x.Name,
              
               
               

            });
        }

        public bool status(int PlanId)
        {
            
            var repo = unitOfWork.GetRepositry<Plan>();
            var plan = repo.GetById(PlanId);
            if (plan is null) return false;
            plan.IsActive = plan.IsActive == true ? false : true;
            plan.UpdatedAt = DateTime.Now;
            try 
            { 
            
                repo.Update(plan);
                    return unitOfWork.saveCahnges() > 0;


            }
            catch (Exception) 
            { 
            
                return false;
            
            }
        }

      public PlanUpdateView? ReturnplanViewToupdate(int planid)
        {
            var plan= unitOfWork.GetRepositry<Plan>().GetById(planid);
            if (plan is null || plan.IsActive == false) return null;

            return new PlanUpdateView()
            {
                PlanName = plan.Name,
                Description = plan.Description,
                Price = plan.Price,
                DurationDays = plan.DurationDays,


            };
        }
        public bool updatePlan(int id, PlanUpdateView planupdate)
        {
            try
            {
                var plan = unitOfWork.GetRepositry<Plan>().GetById(id);
                if (plan is null || plan.IsActive == false) return false;
                (plan.Name, plan.Description, plan.Price, plan.DurationDays, plan.UpdatedAt) =
                    (planupdate.PlanName, planupdate.Description, planupdate.Price, planupdate.DurationDays, DateTime.Now);

                unitOfWork.GetRepositry<Plan>().Update(plan);
                return unitOfWork.saveCahnges() > 0;
            }
            catch (Exception)
            {

                return false;
            }


        }
    }
}
