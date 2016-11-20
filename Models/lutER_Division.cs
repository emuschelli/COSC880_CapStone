using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WarApp.Models
{
    public class lutER_Division
    {
        //PRIMARY KEY
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public virtual int DivisionId { get; set; }

        //TABLE FIELDS
        public virtual string DivisionName { get; set; }
    }
}