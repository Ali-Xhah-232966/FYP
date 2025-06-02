using FYP.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FYP.BLL.Interfaces
{
    public interface IAdminDashboardService
    {
        Task<AppUser?> GetAdminProfileAsync();
        Task<List<ContactUs>> GetAllContactMessagesAsync();
        Task<List<ProjectSubmission>> GetAllProjectSubmissionsAsync();
    }
}
