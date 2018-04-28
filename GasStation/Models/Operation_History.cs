namespace GasStation.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Operation_History
    {
        [Key]
        public int History_id { get; set; }

        public DateTime Change_Date { get; set; }

        public double Operation_Money { get; set; }

        public int Personal_Num { get; set; }

        public int Cashbox_Id { get; set; }

        public int Operation_Id { get; set; }

        public virtual Total_Money Total_Money { get; set; }

        public virtual Type_Operation Type_Operation { get; set; }

        public virtual Personal Personal { get; set; }
    }
}
