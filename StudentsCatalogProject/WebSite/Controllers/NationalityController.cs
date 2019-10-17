using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.ServiceModel;
using System.Web;
using System.Web.Mvc;
using WebSite.Models;
using WebSite.ViewModels;


namespace WebSite.Controllers
{
    public class NationalityController : Controller
    {
        NationalityClientModel _service = new NationalityClientModel();
        // GET: Nationality
        public ActionResult Index()
        {
            List<NationalityViewModel> nationalityVM = new List<NationalityViewModel>();
            try
            {
               
                using (_service.Service)
                {
                    foreach (var item in _service.Service.GetNationalities())
                    {
                        nationalityVM.Add(new NationalityViewModel(item));
                    }
                }
            }
            catch {
                return View("Error");
            }
            
            return View(nationalityVM);
        }

        // GET: Nationality/Details/5
        public ActionResult Details(int id)
        {
            
            NationalityViewModel nationalityVM = new NationalityViewModel();
            using (_service.Service)
            {
                var nationalityDto = _service.Service.GetNationalityByID(id);
                nationalityVM = new NationalityViewModel(nationalityDto);
            }
            return View(nationalityVM);
        }

        // GET: Nationality/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Nationality/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(NationalityViewModel nationalityVM)
        {
            
            try
            {
                using (_service.Service)
                {
                    NationalityService.NationalityDto nationalityDto = new NationalityService.NationalityDto
                    {
                        Title = nationalityVM.Title
                    };
                    _service.Service.PostNationality(nationalityDto);
                }

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Nationality/Edit/5
        public ActionResult Edit(int id)
        {
            
            NationalityViewModel nationalityVM = new NationalityViewModel();
            using (_service.Service)
            {
                var nationalityDto = _service.Service.GetNationalityByID(id);
                nationalityVM = new NationalityViewModel(nationalityDto);
            }
            return View(nationalityVM);
        }

        // POST: Nationality/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(NationalityViewModel nationalityVM)
        {
            
            try
            {
                if (ModelState.IsValid)
                {
                    using (_service.Service)
                    {
                        NationalityService.NationalityDto nationalityDto = new NationalityService.NationalityDto
                        {
                            Id = nationalityVM.Id,
                            Title = nationalityVM.Title
                        };
                        _service.Service.PostNationality(nationalityDto);
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

        // GET: Nationality/Delete/5
        public ActionResult Delete(int id)
        {
            
            NationalityViewModel nationalityVM = new NationalityViewModel();

            using (_service.Service)
            {
                _service.Service.DeleteNationality(id);
            }
            return RedirectToAction("Index");
        }

    }
}
