// FYP.BLL.Services/ProjectService.cs
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using FYP.BLL.Interfaces;
using FYP.DAL;
using FYP.DAL.Entities;
using Microsoft.EntityFrameworkCore;

namespace FYP.BLL.Services
{
    public class ProjectService : IProjectService
    {
        private readonly ApplicationDbContext _context;

        public ProjectService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task SubmitProjectAsync(ProjectSubmission project)
        {
            _context.ProjectSubmissions.Add(project);
            await _context.SaveChangesAsync();
        }

        public async Task<List<ProjectSubmission>> GetAllSubmissionsAsync()
        {
            return await _context.ProjectSubmissions.ToListAsync();
        }

        public async Task UpdateSubmissionStatusAsync(int submissionId, string newStatus)
        {
            // Find the submission
            var submission = await _context.ProjectSubmissions.FindAsync(submissionId);
            if (submission == null)
                throw new KeyNotFoundException($"Submission with Id={submissionId} not found.");

            // Update and save
            submission.Status = newStatus;
            await _context.SaveChangesAsync();
        }
    }
}
