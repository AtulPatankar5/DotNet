using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MVCMobile.Models;

namespace MVCMobile.Controllers
{


    public class MobileController : Controller
    {
        DbOperations db = new DbOperations();

        // GET: MobileController
        public ActionResult Index()
        {
            List<Mobile> mob = db.getAllDetails();
            return View(mob);
        }

        // GET: MobileController/Details/5
        public ActionResult Details(int id)
        {
            Mobile mob=db.getSingleDetails(id);
            return View(mob);
        }

        // GET: MobileController/Create
        public ActionResult Create()
        {

            return View();
        }

        // POST: MobileController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Mobile mob)
        {
            try
            {
                Mobile m = new Mobile { MobileId=mob.MobileId,Name=mob.Name,Brand=mob.Brand,Price=mob.Price };
                db.CreateMobile(m);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: MobileController/Edit/5
        public ActionResult Edit(int id)
        {
            return View(db.getSingleDetails(id));
        }


        // POST: MobileController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, Mobile mob)
        {
            try
            {
                db.editMobile(mob);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: MobileController/Delete/5
        public ActionResult Delete(int id)
        {
            return View(db.getSingleDetails(id));
        }

        // POST: MobileController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, Mobile mob)
        {
            try
            {
                db.deleteMobile(id);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
