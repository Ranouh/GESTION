using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GESTION.Dto.Period
{
    public class UpdatePeriodRequestDto
    {
        public int? Year { get; set; }
        public string? PeriodName {get;set;}
    }
}