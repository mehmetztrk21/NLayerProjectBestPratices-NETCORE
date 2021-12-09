using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using NLayerProjectBestPratices.Core.Repositories;
using NLayerProjectBestPratices.Core.Services;
using NLayerProjectBestPratices.Core.UnitOfWorks;
using NLayerProjectBestPratices.Data;
using NLayerProjectBestPratices.Data.Repositories;
using NLayerProjectBestPratices.Data.UnitOfWorks;
using NLayerProjectBestPratices.Service.Services;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using NLayerProjectBestPratices.API.Filters;
using Microsoft.AspNetCore.Diagnostics;
using NLayerProjectBestPratices.API.DTOs;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using NLayerProjectBestPratices.API.Extensions;

namespace NLayerProjectBestPratices.API
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }
        readonly string ApiCorsPolicy = "_apiCorsPolicy";  //javascript ile ulaþmak için kendim ekledim.

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddCors(options => options.AddPolicy(ApiCorsPolicy, builder => {  //javascript ile ulaþmak için kendim ekledim.
                builder.WithOrigins("http://localhost:44398", "http://www.example.com").AllowAnyOrigin();
//.AllowAnyMethod()
//.AllowAnyHeader()
//.AllowCredentials();
            }));
            services.AddAutoMapper(typeof(Startup));
            services.AddScoped<NotFoundFilter>();  // notfoundfilter sýnýfýmýzda bir constructor ve aldýðý bir deðer olduðu için burda tanýmlamak lazým.

            services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));
            services.AddScoped(typeof(IGenericService<>), typeof(GenericService<>));  //genericse böyle oluyor.
            services.AddScoped<IProductService, ProductService>();
            services.AddScoped<ICategoryService, CategoryService>();
            services.AddScoped<IUnitOfWork, UnitOfWork>();


            services.AddDbContext<AppDbContext>(options =>
            {
                options.UseSqlServer(Configuration["ConnectionStrings:SqlConStr"].ToString(), o =>
                 {
                     o.MigrationsAssembly("NLayerProjectBestPratices.Data");
                 });

            });
             services.AddControllers();
            /*
            //eðer oluþturduðun herhangi bir filtreyi global düzeyde kullanmak istiyorsan buraya eklemen lazým. Eðer sýnýf bazlý istiyorsan sýnýfta en üstte tanýmla authorize yaptýðýn gibi. Eðer fonksiyonla istiyorsan zaten productta yaptýn fonksiyonun hemen üstüne yazýyorsun.
            services.AddControllers(o =>
            {
                o.Filters.Add(new ValidationFilter());
            });

            */

            //bu kod parçasý ile diyoruz ki hata mesajlarýný biz kendimiz vereceðiz sen karýþma.
            services.Configure<ApiBehaviorOptions>(options =>
            {
                options.SuppressModelStateInvalidFilter = true;

            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {



            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }


            app.UseCors(ApiCorsPolicy);  //javascript ile ulaþmak için kendim ekledim.

            app.UseCustomException();    //Extensions kalsörüne hatalarý global düzeyde ele almak için yazdýðýmýz kodlarý burda çaðýrýyoruz.

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
