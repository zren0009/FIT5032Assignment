namespace _123321.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Events
    {
        public int Id { get; set; }

        [Required]
        public string Title { get; set; }

        public DateTime Start { get; set; }
    }
}
