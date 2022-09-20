using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ASPNETMVC.Models;

namespace ASPNETMVC.Controllers
{
    
    public class HomeController : Controller
    {
        doToDoEntities db = new doToDoEntities();
        // GET: Home
        public ActionResult Index()
        {
            var Employee_Data = db.Employee.OrderBy(m => m.Id).ToList();
            return View(Employee_Data);
        }
        public ActionResult Create()
        {
            return View();
        }
        public ActionResult Edit(int id)
        {
            var emp = db.Employee.Where(m => m.Id == id).FirstOrDefault();
            return View(emp);
        }
        [HttpPost]
        public ActionResult Create(string name,int age,DateTime bir)
        {
            Employee emp = new Employee();
            emp.name = name;
            emp.age = age;
            emp.bir = bir;
            db.Employee.Add(emp);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        [HttpPost]
        public ActionResult Edit(Employee new_emp_data)
        {
            int id = new_emp_data.Id;
            var emp = db.Employee.Where(m => m.Id == id).FirstOrDefault();
            emp.name = new_emp_data.name;
            emp.age = new_emp_data.age;
            emp.bir = new_emp_data.bir;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult Delete(int id)
        {
            var emp = db.Employee.Where(m => m.Id == id).FirstOrDefault();
            db.Employee.Remove(emp);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}