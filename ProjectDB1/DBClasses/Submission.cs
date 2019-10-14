using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

using System.Text;

namespace ProjectDB1.DBClasses
{
    [Table("Submission", Schema = "Assignment")]
    class Submission
    {
        [Column("submission_id")]
        [Required]
        public int SubmissionId { get; set; }// Primary key
        [Column("date")]
        [Required]
        public DateTime Date { get; set; }
        [Column("solution")]
        [Required]
        public String Solution { get; set; }
        [Column("mark")]
        public double Mark { get; set; }
        [Column("try_id")]
        [Required]
        public int TryId { get; set; }

        [Column("student_id")]
        [Required]
        public int StudentId { get; set; } // foreign key
        [ForeignKey("StudentId")]
        public Student Student { get; set; } //reference navigation property

        [Column("assignment_id")]
        [Required]
        public int AssId { get; set; } // foreign key
        [ForeignKey("AssId")]
        public Assignment Assignment { get; set; } //reference navigation property

    }
}
