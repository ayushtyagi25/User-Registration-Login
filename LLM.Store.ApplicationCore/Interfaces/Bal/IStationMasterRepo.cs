using LLM.Store.ApplicationCore.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace LLM.Store.ApplicationCore.Interfaces.Bal
{
    public interface IStationMasterRepo
    {
        Task<CreateStationMasterResponse> CreateStationMaster(CreateStationMasterRequest entity, Token TokenInfo);
        Task<UpdateStationMasterResponse> UpdateStationMaster(UpdateStationMasterRequest entity);
        Task<DetailStationMasterResponse> GetDetailsStationMaster(string station_code);
        Task<(int, List<ListStationMasterResponse>)> ListStationMaster(int pageIndex, int pageSize, ListStationMasterRequest entity);

        }
    }
