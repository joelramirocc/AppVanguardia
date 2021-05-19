﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FinancialApp.API.Models.Transaction
{
    public class TransactionCreateDTO
    {
        public long AccountId { get; set; }

        public double Amount { get; set; }

        public string Description { get; set; }

        public DateTime TransactionDate { get; set; }
    }
}
