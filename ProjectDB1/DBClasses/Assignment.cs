using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

using System.Text;

namespace ProjectDB1.DBClasses
{
    [Table("Assignment", Schema = "Assignment")]
    class Assignment
    {
        [Column("assignment_id")]
        [Required]
        public int AssignmentId { get; set; }// Primary key

        [Column("mark")]
        [Required]
        public double Mark { get; set; }

        [Column("dec_mark")]
        [Required]
        public double DecMark { get; set; }
        [Required]

        [Column("publish_date")]
        public DateTime PublishDate { get; set; }

        [Column("deadline")]
        [Required]
        public DateTime Deadline { get; set; }

        [Column("t_deadline")]
        [Required]
        public DateTime TDeadline { get; set; }

        [Column("description")]
        [Required]
        public string Description { get; set; }

        [Column("note")]
        public string Note { get; set; }

        [Column("template")]
        [Required]
        public string Template { get; set; }

        [Column("solution")]
        public string Solution { get; set; }

        [Column("assignment_test")]
        public string AssTest { get; set; }

        [Column("group_id")]
        [Required]
        public int GroupId { get; set; } // foreign key
        [ForeignKey("GroupId")]
        public Group Group { get; set; } //reference navigation property

        [InverseProperty("Assignment")]
        public List<Submission> Submissions { get; } = new List<Submission>();//collection navigation property

          
        public string evaluate(string studentSolutionURL)
        {
            return "dg";
        }
        
    }

}
