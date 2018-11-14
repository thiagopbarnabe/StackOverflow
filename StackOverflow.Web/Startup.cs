using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using StackOverflow.Core.Contexts;
using StackOverflow.Core.Services;
using StackOverflow.Core.Services.Interfaces;

namespace StackOverflow.Web
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
            services.Configure<CookiePolicyOptions>(options =>
            {
                // This lambda determines whether user consent for non-essential cookies is needed for a given request.
                options.CheckConsentNeeded = context => true;
                options.MinimumSameSitePolicy = SameSiteMode.None;
            });

            var connection = @"Data Source=localhost;Initial Catalog=StackOverflow;Integrated Security=True";
            services.AddDbContext<StackOverflowContext>();// (options => options.UseSqlServer(connection));

            //services.AddTransient<IPerguntasServices, PerguntasServices>();
            //services.AddTransient<IRespostasServices, RespostasServices>();
            //services.AddTransient<IAutorService, AutorService>();

            services.AddMvc();

            services.AddAuthentication("app")
                    .AddCookie("app",
                        o =>
                        {
                            o.LoginPath = "/account/index";
                            o.AccessDeniedPath = "/account/denied";

                        });

            services.AddMemoryCache();

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
            }

            app.UseStaticFiles();
            

            app.UseAuthentication();

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Perguntas}/{action=Index}/{id?}");
            });
        }
    }
}
