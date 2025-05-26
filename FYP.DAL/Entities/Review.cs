using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FYP.DAL.Entities
{
    public class Review
    {
        public int Id { get; set; }
        public string UserName { get; set; }      // who wrote it
        public int Rating { get; set; }           // e.g. 1–5
        public string Comment { get; set; }       // the text
        public DateTime CreatedAt { get; set; }   // timestamp
    }


}
