using Polygon.Core.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace Polygon.Core.Data.Interfaces.Repositories
{
    public interface IRepository<T> where T : BaseEntity
    {
        /// <summary>
        /// Gets an entity by it's Id
        /// </summary>
        /// <param name="id">Int Id of entity</param>
        /// <returns>Entity</returns>
        T GetById(Guid id);

        /// <summary>
        /// Gets an entity by it's Id, including a soft delete check.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        T GetAvailableById(Guid id);

        /// <summary>
        /// Gets a list of all entities of a specific type, regardless of whether they have been
        /// soft deleted or not
        /// </summary>
        /// <returns>Enumerated list of entities</returns>
        IEnumerable<T> GetAll();

        /// <summary>
        /// Gets a list of all entities of a specified type if they have not been soft deleted
        /// </summary>
        /// <returns>Enumerated list of entities</returns>
        IEnumerable<T> GetAvailable();

        /// <summary>
        /// Gets a collection of objects based upon a provided expression
        /// </summary>
        /// <param name="whereClause"></param>
        /// <returns></returns>
        IEnumerable<T> Get(Expression<Func<T, bool>> whereClause);

        /// <summary>
        /// Checks to see if an object exists based upon a provided expression
        /// </summary>
        /// <param name="whereClause"></param>
        /// <returns></returns>
        bool Exists(Expression<Func<T, bool>> whereClause);

        /// <summary>
        /// Creates a new entity
        /// </summary>
        /// <param name="entity">Populated entity</param>
        T Add(T entity);

        /// <summary>
        /// Batch creates a list of entities
        /// </summary>
        /// <param name="entities">Enumerated list of entities</param>
        /// <remarks>
        /// This, with it's <c>Insert(T entity)</c> counterpart, is an example of parametric polymorphism, i.e.
        /// two methods with the same name in the same class that have differing method signatures
        /// </remarks>
        IEnumerable<T> Add(IEnumerable<T> entities);

        /// <summary>
        /// Updates a specific entity
        /// </summary>
        /// <param name="entityToUpdate">Entity to update</param>
        T Update(T entityToUpdate);

        /// <summary>
        /// Deletes a specific entity
        /// </summary>
        /// <param name="entityToDelete">Entity to delete</param>
        void Delete(T entityToDelete);

        /// <summary>
        /// Deletes a specific entity based on it's Id
        /// </summary>
        /// <param name="id">Int Id of entity</param>
        void Delete(Guid id);

        /// <summary>
        /// Soft deletes a specific entity
        /// </summary>
        /// <param name="entity">Entity to soft delete</param>
        void SoftDelete(T entity);

        /// <summary>
        /// Soft deletes an entity by it's Id
        /// </summary>
        /// <param name="id">Guid of entity</param>
        void SoftDelete(Guid id);
    }
}
