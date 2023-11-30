
using CarlosMto.Infrastructure;

namespace CarlosMto.Application
{
    public abstract class BaseService
    {
        protected readonly IUnitOfWork UnitOfWork;

        protected BaseService(IUnitOfWork unitOfWork)
        {
            UnitOfWork = unitOfWork;
        }
    }

    //public abstract class BaseService<T> where T : class
    //{
    //    protected readonly IUnitOfWork<T> UnitOfWork;

    //    protected BaseService(IUnitOfWork<T> unitOfWork)
    //    {
    //        UnitOfWork = unitOfWork;
    //    }
    //}
}