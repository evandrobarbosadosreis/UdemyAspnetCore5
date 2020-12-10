using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Cors.Infrastructure;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Rewrite;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using webapi.Business;
using webapi.Business.Interfaces;
using webapi.Data;
using webapi.Data.Interfaces;

namespace webapi
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        private void ConfigureCorsOptions(CorsOptions options)
        {
            options.AddDefaultPolicy(b => {
                b.AllowAnyHeader()
                 .AllowAnyMethod()
                 .AllowAnyOrigin();
            });
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddCors(ConfigureCorsOptions);
            services.AddControllers();
            services.AddScoped(typeof(IRepository<>), typeof(Repository<>));         
            services.AddScoped<IPessoaBusiness, PessoaBusiness>();
            services.AddScoped<ILivroBusiness, LivroBusiness>();
            services.AddDbContext<DataContext>(options => options.UseInMemoryDatabase("database"));
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "webapi", Version = "v1" });
            });
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            app.UseHttpsRedirection();
            app.UseRouting();
            app.UseCors(); // A grande sacada é que a config. do cors tem local correto pra ficar
            app.UseSwagger();
            app.UseSwaggerUI(c => c.SwaggerEndpoint("../swagger/v1/swagger.json", "webapi v1"));
            app.UseRewriter(new RewriteOptions().AddRedirect("^$", "swagger"));
            app.UseAuthorization();
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
