using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace PizzaStore.Context
{
    public partial class PizzaDBContext : DbContext
    {
        public PizzaDBContext()
        {
        }

        public PizzaDBContext(DbContextOptions<PizzaDBContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Inventory> Inventory { get; set; }
        public virtual DbSet<Store> Store { get; set; }
        public virtual DbSet<TransactionOrder> TransactionOrder { get; set; }
        public virtual DbSet<Transactions> Transactions { get; set; }
        public virtual DbSet<Users> Users { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("ProductVersion", "2.2.0-rtm-35687");

            modelBuilder.Entity<Inventory>(entity =>
            {
                entity.HasKey(e => e.IngredientName)
                    .HasName("PK__Inventor__A1B2F1CDE6C0F404");

                entity.ToTable("Inventory", "Pizza");

                entity.Property(e => e.IngredientName)
                    .HasMaxLength(100)
                    .ValueGeneratedNever();

                entity.Property(e => e.Price).HasColumnType("money");
            });

            modelBuilder.Entity<Store>(entity =>
            {
                entity.HasKey(e => e.Name)
                    .HasName("PK__Store__737584F7DF509CCB");

                entity.ToTable("Store", "Pizza");

                entity.Property(e => e.Name)
                    .HasMaxLength(100)
                    .ValueGeneratedNever();

                entity.HasOne(d => d.Order)
                    .WithMany(p => p.Store)
                    .HasForeignKey(d => d.OrderId)
                    .HasConstraintName("FK__Store__OrderId__498EEC8D");
            });

            modelBuilder.Entity<TransactionOrder>(entity =>
            {
                entity.HasKey(e => e.PizzaId)
                    .HasName("PK__Transact__0B6012DD14AFF981");

                entity.ToTable("TransactionOrder", "Pizza");

                entity.Property(e => e.Cost).HasColumnType("money");

                entity.Property(e => e.Size)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.Topping1)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(e => e.Topping2)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(e => e.Topping3)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(e => e.Topping4)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(e => e.Topping5)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.HasOne(d => d.Topping1Navigation)
                    .WithMany(p => p.TransactionOrderTopping1Navigation)
                    .HasForeignKey(d => d.Topping1)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Transacti__Toppi__42E1EEFE");

                entity.HasOne(d => d.Topping2Navigation)
                    .WithMany(p => p.TransactionOrderTopping2Navigation)
                    .HasForeignKey(d => d.Topping2)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Transacti__Toppi__43D61337");

                entity.HasOne(d => d.Topping3Navigation)
                    .WithMany(p => p.TransactionOrderTopping3Navigation)
                    .HasForeignKey(d => d.Topping3)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Transacti__Toppi__44CA3770");

                entity.HasOne(d => d.Topping4Navigation)
                    .WithMany(p => p.TransactionOrderTopping4Navigation)
                    .HasForeignKey(d => d.Topping4)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Transacti__Toppi__45BE5BA9");

                entity.HasOne(d => d.Topping5Navigation)
                    .WithMany(p => p.TransactionOrderTopping5Navigation)
                    .HasForeignKey(d => d.Topping5)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Transacti__Toppi__46B27FE2");
            });

            modelBuilder.Entity<Transactions>(entity =>
            {
                entity.HasKey(e => e.OrderId)
                    .HasName("PK_OrderId_ID");

                entity.ToTable("Transactions", "Pizza");

                entity.Property(e => e.StoreName)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.HasOne(d => d.Pizza)
                    .WithMany(p => p.Transactions)
                    .HasForeignKey(d => d.PizzaId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Transacti__Pizza__4B7734FF");

                entity.HasOne(d => d.StoreNameNavigation)
                    .WithMany(p => p.Transactions)
                    .HasForeignKey(d => d.StoreName)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Transacti__Store__4D5F7D71");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.Transactions)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Transacti__UserI__4C6B5938");
            });

            modelBuilder.Entity<Users>(entity =>
            {
                entity.ToTable("Users", "Pizza");

                entity.Property(e => e.FirstName)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(e => e.LastName)
                    .IsRequired()
                    .HasMaxLength(100);
            });
        }
    }
}
