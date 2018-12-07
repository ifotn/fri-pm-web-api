﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using fri_pm_api.Models;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

// swagger doc references
using NSwag.AspNetCore;
using NJsonSchema;
using System.Reflection;

namespace fri_pm_api
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
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);

            // db connection options
            string db = Configuration.GetConnectionString("DefaultConnection");
            services.AddDbContext<MusicStoreModel>(options => options.UseSqlServer(db));

            // swagger config
            services.AddSwaggerDocument(configure =>
            {
                configure.PostProcess = document =>
                {
                    document.Info.Version = "v1.1";
                    document.Info.Title = "MVC Music Store API";
                    document.Info.Description = ".NET Core Web API";
                };
            });
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
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseMvc();

            // implement swagger
            app.UseSwagger();
            app.UseSwaggerUi3();
        }
    }
}
