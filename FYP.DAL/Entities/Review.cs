using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FYP.DAL.Entities
{
    public class Review
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Name is required")]
        public string UserName { get; set; }      // who wrote it

        [Required(ErrorMessage = "Rating is required")]
        public int Rating { get; set; }           // e.g. 1–5
        [Required(ErrorMessage = "Comment is required")]
        public string Comment { get; set; }       // the text
        public DateTime CreatedAt { get; set; }   // timestamp
    }


}
