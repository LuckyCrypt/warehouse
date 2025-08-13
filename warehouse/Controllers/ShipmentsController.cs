using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace warehouse.Controllers
{
    public class ShipmentsController : Controller
    {
        // GET: Shipments
        public ActionResult Index()
        {
            return View();
        }

        // GET: Shipments/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Shipments/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Shipments/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: Shipments/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Shipments/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: Shipments/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Shipments/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
