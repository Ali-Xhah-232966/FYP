using FYP.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FYP.BLL.Interfaces
{
    public interface IUserService
    {
        Task<AppUser?> GetUserByEmailAsync(string email);
        Task<List<ProjectSubmission>> GetUserSubmissionsAsync(string email);
    }

}
