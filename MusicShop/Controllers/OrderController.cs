using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using MusicShop.DataAccess.Interfaces;
using MusicShop.DataAccess.ViewModels;


namespace MusicShop.Web.Controllers
{
	//[ApiController]
	//[Route("api/[Controller]")]
	public class OrderController : Controller
	{
		private IUnitOfWork _unitOfWork;
		public OrderController(IUnitOfWork unitOfWork)
		{
			_unitOfWork = unitOfWork;
		}
		public ActionResult Index()
		{
            OrderVM orderVM = new()
            {
                orders = _unitOfWork.Order.GetAll()
            };
            return View(orderVM);
        }
        public ActionResult DetailedList()
        {
            OrderVM orderVM = new()
            {
                orders = _unitOfWork.Order.GetAll()
            };
            return View(orderVM);
        }
		[HttpGet]
		public IActionResult DetailById(int? id)
		{
			if (id == null || id == 0)
			{
				return NotFound();
			}
			OrderVM orderVM = new()
			{
				Order = _unitOfWork.Order.GetT(x => x.Id == id)
			};
			if (orderVM == null)
			{
				return NotFound();
			}
			return View(orderVM);
		}

		[HttpGet]
		public IActionResult CreateUpdate(int? id)
		{
			OrderVM vm = new()
			{
				Order = new(),
				instruments = _unitOfWork.Nstrument.GetAll().Select(x =>
			 new SelectListItem()
			 {
				 Text = $"Name: {x.Name} Id: {x.Id}",
				 Value = x.Id.ToString(),
			 }),
				customers = _unitOfWork.Customer.GetAll().Select(x =>
				new SelectListItem()
				{
					Text = $"Name: {x.Name} Id: {x.Id}",
					Value = x.Id.ToString(),
				})
			};
			if (id == null || id == 0)
			{
				return View(vm);
			}
			else
			{
				vm.Order = _unitOfWork.Order.GetT(x => x.Id == id);
				if (vm.Order == null)
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
		public IActionResult CreateUpdate(OrderVM vm)
		{
			if (vm.Order.Id == 0)
			{
				_unitOfWork.Order.add(vm.Order);
				TempData["Success"] = "Order Created Done!";
				_unitOfWork.save();
			}
			else
			{
				_unitOfWork.Order.Update(vm.Order);
				TempData["Updated"] = "Order Updated Done!";
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
			OrderVM orderVM = new()
			{
				Order = _unitOfWork.Order.GetT(x => x.Id == id)
			};
			if (orderVM == null)
			{
				return NotFound();
			}
			return View(orderVM);
		}
		[HttpPost, ActionName("Delete")]
		public IActionResult DeleteData(int? id)
		{
			var order = _unitOfWork.Order.GetT(x => x.Id == id);
			if (order == null)
			{
				return NotFound();
			}
			_unitOfWork.Order.delete(order);
			_unitOfWork.save();
			TempData["success"] = "Customer Deleted Done";
			return RedirectToAction("DetailedList");
		}





		//if you want to make my code turn json and controlled with api this commented area for this but didnt connect with api atm 

		//[HttpGet]
		//public IActionResult Index()
		//{
		//	OrderVM orderVM = new();
		//	orderVM.orders = _unitOfWork.Order.GetAll();
		//	return Ok(orderVM);
		//}
		//[HttpGet("{id}")]
		//public IActionResult CreateUpdate(int? id)
		//{
		//	OrderVM vm = new OrderVM()
		//	{
		//		Order = new(),
		//		instruments = _unitOfWork.Nstrument.GetAll().Select(x =>
		//	 new SelectListItem()
		//	 {
		//		 Text = x.Name,
		//		 Value = x.Id.ToString(),
		//	 }),
		//		customers = _unitOfWork.Customer.GetAll().Select(x =>
		//		new SelectListItem()
		//		{
		//			Text = x.Name,
		//			Value = x.Id.ToString(),
		//		})
		//	};
		//	if (id == null || id == 0)
		//	{
		//		return Ok(vm);
		//	}
		//	else
		//	{
		//		vm.Order = _unitOfWork.Order.GetT(x => x.Id == id);
		//		if (vm.Order == null)
		//		{
		//			return NotFound();
		//		}
		//		else
		//		{
		//			return Ok(vm);
		//		}
		//	}
		//}
		//[HttpPost]
		//public IActionResult CreateUpdate([FromBody] OrderVM vm)
		//{
		//	if (vm.Order.Id == 0)
		//	{
		//		_unitOfWork.Order.add(vm.Order);
		//		_unitOfWork.save();
		//		return Ok();
		//	}
		//	else
		//	{
		//		_unitOfWork.Order.Update(vm.Order);
		//		_unitOfWork.save();
		//		return Ok();
		//	}
		//}
		//[HttpDelete("{id}")]
		//public IActionResult DeleteOrder(int? id)
		//{
		//	if (id == null || id == 0)
		//	{
		//		return NotFound();
		//	}
		//	var order = _unitOfWork.Order.GetT(x => x.Id == id);
		//	if (order == null)
		//	{
		//		return NotFound();
		//	}
		//	_unitOfWork.Order.delete(order);
		//	_unitOfWork.save();
		//	return Ok();
		//}
	}
}
