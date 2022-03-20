using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LLM.Store.ApplicationCore.ViewModels
{
    public class InvalidLogin
    {
        public string IP { get; set; }
        public DateTime Attempttime { get; set; }
        public int AttemptCount { get; set; }
    }
}
