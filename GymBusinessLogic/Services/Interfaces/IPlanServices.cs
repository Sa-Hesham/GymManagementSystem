using GymBusinessLogic.ViewModels.PlanViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GymBusinessLogic.Services.Interfaces
{
   public interface IPlanServices
    {
        IEnumerable<GetPlanView> GetPlans();

        GetPlanView ? getplanById(int id);
        bool status(int PlanId);

        bool updatePlan(int id, PlanUpdateView plan);



    }
}
