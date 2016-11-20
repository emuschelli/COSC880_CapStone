using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace WarApp.Models
{
    public class lutER_Role
    {
        //PRIMARY KEY
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public virtual int RoleId { set; get; }

        //TABLE FIELDS
        public virtual string RoleType { set; get; }
    }
}