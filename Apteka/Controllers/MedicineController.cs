using Apteka.Core;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace Apteka.Controllers
{
    public class MedicineController : Controller
    {
        private readonly IDoctorMenager mDoctorMenager;
        private readonly ViewModelMapper mViewModelMapper;
        
        public MedicineController(IDoctorMenager doctorMenager, 
                                  ViewModelMapper viewModelMapper)
        {
            mDoctorMenager = doctorMenager;
            mViewModelMapper = viewModelMapper;
        }

        public IActionResult Index(int doctorId, int prescriptionId, string filterString)
        {
            TempData["DoctorId"] = doctorId;
            TempData["PrescriptionId"] = prescriptionId;

            var prescriptionDto = mDoctorMenager.GetAllPrescriptionForADoctor(doctorId, null)
                .FirstOrDefault(x=> x.Id == prescriptionId);
            var medicineDtos = mDoctorMenager.GetAllMedicineForAPrescription(prescriptionId, filterString);

            var prescriptionViewModels = mViewModelMapper.Map(prescriptionDto);
            prescriptionViewModels.Medicines = mViewModelMapper.Map(medicineDtos).ToList();

           

            return View(prescriptionViewModels);
        }

        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Add(MedicineViewModel medicineVm)
        {
            var dto = mViewModelMapper.Map(medicineVm);

            mDoctorMenager.AddNewMedicine(dto, int.Parse(TempData["PrescriptionId"].ToString()));

            return RedirectToAction("Index", new { doctorId = int.Parse(TempData["DoctorId"].ToString()), prescriptionId = int.Parse(TempData["PrescriptionId"].ToString()) });
        }
        public IActionResult Delete(int medicineId)
        {
            mDoctorMenager.DeleteMedicine(new MedicineDto { Id = medicineId});
            return RedirectToAction("Index", new { doctorId = int.Parse(TempData["DoctorId"].ToString()), prescriptionId = int.Parse(TempData["PrescriptionId"].ToString()) });
        }

    }
}
