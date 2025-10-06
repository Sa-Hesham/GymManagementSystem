using GymDataAccsess.Data;
using GymDataAccsess.Models;
using GymDataAccsess.Repositres.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GymDataAccsess.Repositres.Classes
{
    internal class MemberRepositry : IMemberRepositry
    {
        private readonly  GymDbContext DbContext;
        public MemberRepositry(GymDbContext dbContext)
        {
            this.DbContext = dbContext;
        }

        public int Add(Member member)
        {
            DbContext.Members.Add(member);   
              return DbContext.SaveChanges();    
        }

        public int Delete(int id)
        {
           var member= DbContext.Members.Find(id);
            if (member == null) return 0;


            DbContext.Remove(member);
         
             
            return DbContext.SaveChanges();
        }

        public IEnumerable<Member> getAll() => DbContext.Members.ToList();


        public Member? GetById(int id)
        {

            return DbContext.Members.Find(id);  
          

        }





        public int Update(Member member)
        {
            DbContext.Members.Update(member); 
           return DbContext.SaveChanges();
            
        }

      

     
    }
}
