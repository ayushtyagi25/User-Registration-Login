using LLM.Store.ApplicationCore.Entities;
using LLM.Store.ApplicationCore.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LLM.Store.ApplicationCore.Interfaces.Bal
{
    public interface IStoreRepo
    {

        Task<AddResponseViewModel> AddStore(AddRequestViewModel entity);
        Task<UpdateResponseViewModel> UpdateStore(int storeId);
        Task<GetResponseViewModel> GetStore(int storeId);
        Task<List<GetResponseViewModel>> StoreList(int pageIndex, int pageSize, StoreListRequestViewModel entity);

        Task<ResponseViewModel> DeleteStore(int storeId);
    }
}
