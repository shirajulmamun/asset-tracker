using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.UI.WebControls;
using AssetTrackingSystem.Context;
using AssetTrackingSystem.Models;

namespace AssetTrackingSystem.Controllers
{
    public class OrganizationController : Controller
    {
        AssetTrackingSystemDBContext db = new AssetTrackingSystemDBContext();
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ViewResult Create(Organization organization)
        {
            if (ModelState.IsValid)
            {
               
                db.Organizations.Add(organization);
                
                int rowAffected = db.SaveChanges();

                if (rowAffected>0)
                {
                    ViewBag.Message = "Saved Successfully!";
                }
            }
            
            return View(organization);
        }

        public ActionResult Search()
        {
            var organizations = GetAllOrganizations();
            return View(organizations);
        }

        [HttpPost]
        public ActionResult Search(string code)
        {
            var organizations = GetAllOrganizations();
            return View(organizations);
        }
        private List<Organization> GetAllOrganizations()
        {
            var organizations = db.Organizations.ToList();
            return organizations;

        }

        public List<Organization> GetOrganizationBySearchCriteria(OrganizationSearchCriteria searchCriteria)
        {
            var organizations = db.Organizations.AsQueryable();

            organizations = (organizations
               .Where(o => o.ShortName.Contains(searchCriteria.Code))
               .OrderBy(o => o.Name));

            return organizations.ToList();

        }
        
	}
}