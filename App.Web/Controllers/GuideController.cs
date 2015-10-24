using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNet.Mvc;
using Microsoft.Data.Entity;
using Microsoft.Data.Entity.Infrastructure;
using App.Models;
using App.Data;

namespace App.Web.Controllers
{
    public class GuideController : CommonController
    {
        public IActionResult Index()
        {
            var models = _letsshareContext.Guides.AsEnumerable();
            return View(models);
        }
        
        public IActionResult Details(int? id)
        {
            if(id == null)
            {
                return new HttpStatusCodeResult(400);    
            }
            
            var model = _letsshareContext.Guides.FirstOrDefault(c => c.Id == id);
            if(model == null)
            {
                return RedirectToAction("Index");
            }
            return View(model);
        }
    }
}
