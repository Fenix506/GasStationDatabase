namespace GasStation.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Client")]
    public partial class Client
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Client()
        {
            Sell_Fuel = new HashSet<Sell_Fuel>();
        }

        [Key]
        public int Client_Num { get; set; }

        [Required]
        [StringLength(25)]
        public string Name { get; set; }

        [Required]
        [StringLength(25)]
        public string Surname { get; set; }

        [StringLength(25)]
        public string Middle_Name { get; set; }

        public double Personal_Discount { get; set; }

        public double Bonus { get; set; }

        public double Liters_Sold { get; set; }

        public DateTime Date_Registration { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Sell_Fuel> Sell_Fuel { get; set; }
    }
}
