using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using App.Data;
using App.Models;

namespace App.Data.SampleData
{
    public class LetsShareSampleData
    {
        private readonly LetsShareDbContext _context;
        
        public LetsShareSampleData(LetsShareDbContext context)
        {
            _context = context;
        }
        
        public void InitializeData() 
        {
            CreateGroups();
        }
        
        private void CreateGroups() 
        {
            if(_context.Groups == null || _context.Groups.Count() == 0)
            {
                _context.Groups.Add(new Groups()
                {
                    GroupName = "De Voetballers",
                    Offers = "Koken",
                    Requests = "Kapper"
                });
                
                
                _context.SaveChanges();
            }
        }
        private void CreateGuide() 
        {
            if(_context.Guides == null || _context.Guides.Count() == 0)
            {
                _context.Guides.Add(new Guide()
                {
                    Offers = "Koken",
                    Requests = "Kapper"
                });
                
                
                _context.SaveChanges();
            }
        }
        
    }
}
