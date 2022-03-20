using LLM.Store.ApplicationCore.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LLM.Store.ApplicationCore.Interfaces.Dal
{
    public interface IStoreData
    {
        Task<TblStore> AddStore(TblStore entity);
        Task<TblStore> UpdateStore(int storeId);
        Task<TblStore> GetStore(int storeId);
        Task<List<TblStore>> StoreList(int pageIndex, int PageSize, TblStore entity);

        Task<TblStore> DeleteStore(int storeId);
    }
}
