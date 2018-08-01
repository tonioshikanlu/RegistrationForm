using System;
using System.ComponentModel.DataAnnotations;

namespace Identity.Models
{
    public class MvcRegister
    {
        public MvcRegister() => DateAdded = DateTime.Now;

        public int ID { get; set; }
        [Display(Name = "First Name")]
        [DataType(DataType.Text)]
        public string FirstName { get; set; }
        [Display(Name = "Last Name")]
        [DataType(DataType.Text)]
        public string LastName { get; set; }

        [Display(Name = "Date Added")]
        [DataType(DataType.Date)]
        public DateTime DateAdded { get; private set; }
        public string Address { get; set; }
        public string Class { get; set; }
        public int Age { get; set; }

        }
    }

