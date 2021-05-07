using ComputerisedAssingment.App.AutoMapper;
using ComputerisedAssingment.Interface;
using ComputerisedAssingment.ModelsEntity;
using ComputerisedAssingment.Service;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.FileProviders;
using Microsoft.Extensions.Hosting;
using System;
using System.IO;

namespace ComputerisedAssingment.App
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
            services.AddSingleton<IFileProvider>(
            new PhysicalFileProvider(
                Path.Combine(Directory.GetCurrentDirectory(), "wwwroot")));

            //ajax post token generate
            services.AddMvc(options =>
            {
                options.Filters.Add(new AutoValidateAntiforgeryTokenAttribute());
            });
            services.AddAntiforgery(options => options.HeaderName = "RequestVerificationToken");
            //ajax post token generate


            //DB migration
            services.AddDbContext<AppDBContext>(options =>
                options.UseSqlServer(Configuration.GetConnectionString("ComputerisedAssingmentDBConnection"),
                    b => b.MigrationsAssembly("ComputerisedAssingment.App")));
            //DB migration


            AppDBContext.ConnectionString = Configuration.GetConnectionString("ComputerisedAssingmentDBConnection");

            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            services.AddScoped<iUsersInterface, UsersService>();
            services.AddScoped<iAdminInterface, AdminService>();
            services.AddScoped<iStudentInterface, StudentService>();
            services.AddScoped<iTeacherInterface, TeacherService>();

            //auto mapper
            //https://www.simongilbert.net/automapper-csharp-aspnetcore-mvc-3-0/
            services.AddAutoMapper(c => c.AddProfile<AutoMapperProfile>(), typeof(Startup));
            //auto mapper

            //session added 
            services.AddDistributedMemoryCache();
            services.AddSession(options =>
            {
                options.Cookie.Name = "LoginCred";
                options.IdleTimeout = TimeSpan.FromMinutes(30);//You can set Time   
            });
            //session added


            services.AddControllersWithViews().AddRazorRuntimeCompilation();
            services.AddRazorPages().AddRazorRuntimeCompilation();

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
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

            app.UseSession();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Login}/{id?}");
            });
        }
    }
}
