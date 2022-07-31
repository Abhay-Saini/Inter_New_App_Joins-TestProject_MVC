using Inter_New_App_Joins.DbConnection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Inter_New_App_Joins.Models;


namespace Inter_New_App_Joins.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {
        NewSchoolDb290722Entities1 obj = new NewSchoolDb290722Entities1();

        public ActionResult Welcome()
        {
            return View();
        }

        //Student Record
        public ActionResult Index()
        {
            var res = obj.tbl_Student.ToList();
            return View(res);
        }
       
        public ActionResult ResisterStudent()
        {

            var address = new List<string>() { "Delhi", "Noida", "Ghaziabad", "Meruut", "Modinagar" };

            ViewBag.address = address;

            return View();
        }
        // Add Student through StoreProcedure
        [HttpPost]
        
        public ActionResult ResisterStudent(tbl_Student student)
        {
            obj.sp_AddStudent(student.Stu_Id, student.Name, student.Email, student.Standard, student.Address);

            return RedirectToAction("Index");
        }
        //Student Record By Using Store procedure
        public ActionResult StuResult()
        {

            var data = obj.sp_SelectAll_Student().ToList();
            ViewBag.data = data;
            return View();
        }




        //Teacher Record

        public ActionResult TeacherList()
        {
            var res = obj.tbl_Teacher.ToList();

            return View(res);
        }

        //Teacher Salary List, We can not call this from outside
        [ChildActionOnly]
        public PartialViewResult TeacherSalary()
        {
            ViewBag.Salary = obj.sp_TeacherSalary().ToList();

            return PartialView("_TeacherSalary");
        }


        public ActionResult DeleteStudent(int id)
        {
            var delitem = obj.tbl_Student.Where(m => m.Stu_Id == id).First();
            obj.tbl_Student.Remove(delitem);
            obj.SaveChanges();
            return RedirectToAction("Index");
        }



        //Search

        public ActionResult SearchStu()
        {
            return View();
        }

        [HttpPost]
        public ActionResult SearchStu(StudentsModel o)
        {
            int id = o.Stu_Id;

            var searchRes = obj.sp_SearchStudent(id).ToList();

            List<StudentsModel> student = new List<StudentsModel>();

            foreach (var item in searchRes)
            {
                student.Add(new StudentsModel
                {
                    Stu_Id = item.Stu_Id,
                    Name = item.Name,
                    Email = item.Email,
                    Standard = item.Standard,
                    Address = item.Address
                });
            }

            Session["StudentData"] = student;

            ViewBag.data = student;

            if (searchRes.Count > 0)
            {
                return View();
            }
            else
            {
                TempData["notfound"] = "Data Not Found";
                return View();
            }

        }

        public ActionResult StudentMarks()
        {
           var StudentMarklist = obj.sp_StuMarks().ToList();

            List<StudentMarks> marks = new List<StudentMarks>();

            foreach (var item in StudentMarklist)
            {
                marks.Add(new StudentMarks
                {
                    Name = item.Name,
                    Email = item.Email,
                    Maths = item.Maths,
                    Hindi = item.Hindi,
                    English = item.English,
                    Science = item.Science
                });
            }

            return View(marks);
        }


    }
}