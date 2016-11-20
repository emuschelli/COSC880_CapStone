using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WarApp.Models
{
    public class tblER_Employee
    {
        //PRIMARY KEY
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public virtual int EmpId { get; set; }

        //FOREIGN KEY
        public virtual int RoleId { set; get; }
        public virtual int DirectorateId { get; set; }
        public virtual int DivisionId { get; set; }
        public virtual int LocationId { get; set; }
        public virtual int OrganizationalId { get; set; }
        public virtual int BranchId { get; set; }
        public virtual int ProjId { get; set; }

        //TABLE FIELDS
        public virtual string FirstName { get; set; }
        public virtual char MiddleInitial { get; set; }
        public virtual string LastName { get; set; }
        public virtual string EmailAddress { get; set; }
        public virtual bool EmpArchive { get; set; }
        public virtual bool Matrixed { get; set; }


        public virtual lutER_Role lutER_Role { get; set; }
        public virtual lutER_Location lutER_Location { get; set; }
        public virtual lutER_Organization lutER_Organization { get; set; }
        public virtual lutER_Directorate lutER_Directorate { get; set; }
        public virtual lutER_Division lutER_Division { get; set; }
        public virtual lutER_Branch lutER_Branch { get; set; }
        public virtual lutWAR_Projects lutWAR_Projects { get; set; }
    }
}