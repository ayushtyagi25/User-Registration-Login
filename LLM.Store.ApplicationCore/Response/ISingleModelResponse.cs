using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LLM.Store.ApplicationCore.Response
{
    public interface ISingleModelResponse<T> : IResponse, IDisposable
    {
        T Model { get; set; }

    }
}
