namespace _30080193.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class ratings
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "{0} is required.")]
        public int BookingId { get; set; }
        [Required]
        public double Rating { get; set; }

        [Required]
        public string Comment { get; set; }

        public virtual Bookings Bookings { get; set; }
    }
}
