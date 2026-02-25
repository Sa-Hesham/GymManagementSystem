using GymBusinessLogic.ViewModels.TrainerViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GymBusinessLogic.Services.Interfaces
{
   public  interface ITrainerService
    {

        bool CreatTrainer(CreatTrainerViewModel trainerViewModel);

        TrainerDetailsViewModel? GetTrainerDetails(int TrainerId);



        UpdateTrainerViewModelcs? UpdateTrainerView(int TrainerId);


        bool UpdateTrainer(int trainerId, UpdateTrainerViewModelcs updateTrainer);



        bool DeleteTrainer(int trainerId);


        IEnumerable<TrainerDetailsViewModel> Getall();


     

    }
}
