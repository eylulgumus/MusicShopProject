using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MusicShop.DataAccess.Interfaces;
using MusicShop.DataAccess.ViewModels;
using System.Diagnostics;

namespace MusicShop.Web.Controllers
{	
    //[ApiController]
    //[Route("api/[controller]")]
    public class CustomerController : Controller
	{

		private IUnitOfWork _unitOfWork;
		public CustomerController(IUnitOfWork unitOfWork)
		{
			_unitOfWork = unitOfWork;
		}
        public ActionResult Index()
        {
            CustomerVM customerVM = new()
            {
                customers = _unitOfWork.Customer.GetAll()
            };
            return View(customerVM);
        }
        public ActionResult DetailedList()
        {
            CustomerVM customerVM = new()
            {
                customers = _unitOfWork.Customer.GetAll()
            };
            return View(customerVM);
        }
        [HttpGet]
        public IActionResult DetailById(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            CustomerVM customerVM = new()
            {
                Customer = _unitOfWork.Customer.GetT(x => x.Id == id)
            };
            if (customerVM == null)
            {
                return NotFound();
            }
            return View(customerVM);
        }

        [HttpGet]
        public IActionResult CreateUpdate(int? id)
        {
            CustomerVM vm = new();
            if (id == null || id == 0)
            {
                return View(vm);
            }
            else
            {
                vm.Customer = _unitOfWork.Customer.GetT(x => x.Id == id);
                if (vm.Customer == null)
                {
                    return NotFound();
                }
                else
                {
                    return View(vm);
                }
            }
        }
        [HttpPost]
        public IActionResult CreateUpdate(CustomerVM vm)
        {
            if (vm.Customer.Id == 0)
            {
                _unitOfWork.Customer.add(vm.Customer);
                TempData["Success"] = "Customer Created Done!";
                _unitOfWork.save();
            }
            else
            {
                _unitOfWork.Customer.Update(vm.Customer);
                TempData["Updated"] = "Customer Updated Done!";
                _unitOfWork.save();
            }
            return RedirectToAction("DetailedList");
        }
        [HttpGet]
        public IActionResult Delete(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            CustomerVM customerVM = new()
            {
                Customer = _unitOfWork.Customer.GetT(x => x.Id == id)
            };
            if (customerVM == null)
            {
                return NotFound();
            }
            return View(customerVM);
        }
		[HttpPost, ActionName("Delete")]
		public IActionResult DeleteData(int? id)
		{
			var customer = _unitOfWork.Customer.GetT(x => x.Id == id);
			if (customer == null)
			{
				return NotFound();
			}
		try
			{
				_unitOfWork.Customer.delete(customer);
				_unitOfWork.save();
				TempData["success"] = "Customer Deleted Done";
				return RedirectToAction("DetailedList");
			}
			//error handling mechanism
			catch (DbUpdateException ex)
			{
				var viewModel = new CustomerVM();
				viewModel.MapFromModel(customer);
				ModelState.AddModelError("", "Unable to delete customer. Please make sure there are no associated orders and try again.");
				return View(viewModel);
			}
		}




		//if you want to make my code turn json and controlled with api this commented area for this but didnt connect with api atm 

		//[HttpDelete("{id}")]
		//public IActionResult Delete(int? id)
		//{
		//    if (id == null || id == 0)
		//    {
		//        return NotFound();
		//    }
		//    var customer = _unitOfWork.Customer.GetT(x => x.Id == id);
		//    if (customer == null)
		//    {
		//        return NotFound();
		//    }

		//    _unitOfWork.Customer.delete(customer);
		//    _unitOfWork.save();

		//    return Ok();
		//}
		//[HttpGet("{id}")]
		//public IActionResult CreateUpdate(int? id)
		//{
		//    if (id == null || id == 0)
		//    {
		//        return Ok(new CustomerVM());
		//    }
		//    else
		//    {
		//        var customer = _unitOfWork.Customer.GetT(x => x.Id == id);
		//        if (customer == null)
		//        {
		//            return NotFound();
		//        }
		//        else
		//        {
		//            return Ok(new CustomerVM { Customer = customer });
		//        }
		//    }
		//}


		//[HttpPost]
		//public IActionResult CreateUpdate([FromBody] CustomerVM vm)
		//{
		//    if (vm.Customer.Id == 0)
		//    {
		//        _unitOfWork.Customer.add(vm.Customer);
		//        _unitOfWork.save();

		//        return Ok();
		//    }
		//    else
		//    {
		//        _unitOfWork.Customer.Update(vm.Customer);
		//        _unitOfWork.save();

		//        return Ok();
		//    }
		//}
		//[HttpGet]
		//public IActionResult Index()
		//{
		//    CustomerVM vm = new();
		//    vm.customers = _unitOfWork.Customer.GetAll();
		//    return Ok(vm);
		//}
	}
}
