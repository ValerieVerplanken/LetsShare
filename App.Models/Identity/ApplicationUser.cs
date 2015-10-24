using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity.EntityFramework;

namespace App.Models.Identity
{
    public class ApplicationUser : IdentityUser
    {   
        public string Description { get; set; }
		public DateTime CreatedAt { get; set; }
		public Nullable<DateTime> UpdatedAt { get; set; }
		public Nullable<DateTime> DeletedAt { get; set; }  
        
        /* Virtual or Navigation Properties */
        public virtual ICollection<Groups> Groups { get; set; } 
    }
}
