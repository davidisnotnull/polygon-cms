using System;
using Polygon.Core.Data.Interfaces;

namespace Polygon.Core.Models.Content
{
    /// <summary>
    /// For capturing the generic ContentReference on a content item within the CMS
    /// </summary>
    public class ContentReference
    {
        private Guid _contentId;
        
        /// <summary>
        /// Initialise a new ContentReference
        /// </summary>
        public ContentReference()
        { }

        /// <summary>
        /// Initialise a new ContentReference with the content id
        /// </summary>
        /// <param name="guid">The guid of the content item</param>
        public ContentReference(string guid)
        {
            _contentId = Guid.Parse(guid);
        }
    }
}