// FYP.BLL/Services/ReviewService.cs
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FYP.BLL.Interfaces;
using FYP.DAL;
using FYP.DAL.Entities;

public class ReviewService : IReviewService
{
    private readonly ApplicationDbContext _db;
    public ReviewService(ApplicationDbContext db) => _db = db;

    public async Task<List<Review>> GetAllAsync() =>
        await _db.Reviews
                 .AsNoTracking()
                 .OrderByDescending(r => r.CreatedAt)
                 .ToListAsync();

    public async Task<Review> GetByIdAsync(int id) =>
        await _db.Reviews.FindAsync(id)
            ?? throw new KeyNotFoundException($"Review {id} not found.");

    public async Task<Review> CreateAsync(Review r)
    {
        r.CreatedAt = DateTime.UtcNow;
        _db.Reviews.Add(r);
        await _db.SaveChangesAsync();
        return r;
    }

    public async Task<Review> UpdateAsync(Review r)
    {
        var existing = await _db.Reviews.FindAsync(r.Id)
                       ?? throw new KeyNotFoundException($"Review {r.Id} not found.");

        existing.UserName = r.UserName;
        existing.Rating = r.Rating;
        existing.Comment = r.Comment;
        // leave CreatedAt unchanged

        await _db.SaveChangesAsync();
        return existing;
    }

    public async Task DeleteAsync(int id)
    {
        var review = await _db.Reviews.FindAsync(id);
        if (review != null)
        {
            _db.Reviews.Remove(review);
            await _db.SaveChangesAsync();
        }
    }

    // ← new: top N by rating, then most recent
    public async Task<List<Review>> GetTopAsync(int count) =>
        await _db.Reviews
                 .AsNoTracking()
                 .OrderByDescending(r => r.Rating)
                 .ThenByDescending(r => r.CreatedAt)
                 .Take(count)
                 .ToListAsync();
}
