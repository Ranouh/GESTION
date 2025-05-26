using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
namespace GESTION.model
{
    public class Nationality
    {
        
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IdNationality { get; set; }
        [Required(ErrorMessage="NationalityName Required")]
        public string? NationalityName { get; set; }

        public ICollection <Student> Students {get;set;}
    }
}