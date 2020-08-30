using Apteka.Core;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

namespace Apteka.Controllers
{
    public class HomeController : Controller
    {

        private readonly IDoctorMenager mDoctorMenager;

        private readonly ViewModelMapper mViewModelMapper;

        

        public HomeController(IDoctorMenager doctorMenager,
                                  ViewModelMapper viewModelMapper)
        {
            mDoctorMenager = doctorMenager;
            mViewModelMapper = viewModelMapper;
        }

        

        public IActionResult Index(string filterString)
        {

            var doctorDtos = mDoctorMenager.GetAllDoctors(filterString);

            var doctorViewModels = mViewModelMapper.Map(doctorDtos);

            return View(doctorViewModels);
        }

        public IActionResult View(int doctorId)
        {
            return RedirectToAction("Index", "Prescription", new { doctorId = doctorId });
        }
        public IActionResult Delete(int doctorId)
        {
            mDoctorMenager.DeleteDoctor(new DoctorDto { Id = doctorId });

            var doctorDtos = mDoctorMenager.GetAllDoctors(null);

            var doctorViewModels = mViewModelMapper.Map(doctorDtos);

            return View("Index",doctorViewModels);
        }

        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Add(DoctorViewModel dovtorVm)
        {
            var dto = mViewModelMapper.Map(dovtorVm);

            mDoctorMenager.AddNewDoctor(dto);

            return RedirectToAction("Index");
        }

    }
}
