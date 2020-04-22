using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Routing;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Polygon.Core.Data;
using Polygon.Core.Data.Context;
using Polygon.Core.Data.Interfaces;
using Polygon.Core.Services.Content;
using Polygon.Core.Services.Interfaces.Content;
using Polygon.Core.Services.Interfaces.MetaData;
using Polygon.Core.Services.Interfaces.Tesseract;
using Polygon.Core.Services.MetaData;
using Polygon.Core.Services.Tesseract;

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
            services.AddRazorPages()
                .AddRazorRuntimeCompilation();

            services.AddControllers();

            services.Configure<RouteOptions>(options =>
            {
                options.LowercaseUrls = true;
                options.LowercaseQueryStrings = true;
                options.AppendTrailingSlash = true;
            });

            services.AddRouting();

            services.AddDbContext<PolygonContext>(options =>
            {
                options.UseSqlServer(Configuration.GetConnectionString("PolygonDb"));
                //Uncomment this for testing with an in memory database
                //options.UseInMemoryDatabase(Guid.NewGuid().ToString());
                options.EnableSensitiveDataLogging();
            });

            services.AddScoped<IPolygonContext, PolygonContext>();
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped<INavigationService, NavigationService>();
            services.AddScoped<IReferenceDataService, ReferenceDataService>();
            services.AddScoped<ITaxonomyService, TaxonomyService>();
            services.AddScoped<IOpenGraphService, OpenGraphService>();
            services.AddScoped(typeof(IContentService<>), typeof(ContentService<>));
            
            // Tesseract Services
            services.AddScoped<ITableService, TableService>();
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

            using (var serviceScope = app.ApplicationServices.GetService<IServiceScopeFactory>().CreateScope())
            {
                var context = serviceScope.ServiceProvider.GetRequiredService<PolygonContext>();
                context.Database.EnsureCreated();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapRazorPages();
                endpoints.MapControllers();
            });

        }
    }
}
