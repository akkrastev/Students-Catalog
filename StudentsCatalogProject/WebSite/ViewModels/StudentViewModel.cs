using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using WebSite.StudentService;

namespace WebSite.ViewModels
{
    public class StudentViewModel
    {
        public int Id { get; set; }
        [StringLength(100, MinimumLength = 1, ErrorMessage = "Must be at least 1 characters long.")]
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime? DateOfBirth { get; set; }
        public string City { get; set; }

        [Display(Name ="Nationality")]
        public int NationalityId { get; set; }
        public NationalityViewModel NationalityVM { get; set; }

        [Display(Name = "Faculty")]
        public int FacultyId { get; set; }
        public FacultyViewModel FacultyVM { get; set; }


        public StudentViewModel() { }

        public StudentViewModel(StudentDto studentDto)
        {
            Id = studentDto.Id;
            FirstName = studentDto.FirstName;
            LastName = studentDto.LastName;
            DateOfBirth = studentDto.DateOfBirth;
            City = studentDto.City;
            NationalityId = studentDto.Nationality.Id;
            NationalityVM = new NationalityViewModel
            {
                Id = studentDto.Nationality.Id,
                Title = studentDto.Nationality.Title
            };
            FacultyId = studentDto.Faculty.Id;
            FacultyVM = new FacultyViewModel
            {
                Id = studentDto.Faculty.Id,
                Name = studentDto.Faculty.Name,
                City = studentDto.Faculty.City,
                Address = studentDto.Faculty.Address
            };
        }
    }
}