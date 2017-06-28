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
            ViewData["Message"] = "Your budget manager page.";
            var budgetRepository = new BudgetRepository();
            var budget = budgetRepository.GetBudget();

            return View(budget);
        }

        [HttpPost]
        public ActionResult DeleteExpense(string id)
        {
            var budgetRepository = new BudgetRepository();
            budgetRepository.DeleteBudgetItem(Convert.ToInt32(id));

            return RedirectToAction("Index");
        }

        [HttpPost]
        public ActionResult Index(ExpenseManagingViewModel item)
        {
            if (ModelState.IsValid)
            {
                var budgetRepository = new BudgetRepository();

                budgetRepository.AddBudgetItem(item.BudgetItem);
            }
            return RedirectToAction("Index");
        }
        public ActionResult EditBudgetItem(int id)
        {
            var budgetRepository = new BudgetRepository();
            var budgetItem = budgetRepository.FindBudgetItem(id);
            var viewModel = new ExpenseManagingViewModel(budgetItem);
            return View(viewModel);
        }
        [HttpPost]
        [ActionName("EditBudgetItem")]
        [ValidateAntiForgeryToken]
        public ActionResult EditBudgetItem(ExpenseManagingViewModel item)
        {
            if (ModelState.IsValid)
            {
                var budgetRepository = new BudgetRepository();
                budgetRepository.EditBudgetItem(item.BudgetItem);
                return RedirectToAction("Index");
            }
            return View(item);
        }
    }

}