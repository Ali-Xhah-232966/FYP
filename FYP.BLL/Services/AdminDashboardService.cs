using FYP.BLL.Interfaces;
using FYP.DAL.Entities;
using FYP.DAL;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;

namespace FYP.BLL.Services
{
    public class AdminDashboardService : IAdminDashboardService
    {
        private readonly ApplicationDbContext _context;

        public AdminDashboardService(ApplicationDbContext context)
        {
            _context = context;
        }

        // Fetch the first admin user (adjust logic as needed for your app)
        public async Task<AppUser?> GetAdminProfileAsync()
        {
            return await _context.GoogleUsers
                .Where(u => u.Role == "Admin" || u.Role == "Super Administrator")
                .FirstOrDefaultAsync();
        }

        public async Task<List<ContactUs>> GetAllContactMessagesAsync()
        {
            return await _context.ContactUsMessages.ToListAsync();
        }

        public async Task<List<ProjectSubmission>> GetAllProjectSubmissionsAsync()
        {
            return await _context.ProjectSubmissions.ToListAsync();
        }
    }
}
