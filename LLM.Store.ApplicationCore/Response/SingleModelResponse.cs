using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LLM.Store.ApplicationCore.Response
{
    public class SingleModelResponse <T> : ISingleModelResponse<T>, IDisposable
    {
        public bool IsError { get; set; }
        public string ErrorMessage { get; set; }
        public string Message { get; set; }
        public long Timestamp { get; set; }
        public string Token { get; set; }
        public int TotalRecord { get; set; }
        public T Model { get; set; }

        public void Dispose()
        {
            throw new NotImplementedException();
        }
    }
}
