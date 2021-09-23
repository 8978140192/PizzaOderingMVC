using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace PizzaOrderingMVCApplication.Models
{
    public partial class PizzaOrdingUsingMVCContext : DbContext
    {
        public PizzaOrdingUsingMVCContext()
        {
        }

        public PizzaOrdingUsingMVCContext(DbContextOptions<PizzaOrdingUsingMVCContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Order> Orders { get; set; }
        public virtual DbSet<OrderDetail> OrderDetails { get; set; }
        public virtual DbSet<OrderToppingDetail> OrderToppingDetails { get; set; }
        public virtual DbSet<PizzaDetail> PizzaDetails { get; set; }
        public virtual DbSet<ToppingDetail> ToppingDetails { get; set; }
        public virtual DbSet<UserDetail> UserDetails { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                if (System.Environment.MachineName == "DESKTOP-8PS4036")
                {
                    optionsBuilder.UseSqlServer("Data source=DESKTOP-8PS4036\\KANINISQL2019; Integrated Security=true; Initial catalog=PizzaOrdingUsingMVC");
                }
                else if (System.Environment.MachineName == "KANINI-LTP-534")

                    optionsBuilder.UseSqlServer("Data Source=KANINI-LTP-534\\SQLSERVERPAVI; user id=sa; password=murugi@1999; Initial catalog=PizzaOrdingUsingMVC");
                else if (System.Environment.MachineName == "KANINI-LTP-455")

                    optionsBuilder.UseSqlServer("Data source=KANINI-LTP-455\\SQLSERVER2019G3;user id=sa;password=Admin@123;Initial catalog=PizzaOrdingUsingMVC");
                else if (System.Environment.MachineName == "KANINI-LTP-537")

                    optionsBuilder.UseSqlServer("Data source=KANINI-LTP-537\\SQLSERVER2019M;Integrated Security = true;Initial catalog=PizzaOrdingUsingMVC");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS");

            modelBuilder.Entity<Order>(entity =>
            {
                entity.Property(e => e.OrderStatus)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.UserId)
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.HasOne(d => d.User)
                    .WithMany(p => p.Orders)
                    .HasForeignKey(d => d.UserId)
                    .HasConstraintName("FK__Orders__UserId__44FF419A");
            });

            modelBuilder.Entity<OrderDetail>(entity =>
            {
                entity.HasKey(e => e.ItemId)
                    .HasName("PK__OrderDet__727E838BB2AD916B");

                entity.HasOne(d => d.Order)
                    .WithMany(p => p.OrderDetails)
                    .HasForeignKey(d => d.OrderId)
                    .HasConstraintName("FK__OrderDeta__Order__48CFD27E");

                entity.HasOne(d => d.Pizza)
                    .WithMany(p => p.OrderDetails)
                    .HasForeignKey(d => d.PizzaId)
                    .HasConstraintName("FK__OrderDeta__Pizza__47DBAE45");
            });

            modelBuilder.Entity<OrderToppingDetail>(entity =>
            {
                entity.HasKey(e => new { e.ItemId, e.ToppingId })
                    .HasName("PK__OrderTop__DC0F3DC8F9EB1591");

                entity.Property(e => e.ItemId).HasColumnName("itemId");

                entity.Property(e => e.ToppingId).HasColumnName("toppingId");

                entity.HasOne(d => d.Item)
                    .WithMany(p => p.OrderToppingDetails)
                    .HasForeignKey(d => d.ItemId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__OrderTopp__itemI__4BAC3F29");

                entity.HasOne(d => d.Topping)
                    .WithMany(p => p.OrderToppingDetails)
                    .HasForeignKey(d => d.ToppingId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__OrderTopp__toppi__4CA06362");
            });

            modelBuilder.Entity<PizzaDetail>(entity =>
            {
                entity.HasKey(e => e.PizzaId)
                    .HasName("PK__PizzaDet__0B6012DD751A2C5E");

                entity.HasIndex(e => e.PizzaName, "UQ__PizzaDet__401E473F24BEC8BB")
                    .IsUnique();

                entity.Property(e => e.PizzaDiscription)
                    .HasMaxLength(1000)
                    .IsUnicode(false);

                entity.Property(e => e.PizzaImage)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.PizzaName)
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.PizzaType)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("pizzaType");
            });

            modelBuilder.Entity<ToppingDetail>(entity =>
            {
                entity.HasKey(e => e.ToppingId)
                    .HasName("PK__ToppingD__EE02CC8551830EFA");

                entity.HasIndex(e => e.ToppingName, "UQ__ToppingD__612DF4CDDFF58E06")
                    .IsUnique();

                entity.Property(e => e.ToppingName)
                    .HasMaxLength(30)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<UserDetail>(entity =>
            {
                entity.HasKey(e => e.UserId)
                    .HasName("PK__UserDeta__CB9A1CFF2AA9EE45");

                entity.Property(e => e.UserId)
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasColumnName("userId");

                entity.Property(e => e.Password)
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasColumnName("password");

                entity.Property(e => e.UserAddress)
                    .HasMaxLength(90)
                    .IsUnicode(false);

                entity.Property(e => e.UserName)
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.UserPhone)
                    .HasMaxLength(15)
                    .IsUnicode(false);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
