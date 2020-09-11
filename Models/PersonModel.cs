using System;
using System.ComponentModel.DataAnnotations;

namespace SchoolTemplate.Models
{
    public class PersonModel
    {
        [Required(ErrorMessage = "Voornaam is verplicht")]
        public string Voornaam { get; set;  }
        
        [Required(ErrorMessage = "Achternaam is verplicht")]
        public string Achternaam { get; set; }

        [Required(ErrorMessage = "E-mail is verplicht")]
        [EmailAddress(ErrorMessage = "Geen geldig e-mail adres")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Geboortedatum is verplicht")]
        public DateTime Geboortedatum { get; set; }

        [Required(ErrorMessage = "Adres is verplicht")]
        public string Adres { get; set; }

        [Required(ErrorMessage = "Woonplaats is verplicht")]
        public string Woonplaats { get; set; }

        [Required(ErrorMessage = "Postcode is verplicht")]
        public string Postcode { get; set; }
    }
}
