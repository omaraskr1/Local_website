using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using lab8.Models;
namespace lab8.Controllers
{
    public class costomerController : Controller
    {
        private ApplicationDbContext _context;
        // GET: costomer
        public costomerController() { _context = new ApplicationDbContext(); }
		protected override void Dispose(bool disposing)
		{
            _context.Dispose();
		}
        public ActionResult New ()
        {
            return View();
        }
        [HttpPost]
        public ActionResult create(coustomer coss)
		{
            if (coss.id == 0)
            {
                _context.cos.Add(coss);
            }
			else
			{
                var cindp = _context.cos.SingleOrDefault(m => m.id == coss.id);
                cindp.name = coss.name;
                cindp.birthday = coss.birthday;
                cindp.issubscribed = coss.issubscribed;
            }
            _context.SaveChanges();
            return RedirectToAction("Index","costomer");
        }
        public ActionResult Index()
        {
            var cost = _context.cos.ToList();
            return View(cost);
        }
        public ActionResult delete(int id)
        {
            var cost = _context.cos.SingleOrDefault(m=>m.id==id);
			if (cost == null)
			{
                return HttpNotFound();
			}
			else
			{
                _context.cos.Remove(cost);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(cost);
        }
        public ActionResult details(int id)
        {
            var cost = _context.cos.SingleOrDefault(c => c.id == id);
			if (cost == null)
			{
                return HttpNotFound();
			}
            return View(cost);
        }
        public ActionResult edit(int id)
        {
            var c = _context.cos.SingleOrDefault(m => m.id == id);
			if(c == null){
                return HttpNotFound();
			}
           
            return View("new",c);
        }
    }
}