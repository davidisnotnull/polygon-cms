using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Polygon.Core.Data.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Polygon.Core.Data.Initializers
{
    public class ApplicationInitializer
    {
        public static async Task InitializeDatabaseContextAsync(IServiceProvider serviceProvider)
        {
            using (var serviceScope = serviceProvider.CreateScope())
            {
                var scopeServiceProvider = serviceScope.ServiceProvider;
                var db = scopeServiceProvider.GetService<PolygonContext>();
                if (await db.Database.EnsureCreatedAsync())
                {
                    // INSERT SEED TASKS HERE
                }
            }
        }

        /// <summary>
        /// Add or update a single entity
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="serviceProvider"></param>
        /// <param name="propertyToWatch"></param>
        /// <param name="entity"></param>
        /// <returns></returns>
        private static async Task AddOrUpdateAsync<T>(
            IServiceProvider serviceProvider,
            Func<T, object> propertyToWatch,
            T entity)
            where T : class
        {
            List<T> existingData;

            using (var serviceScope = serviceProvider.GetRequiredService<IServiceScopeFactory>().CreateScope())
            {
                var db = serviceScope.ServiceProvider.GetService<PolygonContext>();
                existingData = db.Set<T>().ToList();
            }

            using (var serviceScope = serviceProvider.GetRequiredService<IServiceScopeFactory>().CreateScope())
            {
                var db = serviceScope.ServiceProvider.GetService<PolygonContext>();

                db.Entry(entity).State = existingData.Any(g => propertyToWatch(g).Equals(propertyToWatch(entity)))
                    ? EntityState.Modified
                    : EntityState.Added;

                await db.SaveChangesAsync();
            }
        }

        /// <summary>
        /// Add or Update an array of entities
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="serviceProvider"></param>
        /// <param name="propertyToMatch"></param>
        /// <param name="entities"></param>
        /// <returns></returns>
        private static async Task AddOrUpdateAsync<T>(
            IServiceProvider serviceProvider,
            Func<T, object> propertyToMatch,
            IEnumerable<T> entities)
            where T : class
        {
            List<T> existingData;

            using (var serviceScope = serviceProvider.GetRequiredService<IServiceScopeFactory>().CreateScope())
            {
                var db = serviceScope.ServiceProvider.GetService<PolygonContext>();
                existingData = db.Set<T>().ToList();
            }

            using (var serviceScope = serviceProvider.GetRequiredService<IServiceScopeFactory>().CreateScope())
            {
                var db = serviceScope.ServiceProvider.GetService<PolygonContext>();
                foreach (var item in entities)
                {
                    db.Entry(item).State = existingData.Any(g => propertyToMatch(g).Equals(propertyToMatch(item)))
                        ? EntityState.Modified
                        : EntityState.Added;
                }

                await db.SaveChangesAsync();
            }
        }

    }
}
