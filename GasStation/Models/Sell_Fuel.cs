namespace GasStation.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Sell_Fuel
    {
        [Key]
        public int Sell_Num { get; set; }

        public DateTime Date_Sell { get; set; }

        public int Client_Num { get; set; }

        public int Personal_Num { get; set; }

        public int Number_Column { get; set; }

        public double Count_Sell { get; set; }

        public double Price { get; set; }

        public int Fuel_Id { get; set; }

        public virtual Client Client { get; set; }

        public virtual Personal Personal { get; set; }

        public virtual Type_Fuel Type_Fuel { get; set; }
    }
}
