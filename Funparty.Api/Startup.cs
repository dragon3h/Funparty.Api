using Funparty.Api.Application.Interfaces;
using Funparty.Api.Persistence;
using Funparty.Api.Persistence.Repositories;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace Funparty.Api
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        private readonly string FunpartyAllowSpecificOrigins = "_funpartyAllowSpecificOrigins";

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddScoped<IMascotRepository, MascotRepository>();
            
            services.AddDbContext<FunpartyDbContext>(opt =>
                opt.UseSqlServer(Configuration.GetConnectionString("DefaultWin")));
            services.AddControllers();
            
            // add CORS
            services.AddCors(options =>
            {
                options.AddPolicy(FunpartyAllowSpecificOrigins,
                    builder => { builder.AllowAnyOrigin(); });
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseCors(FunpartyAllowSpecificOrigins);
            
            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints => { endpoints.MapControllers(); });
        }
    }
}