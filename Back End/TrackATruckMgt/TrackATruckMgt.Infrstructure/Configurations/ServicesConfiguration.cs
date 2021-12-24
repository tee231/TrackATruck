
using TrackATruckMgt.Core.Managers;

using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using TrackATruckMgt.Core.Interfaces.Managers;
using TrackATruckMgt.Core.Interfaces.Repositories;
using TrackATruckMgt.Infrstructure.Implementations.Repositories;

namespace TrackATruckMgt.Infrstructure.Configurations
{
    public static  class ServicesConfiguration
    {

        public static void AppServicesConfiguration(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddHttpClient("http", c => { })
                .ConfigurePrimaryHttpMessageHandler(h =>
                {

                    var handler = new HttpClientHandler();
                    handler.ServerCertificateCustomValidationCallback = delegate { return true; };
                    return handler;
                });

            

            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();

                       //Repositories
            services.AddScoped<IDriverRepository, DriverRepository>();
            services.AddScoped<ITruckRepository, TruckRepository>();
            services.AddScoped<IPositionRepository, PositionRepository>();
            services.AddScoped<IUserRepository, UserRepository>();
            // Managers Injections
            services.AddScoped<IPositionManager, PositionManager>();
            services.AddScoped<IDriverManager, DriverManager>();
            services.AddScoped<ITruckManager, TruckManager>();
           // services.AddScoped<>



        }
        }
    }
