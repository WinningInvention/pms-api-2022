using DomainLayer.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Serviceslayer.Interfaces
{
    public interface IDischargeService
    {
        void PredictedDated(PredictedDischargeDTO patientBedId);
        void ReadyToDischarge(ReadyToDischargeDto outlierOut);
        void FinalDischarge(PatientDischargeDto patientDischargeDto);
        List<DischargeListDto> GetPatientDischargeList();
        void InsertDischargeComment(DischargeCommentDto dischargeCommentDto);
        IEnumerable<DischargeCommentDto> GetDischargeCommentById(int dischargeId);
        List<PredictedDischargeListDto> PredictedDischargeList();

        List<ReadyDischargeListDto> ReadyDischargeList();
    }
}
