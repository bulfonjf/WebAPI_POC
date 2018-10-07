using System;
using System.ComponentModel.DataAnnotations;

namespace WebAPI_POC.Entities
{
    public class Author
    {
        public Guid Id { get; set; }

        [Required]
        [MaxLength(150)]
        public string FirstName { get; set; }

        [Required]
        [MaxLength(150)]
        public string LastName { get; set; }
    }
}
