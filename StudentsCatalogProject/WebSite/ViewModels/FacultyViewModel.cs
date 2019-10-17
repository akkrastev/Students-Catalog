using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using WebSite.FacultyService;

namespace WebSite.ViewModels
{
    public class FacultyViewModel
    {

        public int Id { get; set; }
        [Required]
        [StringLength(200, MinimumLength = 1, ErrorMessage = "Must be at least 1 characters long.")]
        public string Name { get; set; }
        public string City { get; set; }
        [StringLength(200, MinimumLength = 1, ErrorMessage = "Must be at least 1 characters long.")]
        public string Address { get; set; }

        public FacultyViewModel() { }

        public FacultyViewModel(FacultyDto facultyDto)
        {
            Id = facultyDto.Id;
            Name = facultyDto.Name;
            City = facultyDto.City;
            Address = facultyDto.Address;
        }
    }
}