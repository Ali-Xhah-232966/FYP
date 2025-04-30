using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FYP.DAL.Entities;

namespace FYP.BLL.Interfaces
{
    public interface IProjectService
    {
        Task SubmitProjectAsync(ProjectSubmission project);
        Task<List<ProjectSubmission>> GetAllSubmissionsAsync();
        Task UpdateSubmissionStatusAsync(int submissionId, string newStatus);

    }
}

