using GymBusinessLogic.Services.Interfaces;
using GymBusinessLogic.ViewModels.TrainerViewModel;
using GymDataAccsess.Models;
using GymDataAccsess.Repositres.Classes;
using GymDataAccsess.Repositres.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GymBusinessLogic.Services.Clasess
{
    public class TrainerServices : ITrainerService
    {
        private readonly IUnitOfWork unitOfWork;

        public TrainerServices(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        public bool CreatTrainer(CreatTrainerViewModel trainerViewModel)
        {
            try
            {
              
                if (IsEmailExist(trainerViewModel.Email) || IsPhoneExist(trainerViewModel.Phone)) return false;

                var Trainer = new Trainer()
                {

                    Name = trainerViewModel.Name,
                    Phone = trainerViewModel.Phone,
                    Email = trainerViewModel.Email,
                    Specialies = trainerViewModel.Specialites,
                    DateOfBirth = trainerViewModel.DateOfdBirth,
                    Gendar = trainerViewModel.Gendar,
                    CreatedAt=DateTime.Now,
                    Address = new Address()
                    {
                        BuildingNumber = trainerViewModel.BuildingNumber,
                        street = trainerViewModel.Street,
                        city = trainerViewModel.City,

                    }





                };

                unitOfWork.GetRepositry<Trainer>().Add(Trainer);
                return unitOfWork.saveCahnges() > 0;
            }
            catch (Exception)
            {

                return false;
            }
        }

        public bool DeleteTrainer(int trainerId)
        {
            var trainer = unitOfWork.GetRepositry<Trainer>().GetById(trainerId);
            if (trainer == null) return false;


            var session = unitOfWork.GetRepositry<Sessions>().GetAll(x=>x.TrainerId== trainerId && x.StartDate > DateTime.Now).Any();
            if(session) return false;

            try
            {

                var deletetsession = unitOfWork.GetRepositry<Sessions>().GetAll(x => x.TrainerId == trainerId);
                foreach (var sessions in deletetsession)
                {
                    unitOfWork.GetRepositry<Sessions>().Delete(sessions);
                }


                unitOfWork.GetRepositry<Trainer>().Delete(trainer);

                return unitOfWork.saveCahnges() > 0;

            }
            catch (Exception)
            {

                return false;
            }


        }

        public IEnumerable<TrainerDetailsViewModel> Getall()
        {
           var Trainers = unitOfWork.GetRepositry<Trainer>().GetAll();
            if (Trainers is null || !Trainers.Any()) {

                return Enumerable.Empty<TrainerDetailsViewModel>();
            }
            
            var trainerView = Trainers.Select(x => new TrainerDetailsViewModel
            {
                id = x.Id,
                Name = x.Name,
                Specialites = x.Specialies.ToString(),
                DateOfBirth = x.DateOfBirth.ToString(),
                Email = x.Email,
                Phone = x.Phone,
                Address = $"{x.Address.BuildingNumber}-{x.Address.street}-{x.Address.city}",
            });
            return trainerView; 
        }

        public TrainerDetailsViewModel? GetTrainerDetails(int TrainerId)
        {
          var trainer= unitOfWork.GetRepositry<Trainer>().GetById(TrainerId);   
            if (trainer == null) return null;

            return new TrainerDetailsViewModel()
            {

                Name = trainer.Name,
                Phone = trainer.Phone,
                Email = trainer.Email,
                Specialites = trainer.Specialies.ToString(),
                DateOfBirth =trainer.DateOfBirth.ToShortDateString(),
                Address = $"{trainer.Address.BuildingNumber} - {trainer.Address.street} - {trainer.Address.city}"
               




            };




        }

        public bool UpdateTrainer(int trainerId, UpdateTrainerViewModelcs updateTrainer)
        {
            try
            {
              
               var EmailExist = unitOfWork.GetRepositry<Trainer>().GetAll(x=>x.Email ==updateTrainer.Email && x.Id !=trainerId);
                var phoneExist  = unitOfWork.GetRepositry<Trainer>().GetAll(x => x.Phone == updateTrainer.phone && x.Id != trainerId);
                if(EmailExist.Any() || phoneExist.Any()) return false;  
                var trainer = unitOfWork.GetRepositry<Trainer>().GetById(trainerId);
                if (trainer == null) return false;

                trainer.Name = updateTrainer.Name;
                trainer.Email = updateTrainer.Email;
                trainer.Phone = updateTrainer.phone;
                trainer.Address.BuildingNumber = updateTrainer.BuildingNumber;
                trainer.Address.city = updateTrainer.City;
                trainer.Address.street = updateTrainer.Street;
                trainer.Specialies = trainer.Specialies;
                trainer.UpdatedAt = DateTime.Now;
                unitOfWork.GetRepositry<Trainer>().Update(trainer);
                return unitOfWork.saveCahnges() > 0;
            }
            catch (Exception)
            {

             return false;
            }


        }

        public UpdateTrainerViewModelcs? UpdateTrainerView(int TrainerId)
        {
            var trainer = unitOfWork.GetRepositry<Trainer>().GetById(TrainerId);
            if (trainer == null) return null;
            return new UpdateTrainerViewModelcs() { 
            
                Name = trainer.Name,
                Email = trainer.Email,
                phone = trainer.Phone,
                BuildingNumber=trainer.Address.BuildingNumber,
                City=trainer.Address.city,
                Street=trainer.Address.street,
                Specialization=trainer.Specialies,
            
            
            
            };

        }






        private bool  IsEmailExist( string mail)
        {
            return unitOfWork.GetRepositry<Trainer>().GetAll(x=>x.Email == mail).Any(); 

        }


        private bool IsPhoneExist(string phone)
        {
            return unitOfWork.GetRepositry<Trainer>().GetAll(x => x.Phone == phone).Any();
        }
    }


   
}
