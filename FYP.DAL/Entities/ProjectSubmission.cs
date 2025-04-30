using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


using System.ComponentModel.DataAnnotations;

namespace FYP.DAL.Entities
{
    public class ProjectSubmission
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public ServiceType ServiceType { get; set; }

        // Common Fields
        [Required]
        public string Address { get; set; }
        public DateTime BookingDate { get; set; }

        // Solar Specific
        public decimal? KwSize { get; set; }

        // Electrical/Repair
        public ProjectType? ProjectType { get; set; }
        public List<string> SelectedServices { get; set; } = new();

        // Contact Info
        [Required]
        public string ContactName { get; set; }
        [EmailAddress]
        public string ContactEmail { get; set; }
        [Phone]
        public string ContactPhone { get; set; }
        public string Status { get; set; } = "Pending";
    }

    public enum ServiceType { Solar, Electrical, Repair }
    public enum ProjectType { Domestic, Commercial }


}