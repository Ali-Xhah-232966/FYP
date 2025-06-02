using FYP.BLL.Interfaces;
using FYP.DAL.Entities;
using FYP.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace FYP.BLL.Services
{
    public class UserService : IUserService
    {
        private readonly ApplicationDbContext _context;

        public UserService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<AppUser?> GetUserByEmailAsync(string email)
        {
            return await _context.GoogleUsers.FirstOrDefaultAsync(u => u.Email == email);
        }

        public async Task<List<ProjectSubmission>> GetUserSubmissionsAsync(string email)
        {
            return await _context.ProjectSubmissions
                .Where(p => p.ContactEmail == email) // Ensure this column exists
                .ToListAsync();
        }
    }
}
