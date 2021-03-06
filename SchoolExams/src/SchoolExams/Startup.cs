﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json.Serialization;
using SchoolExams.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Authentication.Cookies;
using AutoMapper;
using SchoolExams.ViewModels;
using Newtonsoft.Json;

namespace SchoolExams
{
    public class Startup
    {
        private IHostingEnvironment _env;
        private IConfigurationRoot _config;

        public Startup(IHostingEnvironment env)
        {
            _env = env;

            var builder = new ConfigurationBuilder()
                .SetBasePath(_env.ContentRootPath)
                .AddJsonFile("config.json")
                .AddEnvironmentVariables();

            _config = builder.Build();
        }
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit http://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddSingleton(_config);
            services.AddDbContext<SchoolsContext>();

            services.AddIdentity<SchoolUser, IdentityRole>(config =>
            {
                config.User.RequireUniqueEmail = true;
                config.Cookies.ApplicationCookie.LoginPath = "/auth/login";
                config.Cookies.ApplicationCookie.Events = new CookieAuthenticationEvents()
                {
                    OnRedirectToLogin = async ctx =>
                    {
                        if (ctx.Request.Path.StartsWithSegments("/api") &&
                          ctx.Response.StatusCode == 200)
                        {
                            ctx.Response.StatusCode = 401;
                        }
                        else
                        {
                            ctx.Response.Redirect(ctx.RedirectUri);
                        }
                        await Task.Yield();
                    }
                };
            })
            .AddEntityFrameworkStores<SchoolsContext>();

            services.AddScoped<ISchoolsRepository, SchoolsRepository>();

            services.AddLogging();

            services.AddTransient<SchoolsContextSeedData>();

            services.AddMvc()
                .AddJsonOptions(opt =>
                {
                    opt.SerializerSettings.ReferenceLoopHandling =
                      ReferenceLoopHandling.Ignore;
                })
                .AddJsonOptions(config =>
                                    {

                                        config.SerializerSettings.ContractResolver = new CamelCasePropertyNamesContractResolver();
                                    });
        }


        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app,
            IHostingEnvironment env, 
            ILoggerFactory loggerFactory,
            SchoolsContextSeedData seeder)
        {
            Mapper.Initialize(config =>
            {
                config.CreateMap<SchoolViewModel, School>().ReverseMap();
                config.CreateMap<SubjectViewModel, Subject>().ReverseMap();
                config.CreateMap<QuestionaryViewModel, Questionary>().ReverseMap();
                config.CreateMap<ExamViewModel, Exam>().ReverseMap();
                config.CreateMap<CityViewModel, City>().ReverseMap();
            });

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                loggerFactory.AddDebug();
            }


            app.UseStaticFiles();
            app.UseIdentity();

            app.UseMvc(config =>
            {
                config.MapRoute(
                    name: "defaults",
                    template: "{controller}/{action}/{id?}",
                    defaults: new { controller = "Home", action = "Index" }

                    );
            });

            seeder.EnsureSeedData().Wait();

        }
    }
}
