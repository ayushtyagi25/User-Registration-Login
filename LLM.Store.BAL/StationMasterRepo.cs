using AutoMapper;
using LLM.Store.ApplicationCore.Entities;
using LLM.Store.ApplicationCore.Interfaces.Bal;
using LLM.Store.ApplicationCore.Interfaces.Dal;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace LLM.Store.BAL
{
    public class StationMasterRepo : IStationMasterRepo
    {
         
        private readonly IStationMasterData _StationMasterData;
        private readonly IMapper _mapper;
        public StationMasterRepo(IStationMasterData StationMasterData, IMapper mapper)
        {
            _StationMasterData = StationMasterData;
            _mapper = mapper;
        }
        public async Task<CreateStationMasterResponse> CreateStationMaster(CreateStationMasterRequest entity,Token TokenInfo)
        {
            CreateStationMasterResponse obj = await _StationMasterData.CreateStationMaster(entity, TokenInfo);
            return _mapper.Map<CreateStationMasterResponse>(obj);

        }
        public async Task<UpdateStationMasterResponse> UpdateStationMaster(UpdateStationMasterRequest entity)
        {
            UpdateStationMasterResponse obj = await _StationMasterData.UpdateStationMaster(entity);
            return _mapper.Map<UpdateStationMasterResponse>(obj);

        }
        
        public async Task<DetailStationMasterResponse> GetDetailsStationMaster(string station_code)
        {
            DetailStationMasterResponse obj = await _StationMasterData.GetDetailsStationMaster(station_code);
            return _mapper.Map<DetailStationMasterResponse>(obj);

        }

        public async Task<(int, List<ListStationMasterResponse>)> ListStationMaster(int pageIndex, int pageSize, ListStationMasterRequest entity)
        {

            (int TotalCount, List<ListStationMasterResponse> result) = await _StationMasterData.ListStationMaster(pageIndex, pageSize, entity);
            return (TotalCount, result);
        }
    }
}
