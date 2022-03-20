using AutoMapper;
using LLM.Store.ApplicationCore.Entities;
using LLM.Store.ApplicationCore.Interfaces.Bal;
using LLM.Store.ApplicationCore.Interfaces.Dal;
using LLM.Store.ApplicationCore.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LLM.Store.BAL
{
    public class StoreRepo : IStoreRepo
    {
        private readonly IStoreData _storeData;
        private readonly IMapper _mapper;

        public StoreRepo(IStoreData storeData, IMapper mapper)
        {
            _storeData = storeData;
            _mapper = mapper;

        }
        public async Task<AddResponseViewModel> AddStore(AddRequestViewModel entity)
        {

            TblStore obj = await _storeData.AddStore(_mapper.Map<TblStore>(entity));
            return _mapper.Map<AddResponseViewModel>(obj);
        }

        public async Task<ResponseViewModel> DeleteStore(int storeId)
        {

            TblStore obj = await _storeData.DeleteStore(storeId);
            return _mapper.Map<ResponseViewModel>(obj);
        }

        public async Task<GetResponseViewModel> GetStore(int storeId)
        {
            TblStore obj = await _storeData.GetStore(storeId);
            return _mapper.Map<GetResponseViewModel>(obj);
        }

        public async Task<List<GetResponseViewModel>> StoreList(int pageIndex, int pageSize, StoreListRequestViewModel entity)
        {

            List<TblStore> obj = await _storeData.StoreList(pageIndex,pageSize, _mapper.Map<TblStore>(entity));
            return _mapper.Map<List<GetResponseViewModel>>(obj);
        }

        public async Task<UpdateResponseViewModel> UpdateStore(int storeId)
        {

            TblStore obj = await _storeData.UpdateStore(storeId);
            return _mapper.Map<UpdateResponseViewModel>(obj);
        }
    }
}
