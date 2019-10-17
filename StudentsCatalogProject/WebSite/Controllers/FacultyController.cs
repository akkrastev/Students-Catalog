using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebSite.Models;
using WebSite.ViewModels;

namespace WebSite.Controllers
{
    public class FacultyController : Controller
    {
        FacultyClientModel _service = new FacultyClientModel();
        // GET: Faculty
        public ActionResult Index()
        {
            
            List<FacultyViewModel> facultyVM = new List<FacultyViewModel>();
            using (_service.Service)
            {
                foreach(var item in _service.Service.GetFaculties())
                {
                    facultyVM.Add(new FacultyViewModel(item));
                }
            }
            return View(facultyVM);
        }

        // GET: Faculty/Details/5
        public ActionResult Details(int id)
        {
            
            FacultyViewModel facultyVM = new FacultyViewModel();
            using (_service.Service)
            {
                var facultyDto = _service.Service.GetFacultyByID(id);
                facultyVM = new FacultyViewModel(facultyDto);
            }
            return View(facultyVM);
        }

        // GET: Faculty/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Faculty/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(FacultyViewModel facultyVM)
        {
            
            try
            {
                using (_service.Service)
                {
                    FacultyService.FacultyDto facultyDto = new FacultyService.FacultyDto
                    {
                        Name = facultyVM.Name,
                        City = facultyVM.City,
                        Address = facultyVM.Address
                    };
                    _service.Service.PostFaculty(facultyDto);
                }

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Faculty/Edit/5
        public ActionResult Edit(int id)
        {
            
            FacultyViewModel facultyVM = new FacultyViewModel();
            using (_service.Service)
            {
                var facultyDto = _service.Service.GetFacultyByID(id);
                facultyVM = new FacultyViewModel(facultyDto);
            }
            return View(facultyVM);
        }

        // POST: Faculty/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(FacultyViewModel facultyVM)
        {
            
            try
            {
                if (ModelState.IsValid)
                {
                    using (_service.Service)
                    {
                        FacultyService.FacultyDto facultyDto = new FacultyService.FacultyDto
                        {
                            Id = facultyVM.Id,
                            Name = facultyVM.Name,
                            City = facultyVM.City,
                            Address = facultyVM.Address
                        };
                        _service.Service.PostFaculty(facultyDto);
                    }

                    return RedirectToAction("Index");
                }

                return View();
            }
            catch
            {
                return View();
            }
        }

        // GET: Faculty/Delete/5
        public ActionResult Delete(int id)
        {
            
            FacultyViewModel facultyVM = new FacultyViewModel();

            using (_service.Service)
            {
                _service.Service.DeleteFaculty(id);
            }
            return RedirectToAction("Index");
        }
 
    }
}
