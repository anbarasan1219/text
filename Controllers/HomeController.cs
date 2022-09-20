using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace text.Controllers
{
    public class HomeController : Controller
    {
        testEntities db=new testEntities();
        public ActionResult Index(int id=0)
        {
            var tablevalue = db.test_table.ToList();
            ViewBag.test_table=tablevalue;
            if(id>0)
            {
                var single_data = db.test_table.Where(e => e.ID == id).First();
                ViewBag.data=single_data;
                ViewBag.Button = "Update";
                return View(single_data);
            }
            ViewBag.Button = "ADD";
            return View(new test_table());
        }
        [HttpPost]
        public ActionResult add_or_update(test_table data)
        {
            if(data.ID>0)
            {
                test_table test_Table = new test_table();
                test_Table.ID = data.ID;
                test_Table.name = data.name;
                test_Table.email=data.email;
                test_Table.phone=data.phone;
                test_Table.zip=data.zip;
                test_Table.hobbies = data.hobbies;
                db.test_table.Add(test_Table);
                db.Entry(test_Table).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
            }
            else
            {
                db.test_table.Add(data);
                db.SaveChanges();
            }
            
            return RedirectToAction("Index");
        }
        public ActionResult editdata(int ID)
        {
            return RedirectToAction("index/" + ID);
        }
        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}