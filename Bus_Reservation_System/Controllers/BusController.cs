using Bus_Reservation_System.Models.Domain;
using Bus_Reservation_System.Repositories.Abstract;
using Bus_Reservation_System.Repositories.Implementation;
using Humanizer.Localisation;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Bus_Reservation_System.Controllers
{
    [Authorize]
    public class BusController : Controller
    {
        private readonly IBusService _BusService;
        private readonly IFileService _fileService;
        private readonly IBusTypeService _TypeService;
        public BusController(IBusService BusService, IFileService fileService, IBusTypeService typeService)
        {
            _BusService = BusService;
            _fileService = fileService;
            _TypeService = typeService;
        }
        public IActionResult Add()
        {
            var model = new Bus();
            model.BusTypeList = _TypeService.List().Select(a => new Microsoft.AspNetCore.Mvc.Rendering.SelectListItem { Text = a.BusTypeName, Value = a.Id.ToString() });
            return View(model);
        }

        [HttpPost]
        public IActionResult Add(Bus model)
        {
            model.BusTypeList = _TypeService.List().Select(a => new SelectListItem { Text = a.BusTypeName, Value = a.Id.ToString() });

            if (!ModelState.IsValid)
                return View(model);
            if (model.ImageFile != null)
            {
                var fileResult = this._fileService.SaveImage(model.ImageFile);
                if (fileResult.Item1 == 0)
                {
                    TempData["msg"] = "File could not saved";
                    return View(model);
                }
                var imageName = fileResult.Item2;
                model.BusImage = imageName;
            }

            var result = _BusService.Add(model);
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
            var model = _BusService.GetById(id);
            var selectBusTypes = _BusService.GetSBusTypeByBusId(model.Id);
            MultiSelectList multiBusTypeList = new MultiSelectList(_TypeService.List(), "Id", "BusTypeName", selectBusTypes);
            model.MultiBusTypeList = multiBusTypeList;
            return View(model);
        }

        [HttpPost]
        public IActionResult Edit(Bus model)
        {
            var selectBusTypes = _BusService.GetSBusTypeByBusId(model.Id);
            MultiSelectList multiBusTypeList = new MultiSelectList(_TypeService.List(), "Id", "BusTypeName", selectBusTypes);
            model.MultiBusTypeList = multiBusTypeList;
            if (!ModelState.IsValid)
                return View(model);
            if (model.ImageFile != null)
            {
                var fileResult = this._fileService.SaveImage(model.ImageFile);
                if (fileResult.Item1 == 0)
                {
                    TempData["msg"] = "File could not saved";
                    return View(model);
                }
                var imageName = fileResult.Item2;
                model.BusImage = imageName;
            }

            var result = _BusService.Update(model);
            if (result)
            {
                TempData["msg"] = "Added Successfully";
                return RedirectToAction(nameof(BusList));
            }
            else
            {
                TempData["msg"] = "Error on server side";
                return View(model);
            }
        }

        public IActionResult BusList()
        {
            var data = this._BusService.List();
            return View(data);
        }

        public IActionResult Delete(int id)
        {
            var result = _BusService.Delete(id);
            return RedirectToAction(nameof(BusList));
        }
    }
}
