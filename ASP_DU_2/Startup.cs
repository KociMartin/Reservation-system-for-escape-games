using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.EntityFrameworkCore;
using ASP_DU_2.Model.Services;
using ASP_DU_2.Model;

namespace ASP_DU_2
{
    public class Startup
    {
        public Startup(IHostingEnvironment env)
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(env.ContentRootPath)
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                .AddJsonFile($"appsettings.{env.EnvironmentName}.json", optional: true)
                .AddEnvironmentVariables();
            Configuration = builder.Build();
        }

        public IConfigurationRoot Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            //Pridani do service konkretni implementaci rozhrani
            services.AddTransient<ICustomerService, CustomerService>();
            services.AddTransient<IReservationService, ReservationService>();
            services.AddTransient<IRoomService, RoomService>();
            //Pridani connectiomn stringu
            services.AddDbContext<DatabaseContext>(options => options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));
            // Add framework services.
            services.AddMvc();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory, DatabaseContext context)
        {
            loggerFactory.AddConsole(Configuration.GetSection("Logging"));
            loggerFactory.AddDebug();

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseBrowserLink();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
            }

            app.UseStaticFiles();

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Reservation}/{action=Index}/{id?}");
            });

            //Initializovani contextu pomoci DbInitializeru
            DbInitializer.Initialize(context);
        }

        /// <summary>
        /// Inicializace databaze
        /// </summary>
        public static class DbInitializer
        {
            public static void Initialize(DatabaseContext context)
            {
                context.Database.EnsureDeleted(); // SMAZAT potom az nebudu sahat do datoveho modelu
                context.Database.EnsureCreated();

                if (context.Rooms.Any())
                {
                    return;
                }

                string LoremIpsum = "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat. Duis aute irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla pariatur. Excepteur sint occaecat cupidatat non proident, sunt in culpa qui officia deserunt mollit anim id est laborum";
                //Vytvoreni jednotlivych mistnosti
                Room CreatedRoomChamber = new Room()
                {
                    Name = "Alchemist chamber",
                    //Description = new string('X', 205)
                    Description = LoremIpsum
                };
                Room CreatedRoomEternity = new Room()
                {
                    Name = "Path to Eternity",
                    //Description = new string('E', 205)
                    Description = LoremIpsum
                };
                Room CreatedRoomAncestors = new Room()
                {
                    Name = "Legacy of the Ancestors",
                    //Description = new string('A', 205)
                    Description = LoremIpsum
                };

                //Prirazeni nahodnych oteviracich hodin jednotlivym mistnostem
                Random FromTo = new Random();
                int TimeFromRandom = FromTo.Next(8, 12);
                CreatedRoomChamber.OpeningHours = string.Join(", ", Enumerable.Range(TimeFromRandom, 8));
                TimeFromRandom = FromTo.Next(8, 12);
                CreatedRoomAncestors.OpeningHours = string.Join(", ", Enumerable.Range(TimeFromRandom, 6));
                TimeFromRandom = FromTo.Next(8, 12);
                CreatedRoomEternity.OpeningHours = string.Join(", ", Enumerable.Range(TimeFromRandom, 7));

                //Pridani do contextu
                context.Rooms.Add(CreatedRoomChamber);
                context.Rooms.Add(CreatedRoomEternity);
                context.Rooms.Add(CreatedRoomAncestors);
                context.SaveChanges();

            }
        }
    }
}
