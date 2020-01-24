namespace iocco_api.DataLayer
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Employee")]
    public partial class Employee
    {
        public int employeeId { get; set; }

        public int personId { get; set; }

        [Required]
        [StringLength(500)]
        public string employeeNumber { get; set; }

        public DateTime employedDate { get; set; }

        public DateTime? terminatedDate { get; set; }

        public virtual Person Person { get; set; }
    }
}
