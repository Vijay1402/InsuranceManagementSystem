using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using UI.Models;

namespace UI.Controllers
{
    public class PolicyController : Controller
    {
        private InsuranceDbContext dbContext; 

        public PolicyController()
        {
            dbContext = new InsuranceDbContext(); 
        }

        public ActionResult ShowAllPolicy()
        {
            var policies = dbContext.Policies.ToList();

            return View(policies);
        }


        public ActionResult AddPolicy()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AddPolicy(PolicyViewModel policyViewModel)
        {
            if (ModelState.IsValid)
            {
                
                Policy newPolicy = new Policy
                {
                    PolicyNumber = policyViewModel.PolicyNumber,
                    DateOfCreation = DateTime.Now,
                    Category = policyViewModel.Category,
                    PolicyType = policyViewModel.PolicyType,
                    Price = policyViewModel.Price
                };

                dbContext.Policies.Add(newPolicy);
                dbContext.SaveChanges();

                return RedirectToAction("AddPolicySuccess");
            }

            return View(policyViewModel);
        }
        public ActionResult AddPolicySuccess()
        {
            return View();
        }


        public ActionResult ShowAllPoliciesEdit()
        {
            List<Policy> allPolicies = dbContext.Policies.ToList();

            List<PolicyViewModel> viewModels = allPolicies.Select(policy => new PolicyViewModel
            {
                PolicyNumber = policy.PolicyNumber,
                DateOfCreation = policy.DateOfCreation,
                Category = policy.Category,
                PolicyType = policy.PolicyType,
                Price = policy.Price
            }).ToList();

            return View(viewModels);
        }


        public ActionResult EditPolicy(string policyNumber)
        {
            if (string.IsNullOrEmpty(policyNumber))
            {
                return new HttpStatusCodeResult(System.Net.HttpStatusCode.BadRequest);
            }

            Policy policyToEdit = dbContext.Policies.FirstOrDefault(p => p.PolicyNumber == policyNumber);

            if (policyToEdit == null)
            {
                return HttpNotFound();
            }

            PolicyViewModel viewModel = new PolicyViewModel
            {
                PolicyNumber = policyToEdit.PolicyNumber,
                DateOfCreation = policyToEdit.DateOfCreation,
                Category = policyToEdit.Category,
                PolicyType = policyToEdit.PolicyType,
                Price = policyToEdit.Price
            };

            return View(viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult EditPolicy(PolicyViewModel viewModel)
        {
            if (ModelState.IsValid)
            {
                Policy policyToEdit = dbContext.Policies.FirstOrDefault(p => p.PolicyNumber == viewModel.PolicyNumber);

                if (policyToEdit == null)
                {
                    return HttpNotFound();
                }

                policyToEdit.DateOfCreation = viewModel.DateOfCreation;
                policyToEdit.Category = viewModel.Category;
                policyToEdit.PolicyType = viewModel.PolicyType;
                policyToEdit.Price = viewModel.Price;
               
                dbContext.SaveChanges();

                return RedirectToAction("EditPolicySuccess");
            }
            return View(viewModel);
        }
        public ActionResult EditPolicySuccess()
        {
            return View();
        }


        public ActionResult ShowAllPoliciesDelete()
        {
            List<Policy> allPolicies = dbContext.Policies.ToList();
            List<PolicyViewModel> viewModels = allPolicies.Select(policy => new PolicyViewModel
            {
                PolicyNumber = policy.PolicyNumber,
                DateOfCreation = policy.DateOfCreation,
                Category = policy.Category,
                PolicyType = policy.PolicyType,
                Price = policy.Price
            }).ToList();

            return View(viewModels);
        }

        public ActionResult DeletePolicy(string policyNumber)
        {
            if (string.IsNullOrEmpty(policyNumber))
            {
                return new HttpStatusCodeResult(System.Net.HttpStatusCode.BadRequest);
            }

            Policy policyToDelete = dbContext.Policies.FirstOrDefault(p => p.PolicyNumber == policyNumber);

            if (policyToDelete == null)
            {
                return HttpNotFound();
            }

            PolicyViewModel viewModel = new PolicyViewModel
            {
                PolicyNumber = policyToDelete.PolicyNumber,
                DateOfCreation = policyToDelete.DateOfCreation,
                Category = policyToDelete.Category,
                PolicyType = policyToDelete.PolicyType,
                Price = policyToDelete.Price
            };

            return View(viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult ConfirmDeletePolicy(string policyNumber)
        {
            if (string.IsNullOrEmpty(policyNumber))
            {
                return new HttpStatusCodeResult(System.Net.HttpStatusCode.BadRequest);
            }

            Policy policyToDelete = dbContext.Policies.FirstOrDefault(p => p.PolicyNumber == policyNumber);

            if (policyToDelete == null)
            {
                return HttpNotFound();
            }

            dbContext.Policies.Remove(policyToDelete);
            dbContext.SaveChanges();

            return RedirectToAction("DeletePolicySuccess");
        }

        public ActionResult DeletePolicySuccess()
        {
            return View();
        }

    }
}
