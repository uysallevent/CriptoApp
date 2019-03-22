using System;
using System.Collections.Generic;
using System.Text;

namespace CriptoApp.Models
{
   public class BaseModel
    {
        public BaseModel()
        {
            Crated = DateTime.Now;
        }
        public int Id { get; set; }

        public int? IsDeleted { get; set; }

        public DateTime? Crated { get; set; }

        public DateTime? Update { get; set; }

        public DateTime? Delete { get; set; }
    }
}
