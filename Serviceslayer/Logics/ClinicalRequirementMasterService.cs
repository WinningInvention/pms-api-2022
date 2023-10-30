using AutoMapper;
using DomainLayer.DTO;
using DomainLayer.Models;
using RepositoryLayer.Interfaces;
using Serviceslayer.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Serviceslayer.Logics
{
    public class ClinicalRequirementMasterService: IClinicalRequirementMasterService
    {
        private IRepositoryModified<ClinicalRequirementMaster> _clinicalRequirementMasterRepository;
        private IRepositoryModified<PatientBed> _patientBedrepository;
        private readonly IMapper _mapper;

        public ClinicalRequirementMasterService(IRepositoryModified<ClinicalRequirementMaster> clinicalRequirementMasterRepository,IRepositoryModified<PatientBed> patientBedrepository, IMapper mapper)
        {
            _clinicalRequirementMasterRepository = clinicalRequirementMasterRepository;
            _patientBedrepository = patientBedrepository;
            _mapper = mapper;
        }
        public void InsertClinicalRequirement(ClinicalRequirementMasterDto clinicalRequirementMasterDto)
        {
            ClinicalRequirementMaster clinicalRequirementMaster = _mapper.Map<ClinicalRequirementMaster>(clinicalRequirementMasterDto);
            _clinicalRequirementMasterRepository.Insert(clinicalRequirementMaster);
        }

        public IEnumerable<ClinicalRequirementMaster> GetClinicalRequirement()
        {
            var clinicalRequirement = _clinicalRequirementMasterRepository.GetAll();
            return clinicalRequirement;
        }
        public void AddUpdateClinicalRequirement(AddClinicalRequirementsDto addClinicalRequirementsDto)
        {
            var patientBed = _patientBedrepository.Get(x => x.PatientBedId == addClinicalRequirementsDto.PatientBedId);
            patientBed.ClinicalRequirements = addClinicalRequirementsDto.ClinicalRequirements;
            _patientBedrepository.Update(patientBed);
        }
    }
}
