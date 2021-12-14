using AspNetCoreRateLimit;

using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using TrackATruckMgt.Infrstructure.Configurations;
using TrackATruckMgt.Infrstructure.Filters;

namespace TrackATruckMgt.API
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

            // needed to load configuration from appsettings.json 
            services.AddOptions();

            // needed to store rate limit counters and ip rules
            services.AddMemoryCache();

            //load general configuration from appsettings.json
         //   services.Configure(Configuration.GetSection("IpRateLimiting"));
            services.Configure<IpRateLimitOptions>(Configuration.GetSection("IpRateLimiting"));
            // inject counter and rules stores
            services.AddInMemoryRateLimiting();

            // configuration (resolvers, counter key builders)
            services.AddSingleton<IRateLimitConfiguration, RateLimitConfiguration>();

            services.AddAutoMapper(typeof(Startup));


            services.AppServicesConfiguration(Configuration);
           

            services.AddDatabaseConfiguration(Configuration);
            
            services.AddControllers(config =>
            {
                config.Filters.Add<GlobalExceptionFilter>();
            })
               .AddJsonOptions(opt =>
               {
                   opt.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter());
                   opt.JsonSerializerOptions.IgnoreNullValues = true;
                   opt.JsonSerializerOptions.PropertyNamingPolicy = JsonNamingPolicy.CamelCase;
               });

          
            services.AddSwaggerGen(c =>
            {
                //c.SwaggerDoc("v1", new OpenApiInfo { Title = "Taiyelolu.TruckingMgt.API", Version = "v1" });
                c.SwaggerDoc("v1", new OpenApiInfo
                {
                    Version = "v1",
                    Title = "Taiwo's TruckingMgt API",
                    Description = "Taiwo Trucking Management service api",
                    Contact = new OpenApiContact
                    {
                        Email = "taiyelolu@info.com",
                        Name = "Taiyelolu",
                        Url = new Uri("http://taiyelolu.com")
                    }
                });


                var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
                var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
                c.IncludeXmlComments(xmlPath);
            });
         
            

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "Taiyelolu.TruckingMgt.API v1"));
            }
            app.UseIpRateLimiting();
            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();
            // global cors policy
            app.UseCors(x => x
                .AllowAnyMethod()
                .AllowAnyHeader()
                .SetIsOriginAllowed(origin => true) // allow any origin
                .AllowCredentials()); // allow credentials
            app.UseStaticFiles();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

        
        }
    }
}
