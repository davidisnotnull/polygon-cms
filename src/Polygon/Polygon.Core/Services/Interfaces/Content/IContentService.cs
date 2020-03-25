using Polygon.Core.Data.Entities;

namespace Polygon.Core.Services.Interfaces.Content
{
    /// <summary>
    /// This is a wrapper for the various content services. This is the one that should
    /// be called from outside of the Core project if you need to access content.
    /// </summary>
    public interface IContentService<TContent> where TContent : BaseEntity
    {
        dynamic Get(string guid);
    }
}