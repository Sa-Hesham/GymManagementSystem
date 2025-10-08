using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GymDataAccsess.Models
{
    [Owned]
   public class Address
    {
        public int BuildingNumber { get; set; } 

        public string city { get; set; } = null!;


        public string street { get; set; } = null!;
    }
}
