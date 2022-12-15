using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MusicShop.DataAccess.Interfaces;
using MusicShop.DataAccess.ViewModels;


namespace MusicShop.Web.Controllers
{
	//[ApiController]
	//[Route("api/[controller]")]
	public class ManufacturerController : Controller
    {
        private IUnitOfWork _unitOfWork;
        public ManufacturerController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
		public ActionResult Index()
		{
			ManufacturerVM manufacturerVm = new()
			{
				manufacturers = _unitOfWork.Manufacturer.GetAll()
			};
			return View(manufacturerVm);
		}

		[HttpGet]
		public IActionResult CreateUpdate(int? id)
		{
			ManufacturerVM vm = new();
			if (id == null || id == 0)
			{
				return View(vm);
			}
			else
			{
				vm.Manufacturer = _unitOfWork.Manufacturer.GetT(x => x.Id == id);
				if (vm.Manufacturer == null)
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
		public IActionResult CreateUpdate(ManufacturerVM vm)
		{
			if (vm.Manufacturer.PhoneNumber.Length > 11)
			{
				ModelState.AddModelError("", "Phone Number cannot be longer than 11 characters.");
				return View(vm);
			}
			if (vm.Manufacturer.Id == 0)
			{
				_unitOfWork.Manufacturer.add(vm.Manufacturer);
				TempData["Success"] = "Manufacture Created Done!";
				_unitOfWork.save();
			}
			else
			{
				_unitOfWork.Manufacturer.Update(vm.Manufacturer);
				TempData["Updated"] = "Manufacture Updated Done!";
				_unitOfWork.save();
			}
			return RedirectToAction("Index");

		}
		[HttpGet]
		public IActionResult Delete(int? id)
		{
			if (id == null || id == 0)
			{
				return NotFound();
			}
			ManufacturerVM manufacturerVm = new()
			{
				Manufacturer = _unitOfWork.Manufacturer.GetT(x => x.Id == id)
			};
			if (manufacturerVm == null)
			{
				return NotFound();
			}
			return View(manufacturerVm);
		}
		[HttpPost, ActionName("Delete")]
		public IActionResult DeleteData(int? id)
		{
			var manufacturer = _unitOfWork.Manufacturer.GetT(x => x.Id == id);
			if (manufacturer == null)
			{
				return NotFound();
			}
			try
			{
				_unitOfWork.Manufacturer.delete(manufacturer);
				_unitOfWork.save();
				TempData["success"] = "Customer Deleted Done";
				return RedirectToAction("Index");
			}
			catch (DbUpdateException ex)
			{
				var viewModel = new ManufacturerVM();
				viewModel.MapFromModel(manufacturer);
				ModelState.AddModelError("", "Unable to delete Manufacturer.Please make sure there are no associated order or instrument and try again.");
				return View(viewModel);
			}
		}




		//if you want to make my code turn json and controlled with api this commented area for this but didnt connect with api atm 

		//[HttpGet]
		//public IActionResult GetAllManufacturers()
		//{
		//	ManufacturerVM manufacturerVm = new();
		//	manufacturerVm.manufacturers = _unitOfWork.Manufacturer.GetAll();
		//	return Ok(manufacturerVm);
		//}
		//[HttpDelete("{id}")]
		//public IActionResult DeleteManufacturer(int id)
		//{
		//	if (id == null || id == 0)
		//	{
		//		return NotFound();
		//	}
		//	var manufacturer = _unitOfWork.Manufacturer.GetT(x => x.Id == id);
		//	if (manufacturer == null)
		//	{
		//		return NotFound();
		//	}
		//	_unitOfWork.Manufacturer.delete(manufacturer);
		//	_unitOfWork.save();
		//	return Ok();
		//}
		//[HttpGet("{id}")]
		//public IActionResult GetManufacturer(int id)
		//{
		//	ManufacturerVM vm = new();
		//	if (id == null || id == 0)
		//	{
		//		return NotFound();
		//	}
		//	vm.Manufacturer = _unitOfWork.Manufacturer.GetT(x => x.Id == id);
		//	if (vm.Manufacturer == null)
		//	{
		//		return NotFound();
		//	}
		//	else
		//	{
		//		return Ok(vm);
		//	}
		//}

		//[HttpPost]
		//public IActionResult CreateManufacturer(ManufacturerVM vm)
		//{
		//	if (vm.Manufacturer.Id == 0)
		//	{
		//		_unitOfWork.Manufacturer.add(vm.Manufacturer);
		//		_unitOfWork.save();
		//		return CreatedAtAction("GetManufacturer", new { id = vm.Manufacturer.Id });
		//	}
		//	else
		//	{
		//		_unitOfWork.Manufacturer.Update(vm.Manufacturer);
		//		_unitOfWork.save();
		//		return Ok();
		//	}
		//}
	}
}
