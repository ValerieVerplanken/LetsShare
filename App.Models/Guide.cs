using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using App.Models.Identity;

namespace App.Models
{
    public class Guide : Item
    {
        public Guide() : base()
        {
            
        }
        
        public Int32 Id { get; set; } 
		
		public string Offers { get; set; }
		
		public string Requests { get; set; }
  
    }
}
