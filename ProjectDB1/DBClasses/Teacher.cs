using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace ProjectDB1.DBClasses
{
    [Table("Teacher", Schema = "Assignment")]
    class Teacher : Person
    {

        [InverseProperty("Teacher")]
        public List<Group> Groups { get; } = new List<Group>();//collection navigation property
    }
}
