using GymDataAccsess.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace GymDataAccsess.Data.SeedData
{
    public static class GymDataSeeding
    {
        public static bool seedData(GymDbContext dbContext)
        {
            try
            {

                var Hasplans = dbContext.Plans.Any();
                var Hascategories = dbContext.categories.Any();
                if (Hasplans && Hascategories) return false;

                if (!Hasplans)
                {
                    var plans = ReadData<Plan>("plans.json");
                    if (plans.Any())
                        dbContext.AddRange(plans);
                }

                if (!Hascategories)
                {
                    var categories = ReadData<Category>("categories.json");
                    if (categories.Any())
                        dbContext.AddRange(categories);
                }

                return dbContext.SaveChanges() > 0;

            }
            catch (Exception ex )
            {

                Console.WriteLine($"seeding Fiekd {ex}");
                return false;
            }


        }




        private  static List<T> ReadData <T>(string FileName)
        {
          
            var Filepath = Path.Combine(Directory.GetCurrentDirectory(),"wwwroot","Files",FileName);

            if (!File.Exists(Filepath)) throw  new FileNotFoundException();

            var data = File.ReadAllText(Filepath);

            var options = new JsonSerializerOptions() { 
            
            
               PropertyNameCaseInsensitive = true,
            
            
            };


            return JsonSerializer.Deserialize<List<T>>(data,options) ?? new List<T>();  

           


        }

    }
           
}
