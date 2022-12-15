using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MusicShop.DataAccess.Interfaces;
using MusicShop.DataAccess.ViewModels;

namespace MusicShop.Web.Controllers
{
	//[ApiController]
	//[Route("api/[controller]")]
	public class NstrumentController : Controller
    {
        private IUnitOfWork _unitOfWork;
        public NstrumentController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public ActionResult Index()
        {
			NstrumentVM nstrumentVM = new()
			{
				instruments = _unitOfWork.Nstrument.GetAll()
			};
			return View(nstrumentVM);
        }

        [HttpGet]
        public IActionResult CreateUpdate(int? id)
        {
            NstrumentVM vm = new()
            {
                Instrument = new(),
                manufacturers = _unitOfWork.Manufacturer.GetAll().Select(x =>
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
                vm.Instrument = _unitOfWork.Nstrument.GetT(x => x.Id == id);
                if (vm.Instrument == null)
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
        public IActionResult CreateUpdate(NstrumentVM vm)
        {
			if (vm.Instrument.Id == 0)
            {
                _unitOfWork.Nstrument.add(vm.Instrument);
                TempData["Success"] = "Instrument Created Done!";
                _unitOfWork.save();
            }
            else
            {
                _unitOfWork.Nstrument.Update(vm.Instrument);
                TempData["Updated"] = "Instrument Updated Done!";
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
			NstrumentVM nstrumentVM = new()
			{
				Instrument = _unitOfWork.Nstrument.GetT(x => x.Id == id)
			};
			if (nstrumentVM == null)
            {
                return NotFound();
            }
            return View(nstrumentVM);
        }
		[HttpPost, ActionName("Delete")]
		public IActionResult DeleteData(int? id)
		{
			var instrument = _unitOfWork.Nstrument.GetT(x => x.Id == id);
			if (instrument == null)
			{
				return NotFound();
			}
			try
			{
				_unitOfWork.Nstrument.delete(instrument);
				_unitOfWork.save();
				TempData["success"] = "Customer Deleted Done";
				return RedirectToAction("DetailedList");
			}
			//error handling mechanism
			catch (DbUpdateException ex)
			{
				var viewModel = new NstrumentVM();
				viewModel.MapFromModel(instrument);
				ModelState.AddModelError("", "Unable to delete instrument. Please make sure there are no associated orders and try again.");
				return View(viewModel);
			}
		}





		//if you want to make my code turn json and controlled with api this commented area for this but didnt connect with api atm 

		//[HttpGet]
		//public IActionResult Index()
		//{
		//	NstrumentVM nstrumentVM = new();
		//	nstrumentVM.instruments = _unitOfWork.Nstrument.GetAll();
		//	return Ok(nstrumentVM);
		//}
		//[HttpGet("{id}")]
		//public IActionResult CreateUpdate(int? id)
		//{
		//	NstrumentVM vm = new NstrumentVM()
		//	{
		//		Instrument = new(),
		//		manufacturers = _unitOfWork.Manufacturer.GetAll().Select(x =>
		//	 new SelectListItem()
		//	 {
		//		 Text = x.Name,
		//		 Value = x.Id.ToString(),
		//	 })
		//	};
		//	if (id == null || id == 0)
		//	{
		//		return Ok(vm);
		//	}
		//	else
		//	{
		//		vm.Instrument = _unitOfWork.Nstrument.GetT(x => x.Id == id);
		//		if (vm.Instrument == null)
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
		//public IActionResult CreateUpdate([FromBody] NstrumentVM vm)
		//{
		//	if (vm.Instrument.Id == 0)
		//	{
		//		_unitOfWork.Nstrument.add(vm.Instrument);
		//		_unitOfWork.save();
		//		return Ok();
		//	}
		//	else
		//	{
		//		_unitOfWork.Nstrument.Update(vm.Instrument);
		//		_unitOfWork.save();
		//		return Ok();
		//	}
		//}
		//[HttpDelete("{id}")]
		//public IActionResult DeleteInstrument(int? id)
		//{
		//	var instrument = _unitOfWork.Nstrument.GetT(x => x.Id == id);
		//	if (instrument == null)
		//	{
		//		return NotFound();
		//	}
		//	_unitOfWork.Nstrument.delete(instrument);
		//	_unitOfWork.save();
		//	return Ok();
		//}
	}

}
