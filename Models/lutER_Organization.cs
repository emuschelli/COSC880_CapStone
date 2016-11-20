using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace WarApp.Models
{
    public class lutER_Organization
    {
        //PRIMARY KEY
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public virtual int OrganizationalId { get; set; }

        //TABLE FIELDS
        public virtual string OrganizationalName { get; set; }
    }
}