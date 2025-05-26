using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
namespace GESTION.model
{
    public class Privilege
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IdPrivilege{get;set;}

        [Required(ErrorMessage="Name privilege is required qnd cannot be empty")]
        public string PrivilegeName {get;set;}

        public ICollection<Staff> Staffs {get;set;}
    }
}