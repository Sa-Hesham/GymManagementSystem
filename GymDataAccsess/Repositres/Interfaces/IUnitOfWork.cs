using GymDataAccsess.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GymDataAccsess.Repositres.Interfaces
{
   public interface IUnitOfWork 
    {
        IRepositryGenaric<TEntity> GetRepositry<TEntity>() where TEntity : BaseEntities, new();

        int saveCahnges();
        
    }
}
