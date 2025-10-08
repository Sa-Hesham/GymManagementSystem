using GymDataAccsess.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GymDataAccsess.Repositres.Interfaces
{
    public interface IRepositryGenaric<TEntity> where TEntity: BaseEntities 
    {

        TEntity? GetById(int id);

        IEnumerable<TEntity> GetAll(Func<TEntity, bool>? conditiom = null );


        void Add(TEntity model);
     
   
        void Update(TEntity model);
      
      
        void Delete(TEntity model);
    }
}
