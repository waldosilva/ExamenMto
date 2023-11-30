using System;
using System.Threading.Tasks;

namespace CarlosMto.Infrastructure
{
    public interface IUnitOfWork
    {
        Task<int> SaveChangeAsync();
        Task<TResult> ExecuteTransactionAsync<TResult>(Func<Task<TResult>> func);
    }
    //  public interface IUnitOfWork<T> where T : class
    //  {   
    //      Task<int> SaveChangeAsync();   
    //Task<TResult> ExecuteTransactionAsync<TResult>(Func<Task<TResult>> func);
    //  }  
}