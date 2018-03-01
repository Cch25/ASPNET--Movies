using System.Threading.Tasks;
using System.Web.Mvc;
using AutoMapper;
using Filme.Core;
using Filme.Core.Models;
using Filme.Core.ViewModels;

namespace Filme.Controllers
{
    public class CustomerController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        public CustomerController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public ViewResult Index()
        {
            return View();
        }
        public ActionResult Details(int id)
        {
            var customer = _unitOfWork.Customers.GetCustomerDetails(id);
            if (customer == null)
                return HttpNotFound();
            return View(customer);
        }
        public async Task<ActionResult> CustomerForm()
        {
            var membershipType = await _unitOfWork.Customers.GetMembershipTypeList();
            var membershipTypeViewModel = new MembershipTypesViewModel
            {
                Customers = new Customer(),
                MembershipType = membershipType
            };
            return View(membershipTypeViewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Save(MembershipTypesViewModel customer)
        {
            if (!ModelState.IsValid)
            {
                var viewModel = new MembershipTypesViewModel
                {
                    Customers = customer.Customers,
                    MembershipType = await _unitOfWork.Customers.GetMembershipTypeList()
            };
                return View("CustomerForm", viewModel);
            }
            if (customer.Customers.Id == 0)
                _unitOfWork.Customers.Add(customer.Customers);
            else
            {
                var customerInDb = _unitOfWork.Customers.SingleOrDefault(c => c.Id == customer.Customers.Id);
                Mapper.Map(customer, customerInDb);
            }
            _unitOfWork.Complete();

            return RedirectToAction("Index", "Customer");
        }

        public async Task<ActionResult> Edit(int id)
        {
            var customer = _unitOfWork.Customers.SingleOrDefault(c => c.Id == id);
            if (customer == null)
                return HttpNotFound();
            var viewModel = new MembershipTypesViewModel
            {
                Customers = customer,
                MembershipType = await _unitOfWork.Customers.GetMembershipTypeList()
            };
            return View("CustomerForm", viewModel);
        }
    }
}