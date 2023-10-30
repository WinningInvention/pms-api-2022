using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainLayer.DTO
{
    public class DashboardDto
    {
       public List<OccupyVacantBedDto> OccupyVacantBedDtoList { get; set; }    
       public List<L2L3PateintCountDto> L2L3PateintCountDtoList { get; set; }

        public List<TotalNurseRequiredListDto> lstTotalNurseRequiredListDto { get; set; }

        public int[] OccupiedArray { get; set; }
        public int[] VaccantArray { get; set; }
        public string[] ZoneName { get; set; }
        public int[] NurseAvailable { get; set; }
        public int[] NurseRequired { get; set; }
        public int[] L2PatientCount { get; set; }
        public int[] L3PatientCount { get; set; }       
        public int NurseCount { get; set; }
        public int ZoneCount { get; set; }
        public int ReferalCount { get; set; }
        public int TotalL2Patient { get; set; }
        public int TotalL3Patient { get; set; }
        public int DischargeCount { get; set; }
        public int CardiffCount { get; set; }
        public int NonCardfiffCount { get; set; }
        public int SpecialistCount { get; set; }
        public int NonSpecialistCount { get; set; }
    }
    public class OccupyVacantBedDto
    {
        public int ZoneId { get; set; }
        public string ZoneName { get; set; }
        public int OccupiedBed { get; set; }
        public int VaccantBed { get; set; }

    }

    public class L2L3PateintCountDto
    {
        public int L2PatientCount { get; set; }
        public int L3PatientCount { get; set; }
        public DateTime Date { get; set; }
    }
}
