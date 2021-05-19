using FinancialApp.API.Models.Account;
using FinancialApp.Services.IServices;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FinancialApp.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountsController : ControllerBase
    {
        private readonly IAccountService accountService;

        public AccountsController(IAccountService accountService)
        {
            this.accountService = accountService;
        }

        [HttpGet()]
        public async Task<IActionResult> GetAsync()
        {
            var accounts = await this.accountService.GetAllAccountsAsync();
            if (accounts.ResponseCode != Core.ResponseCode.Success)
            {
                return this.BadRequest(accounts.Error);
            }

            return this.Ok(accounts.Result.Select(d => new AccountDTO 
            {
                Amount = d.Amount,
                Name = d.Name,
                CurrencySimbol = d.Currency
            }));
        }
    }
}
