using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Capstone.Contracts
{
    public interface ISmsService
    {
        Task SendSMS(string receiver, string reminder);
    }
}
