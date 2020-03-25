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
        IEnumerable<ReferenceCollection> GetAllReferenceCollections();

        /// <summary>
        /// Get a specified Reference Type by Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        ReferenceCollection GetReferenceCollection(Guid id);

        /// <summary>
        /// Get a list of Reference Objects by a specified Reference Type
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        IEnumerable<ReferenceItem> GetReferenceItemsByCollection(Guid id);

        /// <summary>
        /// Get a list of Reference Objects by a specified Reference Type
        /// </summary>
        /// <param name="referenceType"></param>
        /// <returns></returns>
        IEnumerable<ReferenceItem> GetReferenceItemsByCollection(ReferenceCollection referenceType);

        /// <summary>
        /// Get a specified Reference Object
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        ReferenceItem GetReferenceItem(Guid id);

        /// <summary>
        /// Create a new Reference Type
        /// </summary>
        /// <param name="referenceType"></param>
        /// <returns></returns>
        ReferenceCollection CreateReferenceCollection(ReferenceCollection referenceType);

        /// <summary>
        /// Update a specified Reference Type
        /// </summary>
        /// <param name="referenceType"></param>
        /// <returns></returns>
        ReferenceCollection UpdateReferenceCollection(ReferenceCollection referenceType);

        /// <summary>
        /// Create a new Reference Object
        /// </summary>
        /// <param name="referenceObject"></param>
        /// <returns></returns>
        ReferenceItem CreateReferenceItem(ReferenceItem referenceObject);

        /// <summary>
        /// Update a specified Reference Object
        /// </summary>
        /// <param name="referenceObject"></param>
        /// <returns></returns>
        ReferenceItem UpdateReferenceItem(ReferenceItem referenceObject);

        /// <summary>
        /// Delete a specified Reference Object
        /// </summary>
        /// <param name="referenceObject"></param>
        int DeleteReferenceItem(ReferenceItem referenceObject);

        /// <summary>
        /// Delete a specified Reference Object
        /// </summary>
        /// <param name="id"></param>
        int DeleteReferenceItem(Guid id);
    }
}
