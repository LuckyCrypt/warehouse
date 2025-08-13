using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;
using warehouse.Data.Interfaces;
using warehouse.Data.Models;
using warehouse.ViewModel;

namespace warehouse.Controllers
{
    public class UnitsController : Controller
    {
        private IUnits _unitsRep;

        public UnitsController(IUnits unitrep)
        {
            _unitsRep = unitrep;
        }

        // GET: Units
        public ActionResult Index()
        { 
            try
            {
                UnitsViewModel model = new UnitsViewModel();
                model.GetUnits = _unitsRep.NotArchivUnits;
                return View(model);
            } 
            catch (Exception ex)
            {
                return StatusCode(500, ex);
            }
            
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        public ActionResult Archive()
        {
            try
            {
                UnitsViewModel model = new UnitsViewModel();
                model.GetUnits = _unitsRep.ArchivUnits;
                return View(model);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex);
            }
        }

        public ActionResult UnitsEdit(int id, string name)
        {
            try
            {
                UnitsViewModel model = new UnitsViewModel();
                model.GetSomeUnits = _unitsRep.GetUnit(id);

                if (model.GetSomeUnits == null)
                {
                    return View();
                }

                return View(model);
            }
            catch (DbUpdateException ex)
            {
                return BadRequest($"Ошибка при сохранении в базу данных: {ex.InnerException?.Message ?? ex.Message}");
            }
            catch (Exception ex)
            {
                Console.Error.WriteLine($"Непредвиденная ошибка при создании клиента: {ex}");
                return StatusCode(500, "Произошла непредвиденная ошибка при создании клиента.");
            }


        }
        // POST: Units/saveUnit
        [HttpPost]
        public ActionResult saveUnit(int id, string name)
        {
            if (string.IsNullOrEmpty(name))
            {
                return BadRequest("Имя ресурса не может быть пустым.");
            }
            Units unit = _unitsRep.GetUnit(id);
            if (unit == null)
            {
                return BadRequest("Ошибка при редактировании. Элемент не существует");
            }
            try
            {
                unit.Name = name;
                _unitsRep.ChangeUnit(unit); // Сохраняем изменения
                return Ok();
            }
            catch (DbUpdateException ex)
            {
                return BadRequest($"Ошибка при сохранении в базу данных: {ex.InnerException?.Message ?? ex.Message}");
            }
            catch (Exception ex)
            {
                Console.Error.WriteLine($"Непредвиденная ошибка при создании клиента: {ex}");
                return StatusCode(500, "Произошла непредвиденная ошибка при создании клиента.");
            }
        }
        // POST: Units/deleteUnit
        [HttpPost]
        public ActionResult deleteUnit(int id)
        {
            Units unit = _unitsRep.GetUnit(id);
            if (unit == null)
            {
                return BadRequest("Ошибка при редактировании. Элемент не существует");
            }
            try
            {
                _unitsRep.DeleteUnit(unit);
                return Ok();
            }
            catch (DbUpdateException ex)
            {
                return BadRequest($"Ошибка при сохранении в базу данных: {ex.InnerException?.Message ?? ex.Message}");
            }
            catch (Exception ex)
            {
                Console.Error.WriteLine($"Непредвиденная ошибка при создании клиента: {ex}");
                return StatusCode(500, "Произошла непредвиденная ошибка при создании клиента.");
            }
        }
        // POST: Units/AddUnits
        [HttpPost]
        public ActionResult AddUnits(string name)
        {

            if (string.IsNullOrEmpty(name))
            {
                return BadRequest("Имя ресурса не может быть пустым.");
            }
            if (_unitsRep.doubleCheck(name))
            {
                return BadRequest("В системе уже зарегистрирован клиент с таким наименованием.");
            }
            try
            {
                _unitsRep.newUnit(name);
                return Ok();
            }
            //Сделать нормальную систему ошибок
            catch (DbUpdateException ex)
            { 
                return BadRequest($"Ошибка при сохранении в базу данных: {ex.InnerException?.Message ?? ex.Message}");
            }
            catch (Exception ex)
            {
                Console.Error.WriteLine($"Непредвиденная ошибка при создании клиента: {ex}");
                return StatusCode(500, "Произошла непредвиденная ошибка при создании клиента.");
            }

        }
        // POST: Units/setArchiveUnit
        [HttpPost]
        public ActionResult setArchiveUnit(int id,bool archivState)
        {
            Units unit = _unitsRep.GetUnit(id);
            if (unit == null)
            {
                return BadRequest("Ошибка при редактировании. Элемент не существует");
            }
            try
            {
                if (archivState)
                    unit.IsArchived = false;
                else
                    unit.IsArchived = true;

                _unitsRep.ChangeUnit(unit); // Сохраняем изменения
                return Ok();
            }
            catch (DbUpdateException ex)
            {
                return BadRequest($"Ошибка при сохранении в базу данных: {ex.InnerException?.Message ?? ex.Message}");
            }
            catch (Exception ex)
            {
                Console.Error.WriteLine($"Непредвиденная ошибка при создании клиента: {ex}");
                return StatusCode(500, "Произошла непредвиденная ошибка при создании клиента.");
            }
        }
    }
}
