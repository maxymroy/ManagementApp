using ManagementApp.Models;
using ManagementApp.Repositories;
using ManagementApp.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ManagementApp.Controllers
{
    public class BudgetController : Controller
    {
        // GET: Budget
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult ExpenseManager()
        {
            ViewData["Message"] = "Your expense manager page.";
            var expenseRepository = new ExpenseRepository();
            var expenses = expenseRepository.GetExpenses();

            return View(expenses);
        }

        [HttpPost]
        public ActionResult ExpenseManager(ExpenseManagingViewModel item)
        {
            if (ModelState.IsValid)
            {
                var expenseRepository = new ExpenseRepository();

                expenseRepository.AddExpense(item.ExpenseItem);
            }
            return RedirectToAction("ExpenseManager");
        }

        [HttpPost]
        public ActionResult DeleteExpense(string id)
        {
            var expenseRepository = new ExpenseRepository();
            expenseRepository.DeleteExpense(Convert.ToInt32(id));

            return RedirectToAction("ExpenseManager");
        }


        public ActionResult EditExpense(int id)
        {
            var expenseRepository = new ExpenseRepository();
            var expenseItem = expenseRepository.FindExpense(id);
            var viewModel = new ExpenseManagingViewModel(expenseItem);
            return View(viewModel);
        }
        [HttpPost]
        [ActionName("EditExpense")]
        [ValidateAntiForgeryToken]
        public ActionResult EditExpense(ExpenseManagingViewModel item)
        {
            if (ModelState.IsValid)
            {
                var expenseRepository = new ExpenseRepository();
                expenseRepository.EditExpense(item.ExpenseItem);
                return RedirectToAction("ExpenseManager");
            }
            return View(item);
        }


        public ActionResult IncomeManager()
        {
            return View();
        }
    }

}