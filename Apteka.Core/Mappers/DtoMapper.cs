using Apteka.Database.Entities;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;

namespace Apteka.Core.Mappers
{
    public class DtoMapper
    {
        private IMapper mapper;

        public DtoMapper()
        {
            mapper = new MapperConfiguration(config =>
            {
                config.CreateMap<Medicine, MedicineDto>()
                .ForMember(x=> x.PriceInTotal, opt => opt.MapFrom(y => y.Price * y.Amount))
                .ReverseMap();
                config.CreateMap<Prescription, PrescriptionDto>().ReverseMap();
                config.CreateMap<Doctor, DoctorDto>().ReverseMap();
            }).CreateMapper();
        }

        #region Medicine Map
        public MedicineDto Map(Medicine medicine) 
                => mapper.Map<MedicineDto>(medicine);

        public List<MedicineDto> Map(List<Medicine> medicines)
                => mapper.Map<List<MedicineDto>>(medicines);

        public Medicine Map(MedicineDto medicine)
                => mapper.Map<Medicine>(medicine);

        public List<Medicine> Map(List<MedicineDto> medicines)
                => mapper.Map<List<Medicine>>(medicines);

        #endregion

        #region Prescription Map
        public PrescriptionDto Map(Prescription prescription)
                => mapper.Map<PrescriptionDto>(prescription);

        public List<PrescriptionDto> Map(List<Prescription> prescriptions)
                => mapper.Map<List<PrescriptionDto>>(prescriptions);

        public Prescription Map(PrescriptionDto prescription)
                => mapper.Map<Prescription>(prescription);

        public List<Prescription> Map(List<PrescriptionDto> prescriptions)
                => mapper.Map<List<Prescription>>(prescriptions);

        #endregion

        #region Doctor Map
        public DoctorDto Map(Doctor doctor)
                => mapper.Map<DoctorDto>(doctor);

        public List<DoctorDto> Map(List<Doctor> doctors)
                => mapper.Map<List<DoctorDto>>(doctors);

        public Doctor Map(DoctorDto doctor)
                => mapper.Map<Doctor>(doctor);

        public List<Doctor> Map(List<DoctorDto> doctors)
                => mapper.Map<List<Doctor>>(doctors);

        #endregion
    }
}
