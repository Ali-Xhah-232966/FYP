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
    public class BlogService : IBlogService
    {
        private readonly ApplicationDbContext _ctx;
        public BlogService(ApplicationDbContext ctx) => _ctx = ctx;

        public Task<List<Blog>> GetAllAsync() =>
            _ctx.Blogs
                .OrderByDescending(b => b.CreatedAt)
                .ToListAsync();

        public Task<Blog> GetByIdAsync(int id) =>
            _ctx.Blogs.FindAsync(id).AsTask();

        public async Task<Blog> CreateAsync(Blog blog)
        {
            blog.CreatedAt = DateTime.UtcNow;
            _ctx.Blogs.Add(blog);
            await _ctx.SaveChangesAsync();
            return blog;
        }

        public async Task UpdateAsync(Blog blog)
        {
            _ctx.Blogs.Update(blog);
            await _ctx.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var b = await _ctx.Blogs.FindAsync(id);
            if (b != null)
            {
                _ctx.Blogs.Remove(b);
                await _ctx.SaveChangesAsync();
            }
        }
    }
}
