using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
namespace GESTION.model
{
    public class ProfLevel
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IdProfLevel {get;set;}

        public int StaffId{get;set;}
        public virtual Staff Staff{get;set;}

        public int LevelId {get;set;}
        public virtual Level Level {get;set;}

        public int PeriodId {get;set;}
        public virtual Period Period {get;set;}
        
    }
}