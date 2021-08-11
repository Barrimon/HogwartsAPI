using HogwartsAPI.Services;
using HogwartsCore.Extensions;
using HogwartsCore.Models;
using HogwartsCore.Services;
using HogwartsInfrastructure.Data;
using HogwartsInfrastructure.Data.Seeder;
using HogwartsInfrastructure.Extensions;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System.Reflection;
using Newtonsoft.Json;

namespace HogwartsAPI
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            string migrationAssembly = typeof(Startup).GetTypeInfo().Assembly.GetName().Name;

            services.AddControllers();
            services.InitializerSwagger();

            services.AddDbContext<HogwartsContext>(options =>
              options.UseSqlServer(Configuration.GetConnectionString("HogwartsConnectionString"), opt =>
              {
                  opt.MigrationsAssembly(migrationAssembly);
              }));

            services.Configure<PathData>(Configuration.GetSection("PathData"));

            //IoC
            services.InitializerInfrastructure();
            services.InitializerCore();

            services.AddMvc(option => option.EnableEndpointRouting = false)
             .AddNewtonsoftJson(opt => opt.SerializerSettings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, ISeeder seeder)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                seeder.SeedPopulate().GetAwaiter().GetResult();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints => { endpoints.MapControllers(); });

            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "Hogwarts API v1");
                c.InjectStylesheet("/swagger/custom.css");
            });
        }
    }
}
