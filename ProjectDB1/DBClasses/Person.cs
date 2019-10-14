using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace ProjectDB1.DBClasses
{
    [Table("Person", Schema = "Assignment")]
    class Person
    {
        [Column("person_id")]
        [Required]
        public int PersonId { get; set; }// primary key
        [Column("first_name")]
        [Required]
        public string FirstName { get; set; }
        [Column("father_name")]
        [Required]
        public string FatherName { get; set; }
        [Column("sur_name")]
        [Required]
        public string SurName { get; set; }

        [Column("a_first_name")]
        [Required]
        public string AFirstName { get; set; }
        [Column("a_father_name")]
        [Required]
        public string AFatherName { get; set; }
        [Column("a_sur_name")]
        [Required]
        public string ASurName { get; set; }
        [Column("email")]
        [Required]
        public string Email { get; set; }

        [Column("mobile")]
        [Required]
        public string Mobile { get; set; }

        [Column("user_id")]
        [Required]
        public int UserId { get; set; } // foreign key
        [ForeignKey("UserId")]

        public User PersonUser { get; set; } //reference navigation property
    }
}
