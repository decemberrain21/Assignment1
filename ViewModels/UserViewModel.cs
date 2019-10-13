using System;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;

namespace Assignment.ViewModels
{
    public class UserViewModel
    {
        [Key]
        public Guid Id { get; set; }
        [Required]
        [MaxLength(30)]
        public string Name { get; set; }
        [Required]
        [MaxLength(30)]
        [DataType(DataType.EmailAddress)]
        [EmailAddress]
        public string Email { get; set; }
        [Required]
        public char Gender { get; set; }
        [Required]
        [ValidateDateRange]
        [DataType(DataType.Date)]
        public DateTime RegisteredDate { get; set; }
        [Required]
        public string SelectedEvents { get; set; }
        [MaxLength(100)]
        [DataType(DataType.MultilineText)]
        public string AdditionalRequest { get; set; }
        public List<EventViewModel> Events { get; set; }
    }
}
