using System;

namespace Kruchy.Model.DataTypes.Database
{
    public class UsingUnitOfWork : IDisposable
    {
        private readonly IUnitOfWork unitOfWork;
        private bool canceled;

        public UsingUnitOfWork(
            IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
            this.unitOfWork.Start();
        }

        public void Cancel()
        {
            canceled = true;
        }

        public void Dispose()
        {
            if (canceled)
                unitOfWork.Rollback();
            else
                unitOfWork.Finish();
        }
    }
}