using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;
using warehouse.Data.Interfaces;
using warehouse.Data.Models;
using warehouse.ViewModel;

namespace warehouse.Controllers
{
    public class ClientsController : Controller
    {
        private readonly IClients _client;

        public ClientsController(IClients clinet)
        {
            _client = clinet;
        }

        // GET: Clients
        public ActionResult Index()
        {
            try
            {
                ClientsViewModel model = new ClientsViewModel();
                model.GetClients = _client.NotArchivClients;
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
                ClientsViewModel model = new ClientsViewModel();
                model.GetClients = _client.ArchivClients;
                return View(model);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex);
            }
        }

        public ActionResult ClientsEdit(int id, string name)
        {
            try
            {
                ClientsViewModel model = new ClientsViewModel();
                model.GetSomeClients = _client.GetClient(id);

                if (model.GetSomeClients == null)
                {
                    return View();
                }
                return View(model);
            }
            catch (Exception ex)
            {
                return View(new { success = false, message = ex.Message });
            }
        }

        // POST: Clients/saveClient
        [HttpPost]
        public ActionResult saveClient(int id, string name,string address)
        {
            if (string.IsNullOrEmpty(name))
            {
                return BadRequest("Имя ресурса не может быть пустым.");
            }
            Clients Client = _client.GetClient(id);
            if (Client == null)
            {
                return BadRequest("Ошибка при редактировании. Элемент не существует");
            }
            try
            {
                Client.Name = name;
                Client.Address = address;
                _client.ChangeClient(Client); // Сохраняем изменения
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
        // POST: Clients/deleteClient
        [HttpPost]
        public ActionResult deleteClient(int id)
        {
            Clients Client = _client.GetClient(id);
            if (Client == null)
            {
                return BadRequest("Ошибка при редактировании. Элемент не существует");
            }
            try
            {
                _client.DeleteClient(Client);
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
        // POST: Clients/AddClients
        [HttpPost]
        public ActionResult AddClients(string name, string address)
        {

            if (string.IsNullOrEmpty(name))
            {
                return BadRequest("Имя ресурса не может быть пустым.");
            }
            if (_client.doubleCheck(name))
            {
                return BadRequest("В системе уже зарегистрирован клиент с таким наименованием.");
            }
            try
            {
                _client.newClient(name, address);
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
        // POST: Clients/setArchiveClient
        [HttpPost]
        public ActionResult setArchiveClient(int id, bool archivState)
        {
            Clients Client = _client.GetClient(id);
            if (Client == null)
            {
                return BadRequest("Ошибка при редактировании. Элемент не существует");
            }
            try
            {
                if (archivState)
                    Client.IsArchived = false;
                else
                    Client.IsArchived = true;

                _client.ChangeClient(Client);
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
