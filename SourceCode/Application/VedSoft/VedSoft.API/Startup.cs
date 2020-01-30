using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
//using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Swashbuckle.AspNetCore.Swagger;
using VedSoft.Logger;
using VedSoft.API.Core;
using VedSoft.Data.Contracts.Wrapper;
using VedSoft.Data.Repository;
using VedSoft.Logger;
using Newtonsoft.Json.Serialization;

namespace VedSoft.API
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
            services.ConfigureCors();
            services.AddMvc();
        //.AddJsonOptions(options => options.SerializerSettings.ContractResolver = new DefaultContractResolver());
            services.ConfigureSwagger();
            services.ConfigureMySqlContext(Configuration);
            //services.ConfigureRepositoryWrapper();
            services.ConfigureDependencyInjection();
            services.ConfigureJWTToken();
            //services.AddSingleton<IConfiguration>(Configuration);
            services.ConfigureAppSettings(Configuration);

            //VedSoft.API.Util.ConfigKey.Config = Configuration;
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseAuthentication();
            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "VedSoft API V1");
            });
            app.UseMvc();
            loggerFactory.AddLog4Net(); // << Add this line

        }
    }
}
