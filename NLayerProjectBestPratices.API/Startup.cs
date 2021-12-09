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
        readonly string ApiCorsPolicy = "_apiCorsPolicy";  //javascript ile ula�mak i�in kendim ekledim.

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddCors(options => options.AddPolicy(ApiCorsPolicy, builder => {  //javascript ile ula�mak i�in kendim ekledim.
                builder.WithOrigins("http://localhost:44398", "http://www.example.com").AllowAnyOrigin();
//.AllowAnyMethod()
//.AllowAnyHeader()
//.AllowCredentials();
            }));
            services.AddAutoMapper(typeof(Startup));
            services.AddScoped<NotFoundFilter>();  // notfoundfilter s�n�f�m�zda bir constructor ve ald��� bir de�er oldu�u i�in burda tan�mlamak laz�m.

            services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));
            services.AddScoped(typeof(IGenericService<>), typeof(GenericService<>));  //genericse b�yle oluyor.
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
            //e�er olu�turdu�un herhangi bir filtreyi global d�zeyde kullanmak istiyorsan buraya eklemen laz�m. E�er s�n�f bazl� istiyorsan s�n�fta en �stte tan�mla authorize yapt���n gibi. E�er fonksiyonla istiyorsan zaten productta yapt�n fonksiyonun hemen �st�ne yaz�yorsun.
            services.AddControllers(o =>
            {
                o.Filters.Add(new ValidationFilter());
            });

            */

            //bu kod par�as� ile diyoruz ki hata mesajlar�n� biz kendimiz verece�iz sen kar��ma.
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


            app.UseCors(ApiCorsPolicy);  //javascript ile ula�mak i�in kendim ekledim.

            app.UseCustomException();    //Extensions kals�r�ne hatalar� global d�zeyde ele almak i�in yazd���m�z kodlar� burda �a��r�yoruz.

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
