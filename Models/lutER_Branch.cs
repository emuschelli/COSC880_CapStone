using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WarApp.Models
{
    public class lutER_Branch
    {
        //PRIMARY KEY
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public virtual int BranchId { get; set; }

        //TABLE FIELDS
        public virtual string BranchName { get; set; }
    }
}