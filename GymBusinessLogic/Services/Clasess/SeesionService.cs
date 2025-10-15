using AutoMapper;
using GymBusinessLogic.Services.Interfaces;
using GymBusinessLogic.ViewModels.SessionViewModels;
using GymDataAccsess.Models;
using GymDataAccsess.Repositres.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GymBusinessLogic.Services.Clasess
{
    public class SeesionService : ISeesionService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public SeesionService(IUnitOfWork unitOfWork ,IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public bool CreateSession(CreateSessionViewModel sessionViewModel)
        {
            try
            {
                if (!TrainerIsExist(sessionViewModel.TrainerId)) return false;

                if (!CategoryIsExist(sessionViewModel.CategoryId)) return false;

                if (!DateIsvalied(sessionViewModel.StartDate, sessionViewModel.EndDate)) return false;

                if (sessionViewModel.Capcity > 25 || sessionViewModel.Capcity < 0) return false;


                var mapseesion = _mapper.Map<Sessions>(sessionViewModel);


                _unitOfWork.GetRepositry<Sessions>().Add(mapseesion);

                return _unitOfWork.saveCahnges() > 0;

            }
            catch (Exception ex )
            {

                Console.WriteLine($"Create session Faield  {ex }");
                

                return false;
            }
        }

        public IEnumerable<SessionViewModel> GetAllSessions()
        {
            var sessions = _unitOfWork.SessionRepositry.GetAllSessionsWithTrainerAndCategory();

            if ((sessions is null) || (!sessions.Any())) return [];

            //return sessions.Select(s => new SessionViewModel
            //{
            //    id = s.Id,

            //    Description = s.Description,
            //    StartDate = s.StartDate,
            //    EndDate = s.EndDate,
            //    Capcity = s.Capcity,
            //    TrainerName = s.TrainerSession.Name,
            //    CategoryName = s.SessionCategory.Name,
            //    AvilableSlots = s.Capcity - _unitOfWork.SessionRepositry.GetCountOfBookedSlots(s.Id)







            //});


            var mapeed =_mapper.Map<IEnumerable<Sessions>,IEnumerable<SessionViewModel>>(sessions);
            foreach (var session in mapeed) 
                session.AvilableSlots = session.Capcity - _unitOfWork.SessionRepositry.GetCountOfBookedSlots(session.Id);



            return mapeed;
         

        }

        public SessionViewModel? GetSessionById(int id)
        {
           var session = _unitOfWork.SessionRepositry.GetSessionWithTrainerAndCategory(id);
            if (session is null) return null;


            var mapedsession = _mapper.Map<Sessions,SessionViewModel>(session); 
            mapedsession.AvilableSlots=mapedsession.Capcity-_unitOfWork.SessionRepositry.GetCountOfBookedSlots(mapedsession.Id); 
            
            
            return mapedsession;   

           
        }


        public UpdateSessionViewModel? GetSeesionToUpdate(int SessionsId)
        {
            var session = _unitOfWork.SessionRepositry.GetById(SessionsId);
            if (session is null) return null; 
            
            if(!IsSessionAvilable(session)) return null ;

            return _mapper.Map<UpdateSessionViewModel>(session);
        }

        public bool UpdateSession(UpdateSessionViewModel SessionUpdate , int SessionsId)
        {
            try
            {
                var session = _unitOfWork.SessionRepositry.GetById(SessionsId);
                if (session is null) return false;

                if (!IsSessionAvilable(session)) return false;

                if(!TrainerIsExist(session.TrainerId)) return false;

                if (!CategoryIsExist(session.CategoryId)) return false;


                _mapper.Map(SessionUpdate, session);
                session.UpdatedAt = DateTime.Now;   


                _unitOfWork.SessionRepositry.Update(session);

              

                return _unitOfWork.saveCahnges()>0;

            }
            catch (Exception ex )
            {
                Console.WriteLine($"Can not update {ex}");
                return false;
            }
        }



        public bool DeleteSession(int SessionsId)
        {
            try
            {
                var session = _unitOfWork.SessionRepositry.GetById(SessionsId);

                if(!IsSessionAvilableToDelete(session!)) return false;
                _unitOfWork.SessionRepositry.Delete(session!);
                return _unitOfWork.saveCahnges() > 0;
            }
            catch (Exception ex )
            {

                Console.WriteLine($"delte is faield  {ex}");
                return false;
            }
        }







        #region HelperMethods



        private bool IsSessionAvilable (Sessions session)
        {

            if (session is null) return false;  

            if (session.StartDate <=DateTime.Now) return false;
            if(session.EndDate <DateTime.Now)   return false;

            // if sessions has Active Booking
            var HasActiveBooking =  _unitOfWork.SessionRepositry.GetCountOfBookedSlots (session.Id) >0 ;

            if (HasActiveBooking) return false;  

            return true;
        }
        private  bool TrainerIsExist(int trainerid )
        {
            var trainer = _unitOfWork.GetRepositry<Trainer>().GetById(trainerid);   

            if (trainer is not null) return true;

            return false;
        }


        private bool CategoryIsExist(int categoryid)
        {
            var category = _unitOfWork.GetRepositry<Category>().GetById(categoryid);

            if (category is not  null) return true;

            return false;
        }



        private bool DateIsvalied (DateTime SatrtDate , DateTime EndDate)
        {

            return SatrtDate < EndDate;
        }


        private bool IsSessionAvilableToDelete(Sessions session)
        {

            if (session is null) return false;

            if (session.StartDate <= DateTime.Now && session.EndDate >DateTime.Now) return false;
            if (session.StartDate > DateTime.Now) return false;

            // if sessions has Active Booking
            var HasActiveBooking = _unitOfWork.SessionRepositry.GetCountOfBookedSlots(session.Id) > 0;

            if (HasActiveBooking) return false;

            return true;
        }


        #endregion
    }
}
