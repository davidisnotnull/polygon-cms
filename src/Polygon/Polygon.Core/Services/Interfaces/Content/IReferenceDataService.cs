using Polygon.Core.Data.Entities.ReferenceData;
using System;
using System.Collections.Generic;

namespace Polygon.Core.Services.Interfaces.Content
{
    public interface IReferenceDataService
    {
        /// <summary>
        /// Returns all Reference Types
        /// </summary>
        /// <returns></returns>
        IEnumerable<ReferenceType> GetAllReferenceTypes();

        /// <summary>
        /// Get a specified Reference Type by Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        ReferenceType GetReferenceType(Guid id);

        /// <summary>
        /// Get a list of Reference Objects by a specified Reference Type
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        IEnumerable<ReferenceObject> GetReferenceObjectsByType(Guid id);

        /// <summary>
        /// Get a list of Reference Objects by a specified Reference Type
        /// </summary>
        /// <param name="referenceType"></param>
        /// <returns></returns>
        IEnumerable<ReferenceObject> GetReferenceObjectsByType(ReferenceType referenceType);

        /// <summary>
        /// Get a specified Reference Object
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        ReferenceObject GetReferenceObject(Guid id);

        /// <summary>
        /// Create a new Reference Type
        /// </summary>
        /// <param name="referenceType"></param>
        /// <returns></returns>
        ReferenceType CreateReferenceType(ReferenceType referenceType);

        /// <summary>
        /// Update a specified Reference Type
        /// </summary>
        /// <param name="referenceType"></param>
        /// <returns></returns>
        ReferenceType UpdateReferenceType(ReferenceType referenceType);

        /// <summary>
        /// Create a new Reference Object
        /// </summary>
        /// <param name="referenceObject"></param>
        /// <returns></returns>
        ReferenceObject CreateReferenceObject(ReferenceObject referenceObject);

        /// <summary>
        /// Update a specified Reference Object
        /// </summary>
        /// <param name="referenceObject"></param>
        /// <returns></returns>
        ReferenceObject UpdateReferenceObject(ReferenceObject referenceObject);

        /// <summary>
        /// Delete a specified Reference Object
        /// </summary>
        /// <param name="referenceObject"></param>
        int DeleteReferenceObject(ReferenceObject referenceObject);

        /// <summary>
        /// Delete a specified Reference Object
        /// </summary>
        /// <param name="id"></param>
        int DeleteReferenceObject(Guid id);
    }
}
