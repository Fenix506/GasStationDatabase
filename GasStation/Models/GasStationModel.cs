namespace GasStation.Models
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class GasStationModel : DbContext
    {
        public GasStationModel()
            : base("name=GSConnection")
        {
        }

        public virtual DbSet<Client> Client { get; set; }
        public virtual DbSet<Income_Fuel> Income_Fuel { get; set; }
        public virtual DbSet<Operation_History> Operation_History { get; set; }
        public virtual DbSet<Personal> Personal { get; set; }
        public virtual DbSet<Sell_Fuel> Sell_Fuel { get; set; }
        public virtual DbSet<Total_Money> Total_Money { get; set; }
        public virtual DbSet<Type_Fuel> Type_Fuel { get; set; }
        public virtual DbSet<Type_Operation> Type_Operation { get; set; }
        public virtual DbSet<Work_Position> Work_Position { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Client>()
                .Property(e => e.Name)
                .IsUnicode(false);

            modelBuilder.Entity<Client>()
                .Property(e => e.Surname)
                .IsUnicode(false);

            modelBuilder.Entity<Client>()
                .Property(e => e.Middle_Name)
                .IsUnicode(false);

            modelBuilder.Entity<Client>()
                .HasMany(e => e.Sell_Fuel)
                .WithRequired(e => e.Client)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Personal>()
                .Property(e => e.Name)
                .IsUnicode(false);

            modelBuilder.Entity<Personal>()
                .Property(e => e.Surname)
                .IsUnicode(false);

            modelBuilder.Entity<Personal>()
                .Property(e => e.Middle_Name)
                .IsUnicode(false);

            modelBuilder.Entity<Personal>()
                .HasMany(e => e.Operation_History)
                .WithRequired(e => e.Personal)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Personal>()
                .HasMany(e => e.Sell_Fuel)
                .WithRequired(e => e.Personal)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Total_Money>()
                .HasMany(e => e.Operation_History)
                .WithRequired(e => e.Total_Money)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Type_Fuel>()
                .Property(e => e.Name_Fuel)
                .IsUnicode(false);

            modelBuilder.Entity<Type_Fuel>()
                .HasMany(e => e.Income_Fuel)
                .WithRequired(e => e.Type_Fuel)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Type_Fuel>()
                .HasMany(e => e.Sell_Fuel)
                .WithRequired(e => e.Type_Fuel)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Type_Operation>()
                .Property(e => e.Operation_Type)
                .IsUnicode(false);

            modelBuilder.Entity<Type_Operation>()
                .HasMany(e => e.Operation_History)
                .WithRequired(e => e.Type_Operation)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Work_Position>()
                .Property(e => e.Position_Work)
                .IsUnicode(false);

            modelBuilder.Entity<Work_Position>()
                .HasMany(e => e.Personal)
                .WithRequired(e => e.Work_Position)
                .WillCascadeOnDelete(false);
        }
    }
}
