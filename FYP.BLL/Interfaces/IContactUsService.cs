using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FYP.DAL.Entities;

namespace FYP.BLL.Interfaces
{
    public interface IContactUsService
    {
        Task SaveContactFormAsync(ContactUs contact);
      
        Task<IEnumerable<ContactUs>> GetAllContactFormsAsync();
        Task DeleteContactFormAsync(int id);

    }
}
