using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GymDataAccsess.Models
{
    public class Category :BaseEntities 
    {
        public string Name { get; set; } = null!;






        public ICollection< Sessions> Sessions { get; set; } = new LinkedList<Sessions>();
    }
}
