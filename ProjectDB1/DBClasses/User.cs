using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace ProjectDB1.DBClasses
{
    [Table("User", Schema = "Assignment")]
    class User
    {
        [Column("user_id")]
        [Required]
        public int UserId { get; set; }// primary key

        [Column("user_name")]
        [Required]
        public string UserName { get; set; }

        [Column("password")]
        [Required]
        public string Password { get; set; }

        [Column("hint")]
        public string Hint { get; set; }

        [Column("type")]
        [Required]
        public int Type { get; set; }

        [InverseProperty("PersonUser")]
        public List<Person> Persons { get; } = new List<Person>();//collection navigation property
 }
}
