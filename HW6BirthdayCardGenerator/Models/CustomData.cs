using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace HW6BirthdayCardGenerator.Models
{
    public class CustomData
    {
        [Required(ErrorMessage = "Please enter From")]
        public string Sender { get; set; }
        [Required(ErrorMessage = "Please enter To")]
        public string Recipient { get; set; }
        [Required(ErrorMessage = "Please enter Message")]
        public string Message { get; set; }
    }
}
