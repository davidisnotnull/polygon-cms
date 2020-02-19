using Polygon.Core.Data.Interfaces;
using System;
using Microsoft.Extensions.Logging;

namespace Polygon.Core.Services
{
    public abstract class BaseService : IDisposable
    {
        protected readonly IUnitOfWork UnitOfWork;
        protected readonly ILogger Logger;

        protected BaseService(IUnitOfWork unitOfWork)
        {
            UnitOfWork = unitOfWork;
        }

        protected BaseService(IUnitOfWork unitOfWork, ILogger logger)
        {
            UnitOfWork = unitOfWork;
            Logger = logger;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (disposing)
                UnitOfWork?.Dispose();
        }

    }
}
