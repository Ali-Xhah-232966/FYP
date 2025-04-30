using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FYP.BLL.Interfaces;
using FYP.DAL;
using FYP.DAL.Entities;
using Microsoft.EntityFrameworkCore; // 📢 Needed for ToListAsync()

namespace FYP.BLL.Services
{
    public class ContactUsService : IContactUsService
    {
        private readonly ApplicationDbContext _dbContext;

        public ContactUsService(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task SaveContactFormAsync(ContactUs contact)
        {
            _dbContext.ContactUsMessages.Add(contact);
            await _dbContext.SaveChangesAsync();
        }
        public async Task<IEnumerable<FYP.DAL.Entities.ContactUs>> GetAllContactFormsAsync()
        {
            return await _dbContext.ContactUsMessages
                .OrderByDescending(m => m.SubmittedAt)
                .ToListAsync();
        }

        public async Task DeleteContactFormAsync(int id)
        {
            var message = await _dbContext.ContactUsMessages.FindAsync(id);
            if (message != null)
            {
                _dbContext.ContactUsMessages.Remove(message);
                await _dbContext.SaveChangesAsync();
            }
        }
    }
}
