using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace ProjectDB1.DBClasses
{

    [Table("Student", Schema = "Assignment")]
    class Student : Person
    {
        

        [Column("registration_year")]
        [Required]
        public string RegYear { get; set; }

        [Column("university_number")]
        [Required]
        public string UnNum { get; set; }

        public Department Department { get; set; } //reference navigation property


        [Column("dept_id")]
        [Required]
        public int DepartmentId { get; set; } // foreign key
        [ForeignKey("DepartmentId")]

        [Column("group_id")]
        public int GroupId { get; set; } // foreign key
        [ForeignKey("GroupId")]
        public Group Group { get; set; } //reference navigation property

        [InverseProperty("Student")]
        public List<Submission> Submissions { get; } = new List<Submission>();//collection navigation property

        public static string exportCSV(int gourpid)
        {
            return "c,,,,,";
        }

        /*
         *  std_num, std_name, groupid, remarsk
         *  
         */
        public static bool importCSV(string students)
        {
            return true;
        }

    }
}
