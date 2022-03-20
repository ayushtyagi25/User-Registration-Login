using AutoMapper;
using LLM.Store.ApplicationCore.Entities;
using LLM.Store.ApplicationCore.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LLM.Store.BAL.MappingProfile
{
    class StoreProfile: Profile
    {
        public StoreProfile()
        {
            CreateMap<RequestViewModel,TblStore>();
            CreateMap<StoreListRequestViewModel, TblStore>();
            CreateMap<AddRequestViewModel, TblStore>();
            CreateMap<TblStore,ResponseViewModel>();
            CreateMap<TblStore, AddResponseViewModel>();
            CreateMap<TblStore, GetResponseViewModel>();
            CreateMap<TblStore, UpdateResponseViewModel>();
        }
    }
}
