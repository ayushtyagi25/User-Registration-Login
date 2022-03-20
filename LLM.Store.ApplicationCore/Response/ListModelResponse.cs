using System.Collections.Generic;

namespace LLM.Operator.API.Responses
{
    public class ListModelResponse<T>: IListModelResponse<T>
    {
        public bool IsError { get; set; }
        public string ErrorMessage { get; set; }
        public string Message { get; set; }
        public string Token { get; set; }
        public int TotalRecord { get; set; }
        public IEnumerable<T> Model { get; set; }
    }
}
