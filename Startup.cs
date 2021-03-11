using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Hangfire;
using Hangfire.PostgreSql;

namespace HangPlayGround
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

            services.AddDbContext<Models.DefaultDbContext>(options => 
            {                
                options.UseNpgsql(Configuration.GetSection("DatabaseConfig")["PostgresSQL"]);
            });
            // Configuração do HangFire
            services.AddHangfire(x =>
                x.UsePostgreSqlStorage(Configuration.GetConnectionString("DefaultConnection")));


            services.AddSingleton<HangPlayGround.Services.IUserService, HangPlayGround.Services.UserService>();

            services.AddControllers();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            // Configuração do HangFire
            app.UseHangfireDashboard(); //Will be available under http://localhost:5000/hangfire"
            app.UseHangfireServer();
            

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
