using FinancialApp.Core;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace FinancialApp.Services.IServices
{
    public interface IAccountService
    {
        Task<ServiceResult<Data.Entities.Account>> GetCurrentMonthUserResumeAsync();
        
        Task<ServiceResult<IEnumerable<Data.Entities.Account>>> GetAllAccountsAsync();
    }
}
