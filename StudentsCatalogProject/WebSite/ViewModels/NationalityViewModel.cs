using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using WebSite.NationalityService;

namespace WebSite.ViewModels
{
    public class NationalityViewModel
    {

        public int Id { get; set; }
        [Required]
        [StringLength(100, MinimumLength = 1, ErrorMessage = "Must be at least 1 characters long.")]
        public string Title { get; set; }

        public NationalityViewModel() { }

        public NationalityViewModel(NationalityDto nationalityDto)
        {
            Id = nationalityDto.Id;
            Title = nationalityDto.Title;
        }
    }
}