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

        IEnumerable<TEntity> GetAll();


        int Add(TEntity model);


        int Update(TEntity model);


        int Delete(TEntity model);
    }
}
