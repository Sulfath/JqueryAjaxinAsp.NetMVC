using JqueryAjaxinAsp.NetMVC.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace JqueryAjaxinAsp.NetMVC.Controllers
{
    public class EmployeeController : Controller
    {
        // GET: Employee

        public ActionResult Index()
        {
            return View();
        }

    
        public ActionResult ViewAll()
        {
            return View(GetAllEmployee());
        }

        IEnumerable<Employee> GetAllEmployee()
        {
            using (jQueryAjaxDBEntities db =new jQueryAjaxDBEntities())
            {
                return db.Employees.ToList<Employee>();
            }
        }


        public ActionResult AddOrEdit(int id=0)
        {
            Employee emp = new Employee();
            if(id !=0)
            {
                using (jQueryAjaxDBEntities db = new jQueryAjaxDBEntities())
                {
                    emp = db.Employees.Where(x => x.EmployeeID == id).FirstOrDefault<Employee>();
                }
            }
            return View(emp);
        }

        [HttpPost]
        public ActionResult AddOrEdit(Employee emp)
        {
            try
            {
                if (emp.ImageUpload != null)
                {
                    string fileName = Path.GetFileNameWithoutExtension(emp.ImageUpload.FileName);
                    string extension = Path.GetExtension(emp.ImageUpload.FileName);
                    fileName = fileName + DateTime.Now.ToString("yymmssff") + extension;
                    emp.ImagePath = "~/AppFiles/Images/" + fileName;
                    emp.ImageUpload.SaveAs(Path.Combine(Server.MapPath("~/AppFiles/Images/"), fileName));
                }

                using (jQueryAjaxDBEntities db = new jQueryAjaxDBEntities())
                {
                    if (emp.EmployeeID == 0)
                    {
                        db.Employees.Add(emp);
                        db.SaveChanges();
                    }
                    else
                    {
                        db.Entry(emp).State = EntityState.Modified;
                        db.SaveChanges();
                    }
                }
                //return RedirectToAction("ViewAll");
            }
            catch(Exception ex)
            {

            }
            return RedirectToAction("ViewAll");
        }

        [HttpPost]
        public ActionResult Delete(int id)
        {
            return View();
        }
    }

}