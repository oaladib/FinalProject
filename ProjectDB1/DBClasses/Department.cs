using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace ProjectDB1.DBClasses
{
    [Table("Department", Schema = "Assignment")]
    class Department
    {
        [Column("dept_id")]
        [Required]
        public int DepartmentId { get; set; }// Primary key

        [Column("dept_name")]
        [Required]
        public string DeptName { get; set; }

        [InverseProperty("Department")]
        public List<Student> Students { get; } = new List<Student>();//collection navigation property
    }
}
