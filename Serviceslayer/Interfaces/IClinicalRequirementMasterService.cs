using DomainLayer.DTO;
using DomainLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Serviceslayer.Interfaces
{
    public interface IClinicalRequirementMasterService
    {
        void InsertClinicalRequirement(ClinicalRequirementMasterDto clinicalRequirementMasterDto);
        IEnumerable<ClinicalRequirementMaster> GetClinicalRequirement();
        void AddUpdateClinicalRequirement(AddClinicalRequirementsDto addClinicalRequirementsDto);
    }
}
