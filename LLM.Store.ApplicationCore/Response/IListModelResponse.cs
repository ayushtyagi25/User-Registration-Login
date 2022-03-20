using LLM.Store.ApplicationCore.Response;
using System.Collections.Generic;

namespace LLM.Operator.API.Responses
{
    public interface IListModelResponse<T>: IResponse
    {
        IEnumerable<T> Model { get; set; }
    }
}
