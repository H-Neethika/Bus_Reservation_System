using Bus_Reservation_System.Models.Domain;
using Bus_Reservation_System.Repositories.Abstract;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Bus_Reservation_System.Controllers
{
    [Authorize(Roles = "Admin")]
    public class BusTypeController : Controller
    {
        private readonly IBusTypeService _busTypeService;
        public BusTypeController(IBusTypeService busTypeService)
        {
            _busTypeService = busTypeService;
        }
        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Add(BusType model)
        {
            if (!ModelState.IsValid)
                return View(model);
            var result = _busTypeService.Add(model);
            if (result)
            {
                TempData["msg"] = "Added Successfully";
                return RedirectToAction(nameof(Add));
            }
            else
            {
                TempData["msg"] = "Error on server side";
                return View(model);
            }
        }

        public IActionResult Edit(int id)
        {
            var data = _busTypeService.GetById(id);
            return View(data);
        }

        [HttpPost]
        public IActionResult Update(BusType model)
        {
            if (!ModelState.IsValid)
                return View(model);
            var result = _busTypeService.Update(model);
            if (result)
            {
                TempData["msg"] = "Added Successfully";
                return RedirectToAction(nameof(BusTypeList));
            }
            else
            {
                TempData["msg"] = "Error on server side";
                return View(model);
            }
        }

        public IActionResult BusTypeList()
        {
            var data = this._busTypeService.List().ToList();
            return View(data);
        }

        public IActionResult Delete(int id)
        {
            
            var result = _busTypeService.Delete(id);                    
            return RedirectToAction(nameof(BusTypeList));
            
        }

       

    }
}
