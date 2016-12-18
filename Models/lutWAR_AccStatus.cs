using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace WarApp.Models
{
    //use the authorize attribute to require login
    [System.Web.Mvc.Authorize]
    public class lutWAR_AccStatus
    {
        //PRIMARY KEY
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public virtual int AccStatusId { get; set; }

        //TABLE FIELDS
        public virtual string Status { get; set; }
    }
}