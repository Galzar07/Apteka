using Apteka.Core;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;

namespace Apteka
{
    public class ViewModelMapper
    {
        private IMapper mapper;

        public ViewModelMapper()
        {
            mapper = new MapperConfiguration(config =>
            {
                config.CreateMap<MedicineDto, MedicineViewModel>()
                .ReverseMap();
                config.CreateMap<PrescriptionDto, PrescriptionViewModel>().ReverseMap();
                config.CreateMap<DoctorDto, DoctorViewModel>().ReverseMap();
            }).CreateMapper();
        }

        #region Medicine Map
        public MedicineViewModel Map(MedicineDto medicine)
                => mapper.Map<MedicineViewModel>(medicine);

        public List<MedicineViewModel> Map(List<MedicineDto> medicines)
                => mapper.Map<List<MedicineViewModel>>(medicines);

        public MedicineDto Map(MedicineViewModel medicine)
                => mapper.Map<MedicineDto>(medicine);

        public List<MedicineDto> Map(List<MedicineViewModel> medicines)
                => mapper.Map<List<MedicineDto>>(medicines);

        #endregion

        #region Prescription Map
        public PrescriptionViewModel Map(PrescriptionDto prescription)
                => mapper.Map<PrescriptionViewModel>(prescription);

        public List<PrescriptionViewModel> Map(List<PrescriptionDto> prescriptions)
                => mapper.Map<List<PrescriptionViewModel>>(prescriptions);

        public PrescriptionDto Map(PrescriptionViewModel prescription)
                => mapper.Map<PrescriptionDto>(prescription);

        public List<PrescriptionDto> Map(List<PrescriptionViewModel> prescriptions)
                => mapper.Map<List<PrescriptionDto>>(prescriptions);

        #endregion

        #region Doctor Map
        public DoctorViewModel Map(DoctorDto doctor)
                => mapper.Map<DoctorViewModel>(doctor);

        public List<DoctorViewModel> Map(List<DoctorDto> doctors)
                => mapper.Map<List<DoctorViewModel>>(doctors);

        public DoctorDto Map(DoctorViewModel doctor)
                => mapper.Map<DoctorDto>(doctor);

        public List<DoctorDto> Map(List<DoctorViewModel> doctors)
                => mapper.Map<List<DoctorDto>>(doctors);

        #endregion
    }
}
