using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace ProjectDB1.DBClasses
{
    [Table("Group", Schema = "Assignment")]
    class Group
    {
        [Column("group_id")]
        [Required]
        public int GroupId { get; set; }// Primary key

        [Column("max_number")]
        [Required]
        public int MaxNum { get; set; }

        [Column("group_semester")]
        [Required]
        public string GroupSemester { get; set; }

        [Column("day")]
        [Required]
        public string Day { get; set; }

        [Column("time")]
        [Required]
        public DateTime Time { get; set; }

        [Column("teacher_id")]
        [Required]
        public int TeacherId { get; set; } // foreign key
        [ForeignKey("TeacherId")]
        public Teacher Teacher { get; set; } //reference navigation property


        [InverseProperty("Group")]
        public List<Student> Students { get; } = new List<Student>();//collection navigation property


        //[InverseProperty("Group")]
        public List<Assignment> Assignments { get; } = new List<Assignment>();//collection navigation property

    }
}
