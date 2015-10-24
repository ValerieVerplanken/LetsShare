using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNet.Mvc;
using App.Data;
using App.Models;
using App.Services;

namespace App.API.Controllers
{    
    public abstract class CommonController : Controller
    {
        [FromServices]
        public LetsShareDbContext _libraryContext { get; set; }
        
    }
}
