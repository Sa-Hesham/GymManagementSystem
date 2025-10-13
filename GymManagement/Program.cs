using GymBusinessLogic;
using GymDataAccsess.Data;
using GymDataAccsess.Data.SeedData;
using GymDataAccsess.Repositres.Classes;
using GymDataAccsess.Repositres.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace GymManagement
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllersWithViews();
            builder.Services.AddDbContext<GymDbContext>(options =>
            {
                //Section name in app setting json (First)
                // second  [json key of section ] =>>>>> GetSection("SectionName")[sectionKeyName]
                //options.UseSqlServer(builder.Configuration.GetSection("ConnectionStrings")["DefaultConnection"]);
                //options.UseSqlServer(builder.Configuration["ConnectionStrings:DefaultConnection"]);

                //Short Hand way 
                options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
            });

            builder.Services.AddScoped(typeof(IRepositryGenaric<>), typeof(GenaricRpositry<>));

            builder.Services.AddScoped<IUnitOfWork,UnitOFWork>();

             builder.Services.AddScoped<ISessionRepositry, SessionRepositry>();
            builder.Services.AddAutoMapper(x => x.AddProfile(new MappingProfiles()));


            var app = builder.Build();

            using var scope = app.Services.CreateScope() ;

                var dbcontext = scope.ServiceProvider.GetRequiredService<GymDbContext>() ;
            GymDataSeeding.seedData(dbcontext);




                // Configure the HTTP request pipeline.
                if (!app.Environment.IsDevelopment())
                {
                    app.UseExceptionHandler("/Home/Error");
                    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                    app.UseHsts();
                }

            app.UseHttpsRedirection();
            app.UseRouting();

            app.UseAuthorization();

            app.MapStaticAssets();
            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}")
                .WithStaticAssets();

            app.Run();
        }
    }
}
