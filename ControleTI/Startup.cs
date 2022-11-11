using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

using Microsoft.EntityFrameworkCore;
using ControleTI.Data;
using Microsoft.AspNetCore.Identity;
using ControleTI.Controllers;

namespace ControleTI
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

            services.AddIdentity<IdentityUser, IdentityRole>()
                .AddEntityFrameworkStores<ControleTIContext>()
                .AddDefaultTokenProviders();

            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);

            services.AddDbContext<ControleTIContext>(options => 
                options.UseMySql(Configuration.GetConnectionString("ControleTIContext"), builder => 
                    builder.MigrationsAssembly("ControleTI")));

            services.AddScoped<ControleTI.Services.SetorService>();
            services.AddScoped<ControleTI.Services.UsuarioService>();
            services.AddTransient<ControleTI.Services.SerialKeyService>();
            services.AddTransient<ControleTI.Services.SoftwareService>();
            services.AddTransient<ControleTI.Services.DispositivoService>();
            services.AddTransient<ControleTI.Services.TipoDispositivoService>();
            services.AddTransient<ControleTI.Services.DispositivoSoftwareService>();
            services.AddTransient<ControleTI.Services.StatusService>();
            services.AddTransient<ControleTI.Services.EmpresaParceiraService>();
            services.AddTransient<ControleTI.Services.ContratoService>();
            services.AddScoped<SeedingService>();


            services.Configure<IdentityOptions>(options =>
            {
                // Default Password settings.
                options.Password.RequireDigit = false;
                options.Password.RequireLowercase = false;
                options.Password.RequireNonAlphanumeric = false;
                options.Password.RequireUppercase = false;
                options.Password.RequiredLength = 3;
                options.Password.RequiredUniqueChars = 0;
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, SeedingService seedingService)
        {
            app.UseForwardedHeaders(new ForwardedHeadersOptions
            {
                ForwardedHeaders = Microsoft.AspNetCore.HttpOverrides.ForwardedHeaders.XForwardedFor |
               Microsoft.AspNetCore.HttpOverrides.ForwardedHeaders.XForwardedProto
            });

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
               // seedingService.Seed();
               
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                app.UseHsts();
            }


            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseCookiePolicy();
            app.UseHttpsRedirection();
            app.UseAuthentication();
            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");
            });
        }


    }
}
