using System.Web.Mvc;
using Filme.Core;

namespace Filme.Controllers
{
    public class ReturnsController : Controller
    {

        private readonly IUnitOfWork _unitOfWork;

        public ReturnsController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        // GET: Returns

        [HttpGet]     
        public ActionResult Index()
        {
            var customerRent = _unitOfWork.Rentals.GetCustomersRents();
            return View(customerRent);
        }

        public ActionResult Details(int id)
        {
            var moviesRented = _unitOfWork.Rentals.RentsByCustomer(id);
            return View(moviesRented);
        }

       
    }
}