using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using AssetTrackingSystem.Models;

namespace AssetTrackingSystem.Context
{
    public class AssetTrackingSystemDBContext:DbContext
    {
        public DbSet<Organization> Organizations { get; set; }
    }
}