using GymBusinessLogic.ViewModels.SessionViewModels;
using GymDataAccsess.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GymBusinessLogic.Services.Interfaces
{
    public interface ISeesionService
    {

        IEnumerable<SessionViewModel> GetAllSessions();

        SessionViewModel?GetSessionById(int  id);


        bool CreateSession(  CreateSessionViewModel sessionViewModel );



        UpdateSessionViewModel? GetSeesionToUpdate(int SessionsId);


        bool UpdateSession( UpdateSessionViewModel sessionUpdate , int SessionsId);




        bool DeleteSession( int SessionsId );



        IEnumerable<TrainerSelectViewModel> GetAllTrainersdrop();


        IEnumerable<CategorySelectViewModel> GetAllCategoriesdrop();



    }
}
