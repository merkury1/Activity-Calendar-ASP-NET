using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using ToDoList.Core.Repositories;
using ToDoList.Infrastracture;
using ToDoList.Infrastracture.Repositories;

namespace ToDoList
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
            //services.AddSingleton<IActivityRepository, MockActivityRepository>();
            services.AddScoped<IActivityRepository, SQLActivityRepository>();
            services.AddMvc();
            services.AddDbContext<ToDoListDBContext>(options =>
            options.UseSqlServer(Configuration.GetConnectionString("ToDoListDb")));
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            app.UseDeveloperExceptionPage();
            app.UseStatusCodePages();
            app.UseStaticFiles();
            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Activity}/{action=Index}/{id?}"
                    );
            });
        }
    }
}
