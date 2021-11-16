using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TeamsChat.TimeoutService.Models
{
    public class TimeoutReturnModel<TResult>
    {
        public TResult Output { get; set; }
        public bool HasTimeOut { get; set; }
    }
}
