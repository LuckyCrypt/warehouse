using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;
using warehouse.Data.Interfaces;
using warehouse.Data.Models;
using warehouse.ViewModel;

namespace warehouse.Controllers
{
    public class ResourcesController : Controller
    {
        private IResources _resource;

        public ResourcesController(IResources resource)
        {
            _resource = resource;
        }

        // GET: Resources
        public ActionResult Index()
        {
            try
            {
                ResourcesViewModel model = new ResourcesViewModel();
                model.GetResources = _resource.NotArchivResources;
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
                ResourcesViewModel model = new ResourcesViewModel();
                model.GetResources = _resource.ArchivResources;
                return View(model);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex);
            }
        }

        public ActionResult ResourcesEdit(int id, string name)
        {
            try
            {
                ResourcesViewModel model = new ResourcesViewModel();
                model.GetSomeResources = _resource.GetResource(id);

                if (model.GetSomeResources == null)
                {
                    return View();
                }

                return View(model);
            }
            catch (Exception ex)
            {
                // Log the exception
                return View(new { success = false, message = ex.Message });
            }
        }

        // POST: Resources/saveResource
        [HttpPost]
        public ActionResult saveResource(int id, string name)
        {
            if (string.IsNullOrEmpty(name))
            {
                return BadRequest("Имя ресурса не может быть пустым.");
            }
            Resources Resource = _resource.GetResource(id);
            if (Resource == null)
            {
                return BadRequest("Ошибка при редактировании. Элемент не существует");
            }
            try
            {
                _resource.ChangeResource(Resource); // Сохраняем изменения
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
        // POST: Resources/deleteResource
        [HttpPost]
        public ActionResult deleteResource(int id)
        {
            Resources Resource = _resource.GetResource(id);
            if (Resource == null)
            {
                return BadRequest("Ошибка при редактировании. Элемент не существует");
            }
            try
            {
                _resource.DeleteResource(Resource);
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
        // POST: Resources/AddResources
        [HttpPost]
        public ActionResult AddResources(string name)
        {

            if (string.IsNullOrEmpty(name))
            {
                return BadRequest("Имя ресурса не может быть пустым.");
            }
            if (_resource.doubleCheck(name))
            {
                return BadRequest("В системе уже зарегистрирован клиент с таким наименованием.");
            }
            try
            {
                _resource.newResource(name);
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
        // POST: Resources/setArchiveResource
        [HttpPost]
        public ActionResult setArchiveResource(int id, bool archivState)
        {
            Resources Resource = _resource.GetResource(id);
            if (Resource == null)
            {
                return BadRequest("Ошибка при редактировании. Элемент не существует");
            }
            try
            {
                if (archivState)
                    Resource.IsArchived = false;
                else
                    Resource.IsArchived = true;

                _resource.ChangeResource(Resource); // Сохраняем изменения
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
