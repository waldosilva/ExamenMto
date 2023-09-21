using System;
using System.Threading.Tasks;

namespace UmvelTest.Infrastructure
{
    public interface IUnitOfWork    
    {   
        Task<int> SaveChangeAsync();   
		Task<TResult> ExecuteTransactionAsync<TResult>(Func<Task<TResult>> func);
    }  
}