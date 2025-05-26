using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
namespace GESTION.model
{
    public class Staff
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IdStaff {get;set;}

        [Required(ErrorMessage="matriculeStaff is required and cannot be null")]
        public string? StaffMatricule {get;set;}
        [Required(ErrorMessage="nameStaff is required and cannot be null")]
        public string? StaffName {get;set;}
        [Required(ErrorMessage="firstNameStaff is required and cannot be null")]
        public string? StaffFirstName{get;set;}
        [Required(ErrorMessage="genderStaff is required and cannot be null")]
        public string? StaffGender{get;set;}
        [Required(ErrorMessage="phoneNumberStaff is required and cannot be null")]
        public string? StaffPhone{get;set;}
        [Required(ErrorMessage="emailStaff is required and cannot be null")]
        public string? StaffEmail{get;set;}
        [Required(ErrorMessage="homeStaff is required and cannot be null")]
        public string? StaffHome{get;set;}
        [Required(ErrorMessage="martialSatusStaff is required and cannot be null")]
        public string? StaffMartialStatus{get;set;}
        [Required(ErrorMessage="birth is required and cannot be null")]
        public DateTime StaffBirth{get;set;}

        public int VenueId {get;set;}
        public Venue Venue{get;set;}

        public int NationalityId{get;set;}
        public Nationality Nationality {get;set;}

        public int PrivilegeId{get;set;}
        public Privilege Privilege{get;set;}

        public int SubjectId {get;set;}
        public Subject Subject{get;set;}

        public ICollection <ProfLevel> ProfLevels {get;set;}
        

    }

}