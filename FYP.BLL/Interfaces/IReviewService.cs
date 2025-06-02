using FYP.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FYP.BLL.Interfaces
{
    public interface IReviewService
    {
        Task<List<Review>> GetAllAsync();
        Task<Review> GetByIdAsync(int id);
        Task<Review> CreateAsync(Review r);
        Task<Review> UpdateAsync(Review r);
        Task DeleteAsync(int id);
        Task<List<Review>> GetTopAsync(int count);
    }
}
