﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using ApiCore1.Model;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

namespace ApiCore1
{
    public class Startup
    {
        readonly IHostingEnvironment HostingEnvironment;


        public Startup(IHostingEnvironment env)
        {
            HostingEnvironment = env;
        }

        //IConfigurationRoot Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<IngredientsContext>(builder =>
            {
                // string useSqLite = Configuration["Data:useSqLite"];
                // if (useSqLite != "true")
                // {
                //     var connStr = Configuration["Data:SqlServerConnectionString"];
                //     builder.UseSqlServer(connStr);
                // }
                // else
                // {
                    // Note this path has to have full  access for the Web user in order 
                    // to create the DB and write to it.
                    var connStr = "Data Source=" +
                                  Path.Combine(HostingEnvironment.ContentRootPath, "IngredientsData.sqlite");
                    builder.UseSqlite(connStr);
                //}

                
            });
            services.AddMvc();
            
            // Also make top level configuration available (for EF configuration and access to connection string)
            //services.AddSingleton<IConfigurationRoot>(Configuration);
            //services.AddSingleton<IConfiguration>(Configuration);

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseMvc();

            
        }
    }
}