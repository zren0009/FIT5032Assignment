namespace _30080193.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Enrolment")]
    public partial class Enrolment
    {
        public int Id { get; set; }

        public int StudentId { get; set; }

        public int UnitId { get; set; }

        public int Year { get; set; }

        public int Semester { get; set; }

        [Column(TypeName = "date")]
        public DateTime UpdateTime { get; set; }

        public virtual Student Student { get; set; }

        public virtual Unit Unit { get; set; }
    }
}
