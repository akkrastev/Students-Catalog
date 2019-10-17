using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebSite.Models;
using WebSite.StudentService;
using WebSite.ViewModels;

namespace WebSite.Controllers
{
    public class StudentController : Controller
    {
        StudentClientModel _service = new StudentClientModel();
        NationalityClientModel _serviceNationality = new NationalityClientModel();
        FacultyClientModel _serviceFaculty = new FacultyClientModel();


        // GET: Student
        public ActionResult Index()
        {
            
            List<StudentViewModel> studentVM = new List<StudentViewModel>();
            using (_service.Service)
            {
                foreach(var item in _service.Service.GetStudents())
                {
                    studentVM.Add(new StudentViewModel(item));
                }
            }
            return View(studentVM);
        }

        // GET: Student/Details/5
        public ActionResult Details(int id)
        {
            
            StudentViewModel studentVM = new StudentViewModel();
            using (_service.Service)
            {
                var studentDto = _service.Service.GetStudentByID(id);
                studentVM = new StudentViewModel(studentDto);

            }
            return View(studentVM);
        }

        // GET: Student/Create
        public ActionResult Create()
        {
            
            using (_serviceNationality.Service)
            {
                ViewBag.Nationalities = new SelectList(_serviceNationality.Service.GetNationalities(), "Id", "Title");
            }

            
            using (_serviceFaculty.Service)
            {
                ViewBag.Faculties = new SelectList(_serviceFaculty.Service.GetFaculties(), "Id", "Name");
            }
            return View();
        }

        // POST: Student/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(StudentViewModel studentVM)
        {
            
            try
            {
                using (_service.Service)
                {
                    StudentService.StudentDto studentDto = new StudentService.StudentDto
                    {
                        FirstName = studentVM.FirstName,
                        LastName = studentVM.LastName,
                        DateOfBirth = studentVM.DateOfBirth,
                        City = studentVM.City,
                        Nationality = new NationalityDto
                        {
                            Id = studentVM.NationalityId
                        },
                        Faculty = new FacultyDto
                        {
                            Id = studentVM.FacultyId
                        }
                    };
                    _service.Service.PostStudent(studentDto);
                }

                
                using (_serviceNationality.Service)
                {
                    ViewBag.Nationalities = new SelectList(_serviceNationality.Service.GetNationalities(), "Id", "Title");
                }

                
                using (_serviceFaculty.Service)
                {
                    ViewBag.Faculties = new SelectList(_serviceFaculty.Service.GetFaculties(), "Id", "Name");
                }   

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Student/Edit/5
        public ActionResult Edit(int id)
        {
            
            StudentViewModel studentVM = new StudentViewModel();
            using (_service.Service)
            {
                var studentDto = _service.Service.GetStudentByID(id);
                studentVM = new StudentViewModel(studentDto);
            }

            
            using (_serviceNationality.Service)
            {
                ViewBag.Nationalities = new SelectList(_serviceNationality.Service.GetNationalities(), "Id", "Title");
            }

            
            using (_serviceFaculty.Service)
            {
                ViewBag.Faculties = new SelectList(_serviceFaculty.Service.GetFaculties(), "Id", "Name");
            }

            return View(studentVM);
        }

        // POST: Student/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(StudentViewModel studentVM)
        {
            
            try
            {
                if (ModelState.IsValid)
                {
                    using (_service.Service)
                    {
                        StudentService.StudentDto studentDto = new StudentService.StudentDto
                        {
                            Id = studentVM.Id,
                            FirstName = studentVM.FirstName,
                            LastName = studentVM.LastName,
                            DateOfBirth = studentVM.DateOfBirth,
                            City =studentVM.City,
                            Nationality = new StudentService.NationalityDto
                            {
                                Id = studentVM.NationalityId
                            },
                            Faculty = new StudentService.FacultyDto
                            {
                                Id = studentVM.FacultyId
                            }
                        };
                        _service.Service.PostStudent(studentDto);
                    }

                    return RedirectToAction("Index");
                }
                
                using (_serviceNationality.Service)
                {
                    ViewBag.Nationalities = new SelectList(_serviceNationality.Service.GetNationalities(), "Id", "Title");
                }

                
                using (_serviceFaculty.Service)
                {
                    ViewBag.Faculties = new SelectList(_serviceFaculty.Service.GetFaculties(), "Id", "Name");
                }

                return View();
            }
            catch
            {
                
                using (_serviceNationality.Service)
                {
                    ViewBag.Nationalities = new SelectList(_serviceNationality.Service.GetNationalities(), "Id", "Title");
                }

                
                using (_serviceFaculty.Service)
                {
                    ViewBag.Faculties = new SelectList(_serviceFaculty.Service.GetFaculties(), "Id", "Name");
                }
                return View();
            }
        }

        // GET: Student/Delete/5
        public ActionResult Delete(int id)
        {
            StudentClientModel _service = new StudentClientModel();
            StudentViewModel studentVM = new StudentViewModel();
            using (_service.Service)
            {
                _service.Service.DeleteStudent(id);
            }
                return RedirectToAction("Index");
        }

        
    }
}
