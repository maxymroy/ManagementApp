using ManagementApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ManagementApp.ViewModels
{
    public class BudgetViewModel
    {
        public ExpenseGridViewModel Budget { get; set; }

        public BudgetViewModel()
        {
            Budget = new ExpenseGridViewModel();
        }
    }
}