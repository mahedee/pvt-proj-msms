using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace MSMS.Models
{
    public class Institution
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        [StringLength(250)]
        [Display(Name = "Institution Name")]
        public string Name { get; set; }

        [StringLength(350)]
        [Display(Name = "Slogan")]
        public string Slogan { get; set; }

        [StringLength(500)]
        [Display(Name = "Address")]
        public string Address { get; set; }

        [StringLength(20)]
        [Display(Name = "Institution Code")]
        public string InstitutionCode { get; set; }

        [StringLength(250)]
        [Display(Name = "Logo")]
        public string LogoURL { get; set; }

        [DataType(DataType.DateTime)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd/MM/yyyy}")]
        [Display(Name = "Date of Establishment")]
        public DateTime EstDate { get; set; }
    }
}