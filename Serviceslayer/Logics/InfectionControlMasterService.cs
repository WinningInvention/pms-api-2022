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
    public class InfectionControlMasterService: IInfectionControlMasterService
    {
        private IRepositoryModified<InfectionControlMaster> _infectionControlMasterRepository;
        private readonly IMapper _mapper;

        public InfectionControlMasterService(IRepositoryModified<InfectionControlMaster> infectionControlMasterRepository, IMapper mapper)
        {
            _infectionControlMasterRepository = infectionControlMasterRepository;
            _mapper = mapper;
        }
        public void InsertInfectionControl(InfectionControlInsertDto infectionControlInsertDto)
        {
            InfectionControlMaster infectionControlMaster = _mapper.Map<InfectionControlMaster>(infectionControlInsertDto);
            _infectionControlMasterRepository.Insert(infectionControlMaster);
        }
        public IList<InfectionListDto> GetInfectionControlList()
        {
            var lst = _infectionControlMasterRepository.GetAll();
            List<InfectionListDto> infections = _mapper.Map<List<InfectionListDto>>(lst);
            return infections;
           
        }
    }
}
