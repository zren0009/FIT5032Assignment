namespace ePortfolio_30080193.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Booking")]
    public partial class Booking
    {
        public int Id { get; set; }

        public int StudentId { get; set; }

        public DateTime Start { get; set; }

        public double Hours { get; set; }

        public virtual Student Student { get; set; }
    }
}
