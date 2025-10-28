using AutoMapper;
using GymBusinessLogic.ViewModels.SessionViewModels;
using GymDataAccsess.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GymBusinessLogic
{
  public class MappingProfiles:Profile
    {

        public MappingProfiles()
        {
            CreateMap<Sessions, SessionViewModel>()
              .ForMember(dest => dest.CategoryName, options => options.MapFrom(src => src.SessionCategory.Name))
             .ForMember(dest => dest.TrainerName, options => options.MapFrom(src => src.TrainerSession.Name))
             .ForMember(dest => dest.AvilableSlots, options=>options.Ignore()) ;




            CreateMap<CreateSessionViewModel, Sessions>();



            CreateMap<Sessions, UpdateSessionViewModel>().ReverseMap();

            CreateMap<Trainer, TrainerSelectViewModel>();

            CreateMap<Category, CategorySelectViewModel>();


        }
    }
}
