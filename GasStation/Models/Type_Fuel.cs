namespace GasStation.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Type_Fuel
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Type_Fuel()
        {
            Income_Fuel = new HashSet<Income_Fuel>();
            Sell_Fuel = new HashSet<Sell_Fuel>();
        }

        [Key]
        public int Fuel_Id { get; set; }

        [Required]
        [StringLength(20)]
        public string Name_Fuel { get; set; }

        public double Price { get; set; }

        public double Count_Fuel { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Income_Fuel> Income_Fuel { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Sell_Fuel> Sell_Fuel { get; set; }
    }
}
