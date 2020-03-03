using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Routing;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using Polygon.Core.Data;
using Polygon.Core.Data.Context;
using Polygon.Core.Data.Interfaces;
using Polygon.Core.Services.Content;
using Polygon.Core.Services.Interfaces.Content;
using Polygon.Core.Services.Interfaces.MetaData;
using Polygon.Core.Services.MetaData;
using System;

namespace Polygon.CMS
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
            services.AddRazorPages();

            services.Configure<RouteOptions>(options =>
            {
                options.LowercaseUrls = true;
                options.LowercaseQueryStrings = true;
                options.AppendTrailingSlash = true;
            });

            services.AddRouting();

            services.AddDbContext<PolygonContext>(options =>
            {
                options.UseInMemoryDatabase(Guid.NewGuid().ToString());
                options.EnableSensitiveDataLogging();
            });

            services.AddScoped<IPolygonContext, PolygonContext>();
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped<INavigationService, NavigationService>();
            services.AddScoped<IReferenceDataService, ReferenceDataService>();
            services.AddScoped<ITaxonomyService, TaxonomyService>();
            services.AddScoped<IOpenGraphService, OpenGraphService>();

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo {Title = "Polygon OpenApi Documentation", Version = "v1"});
            });
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
                app.UseExceptionHandler("/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();
            
            app.UseSwagger();
            app.UseSwaggerUI(c => { c.SwaggerEndpoint("/swagger/v1/swagger.json", "Polygon OpenApi v1"); });

            app.UseRouting();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapRazorPages();
            });

        }
    }
}
