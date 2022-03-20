using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LLM.Store.ApplicationCore.Response
{
    public interface IResponse
    {
        String Message { get; set; }
        Boolean IsError { get; set; }
        String ErrorMessage { get; set; }
        String Token { get; set; }
        int TotalRecord { get; set; }
    }
}
