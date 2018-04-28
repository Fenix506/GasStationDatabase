namespace GasStation.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Income_Fuel
    {
        [Key]
        public int Income_Num { get; set; }

        public double Count_Income { get; set; }

        public DateTime Date_Income { get; set; }

        public int Fuel_Id { get; set; }

        public virtual Type_Fuel Type_Fuel { get; set; }
    }
}
