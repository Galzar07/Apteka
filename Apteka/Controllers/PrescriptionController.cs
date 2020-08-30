using Apteka.Core;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace Apteka.Controllers
{
    public class PrescriptionController : Controller
    {

        private readonly IDoctorMenager mDoctorMenager;

        private readonly ViewModelMapper mViewModelMapper;

        

        public PrescriptionController(IDoctorMenager doctorMenager,
                                  ViewModelMapper viewModelMapper)
        {
            mDoctorMenager = doctorMenager;
            mViewModelMapper = viewModelMapper;
        }

        public IActionResult Index(int doctorId,string filterString)
        {
            TempData["DoctorId"] = doctorId;


            var doctorDto = mDoctorMenager.GetAllDoctors(null)
                .FirstOrDefault(x => x.Id == doctorId);

            var prescriptionDtos = mDoctorMenager.GetAllPrescriptionForADoctor(doctorId, filterString);

            var doctorViewModels = mViewModelMapper.Map(doctorDto);
            doctorViewModels.Prescriptions = mViewModelMapper.Map(prescriptionDtos).ToList();



            return View(doctorViewModels);
        }
        public IActionResult View(int prescriptionId)
        {
            return RedirectToAction("Index", "Medicine",new { doctorId = int.Parse(TempData["DoctorId"].ToString()), prescriptionId = prescriptionId });
        }


        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Add(PrescriptionViewModel prescriptionVm)
        {
            var dto = mViewModelMapper.Map(prescriptionVm);

            mDoctorMenager.AddNewPrescription(dto, int.Parse(TempData["DoctorId"].ToString()));

            return RedirectToAction("Index", new { doctorId = int.Parse(TempData["DoctorId"].ToString()) });
        }


        public IActionResult Delete(int presciptionId)
        {
            mDoctorMenager.DeletePrescription(new PrescriptionDto { Id = presciptionId });
            return RedirectToAction("Index", new { doctorId = int.Parse(TempData["DoctorId"].ToString()) });
        }


    }
}
