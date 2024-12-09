﻿using EMA.Enums;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EMA.ViewModel
{
    public class RegistrationViewModel
    {
        public int Id { get; set; }
        [ForeignKey("Event")]
        public int EventId { get; set; }
        
        [Required(ErrorMessage = "First Name is required")]
        [Display(Name = "First Name")]
        [StringLength(50, ErrorMessage = "First Name cannot be longer than 50 characters")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "Last Name is required")]
        [Display(Name = "Last Name")]
        [StringLength(50, ErrorMessage = "Last Name cannot be longer than 50 characters")]
        public string LastName { get; set; }

        [Required(ErrorMessage = "Email is required")]
        [EmailAddress(ErrorMessage = "Invalid Email Address")]
        public string Email { get; set; }

        [Phone(ErrorMessage = "Invalid Phone Number")]
        [Display(Name = "Phone Number")]
        public string PhoneNumber { get; set; }

        public string Organization { get; set; }

        [Required(ErrorMessage = "Registration Type is required")]
        [Display(Name = "Registration Type")]
        public RegistrationType RegistrationType { get; set; }

        [Display(Name = "Special Requirements")]
        public string SpecialRequirements { get; set; }

        [Required(ErrorMessage = "You must accept the terms and conditions")]
        [Display(Name = "Accept Terms")]
        public bool AcceptTerms { get; set; }
    }
}