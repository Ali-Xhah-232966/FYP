using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FYP.BLL.Interfaces
{

    public interface IChatService
    {
        Task<string> GetResponseAsync(string input);
    }
}
