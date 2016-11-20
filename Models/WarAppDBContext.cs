using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Web;

namespace WarApp.Models
{
    public class WarAppDBContext : DbContext
    {
        // You can add custom code to this file. Changes will not be overwritten.
        // 
        // If you want Entity Framework to drop and regenerate your database
        // automatically whenever you change your model schema, please use data migrations.
        // For more information refer to the documentation:
        // http://msdn.microsoft.com/en-us/data/jj591621.aspx
    
        public WarAppDBContext() : base("name=WarAppDBContext")
        {
        }

        public System.Data.Entity.DbSet<WarApp.Models.lutER_Branch> lutER_Branch { get; set; }

        public System.Data.Entity.DbSet<WarApp.Models.lutER_Directorate> lutER_Directorate { get; set; }

        public System.Data.Entity.DbSet<WarApp.Models.lutER_Division> lutER_Division { get; set; }

        public System.Data.Entity.DbSet<WarApp.Models.lutER_Location> lutER_Location { get; set; }

        public System.Data.Entity.DbSet<WarApp.Models.lutER_Organization> lutER_Organization { get; set; }

        public System.Data.Entity.DbSet<WarApp.Models.lutER_Role> lutER_Role { get; set; }

        public System.Data.Entity.DbSet<WarApp.Models.lutWAR_AccStatus> lutWAR_AccStatus { get; set; }

        public System.Data.Entity.DbSet<WarApp.Models.lutWAR_Projects> lutWAR_Projects { get; set; }

        public System.Data.Entity.DbSet<WarApp.Models.tblER_Employee> tblER_Employee { get; set; }

        public System.Data.Entity.DbSet<WarApp.Models.tblWAR_Accomplishments> tblWAR_Accomplishments { get; set; }

        //Foreign Key Constraints may cause multiple cycles or cascading paths.  
        //To correct this issue, the following method was added.
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            //remove all CASCADE DELETES by adding this
            modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();
        }
    }
}
