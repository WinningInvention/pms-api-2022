using AutoMapper;
using DomainLayer.DTO;
using DomainLayer.EntityMapper;
using DomainLayer.Models;

namespace Serviceslayer
{
    public class AutoMapperProfile:Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<AllocatePatientBedDto, PatientBed>().ReverseMap(); //reverse so the both direction
            CreateMap<AllZoneForBedDto, Zone>().ReverseMap(); //reverse so the both direction
            CreateMap<CreateCommentDto, ReferalComment>().ReverseMap();
            CreateMap<CommentListDto, ReferalComment>().ReverseMap();
            CreateMap<NurseAvailabilityDto, NurseAvailability>().ReverseMap();
            CreateMap<UpdateNurseAvailablityDto, NurseAvailability>().ReverseMap();
            CreateMap<ZoneBedBirdViewDto, Zone>().ReverseMap();
            CreateMap<OutlierQueueInCommentDto, OutlierQueueInComment>().ReverseMap();
            CreateMap<DischargeCommentDto, DischargeComment>().ReverseMap();
            CreateMap<OutlierOutQueueCommentDto, OutlierOutQueueComment>().ReverseMap();
            CreateMap<ClinicalRequirementMasterDto, ClinicalRequirementMaster>().ReverseMap();
            CreateMap<InfectionControlInsertDto, InfectionControlMaster>().ReverseMap();
            CreateMap<InfectionListDto, InfectionControlMaster>().ReverseMap();
        }
    }
}
