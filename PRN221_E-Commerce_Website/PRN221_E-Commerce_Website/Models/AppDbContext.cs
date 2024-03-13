using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Internal;

namespace MockProject.Models
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions options)
            : base(options) { }

        #region Dbset
        public DbSet<Role> Roles { get; set; }
        public DbSet<Account> Accounts { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Room> Rooms { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderDetail> OrderDetails { get; set; }
        public DbSet<PayMethod> PayMethods { get; set; }
        public DbSet<UserPaymentTransaction> UserPaymentTransactions { get; set; }
        #endregion

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            #region ConfigTableRole
            modelBuilder.Entity<Role>(entity =>
            {
                entity.HasKey(e => e.Id);

                entity.ToTable("Role");

                entity.Property(e => e.Id).HasColumnName("ID").UseIdentityByDefaultColumn();
                entity
                    .Property(e => e.RoleName)
                    .IsRequired()
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("Role");
            });
            #endregion

            #region ConfigTableAccount
            modelBuilder.Entity<Account>(entity =>
            {
                entity.HasKey(e => e.Id);

                entity.ToTable("Account");

                entity.HasIndex(e => e.AccountName, "accountName").IsUnique();

                entity.Property(e => e.Id).HasColumnName("ID").UseIdentityByDefaultColumn();
                entity.Property(e => e.Birthday).HasColumnName("Birthday");
                entity
                    .Property(e => e.Email)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("Email");
                entity
                    .Property(e => e.Gender)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("Gender");
                entity
                    .Property(e => e.Identitycard)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("IdentityCard");
                entity.Property(e => e.Name).HasMaxLength(50).HasColumnName("Name");
                entity
                    .Property(e => e.Nation)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("Nation");
                entity
                    .Property(e => e.Password)
                    .IsRequired()
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("Password");
                entity
                    .Property(e => e.Phone)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("Phone");
                entity
                    .Property(e => e.RoleID)
                    .IsRequired()
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("roleID");
                entity
                    .Property(e => e.AccountName)
                    .IsRequired()
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("Account");

                entity
                    .HasOne(d => d.role)
                    .WithMany(p => p.accounts)
                    .HasForeignKey(d => d.RoleID)
                    .OnDelete(DeleteBehavior.NoAction);
            });
            #endregion

            #region ConfigTableCategory
            modelBuilder.Entity<Category>(entity =>
            {
                entity.HasKey(e => e.ID);

                entity.ToTable("Category");
                entity.Property(e => e.ID).HasColumnName("CategoryID").UseIdentityByDefaultColumn();
            });
            #endregion

            #region ConfigTableRoom
            modelBuilder.Entity<Room>(entity =>
            {
                entity.ToTable("Room");

                entity.Property(e => e.Id).HasColumnName("RoomID");

                entity.Property(e => e.BedQuantity).HasColumnName("Bed Quantity");

                entity.Property(e => e.RoomImage).HasMaxLength(255).IsUnicode(false);

                entity.Property(e => e.Name).IsRequired().HasMaxLength(100).IsUnicode(false);

                entity
                    .HasOne(r => r.Category)
                    .WithMany(c => c.Rooms)
                    .HasForeignKey(r => r.CategoryId);
            });
            #endregion

            #region ConfigTableOrder
            modelBuilder.Entity<Order>(entity =>
            {
                entity.ToTable("Order");

                entity.HasKey(e => e.Id);

                entity.Property(e => e.Id).HasColumnName("OrderID").UseIdentityByDefaultColumn();

                entity.Property(e => e.AccountId).IsRequired().HasColumnName("AccountID");

                entity
                    .Property(e => e.RoomId)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("RoomID");

                entity
                    .HasOne(e => e.Account)
                    .WithMany(a => a.Orders)
                    .HasForeignKey(e => e.AccountId);
            });
            #endregion

            #region ConfigTableOrderDetail
            modelBuilder.Entity<OrderDetail>(entity =>
            {
                entity.ToTable("Order Detail");
                entity.HasKey(e => e.OrderID);

                entity
                    .HasOne(d => d.Order)
                    .WithOne(o => o.OrderDetail)
                    .HasForeignKey<OrderDetail>(d => d.OrderID);
                entity
                    .HasOne(d => d.PayMethod)
                    .WithMany(o => o.OrderDetails)
                    .HasForeignKey(d => d.PayMethodID);
            });
            #endregion

            #region ConfigTablePayMethod
            modelBuilder.Entity<PayMethod>(entity =>
            {
                entity.ToTable("PayMethod");
                entity.HasKey(p => p.Id);
                entity.Property(p => p.Id).UseIdentityByDefaultColumn();
                entity.Property(p => p.Name).HasMaxLength(255).IsUnicode(false);
            });
            #endregion

            #region ConfigTableUserPaymentTransaction
            modelBuilder.Entity<UserPaymentTransaction>(entity =>
            {
                entity.ToTable("UserPaymentTransaction");
                entity.HasKey(e => e.Id);
                entity.Property(entity => entity.Id).UseIdentityByDefaultColumn();
                entity
                    .HasOne(c => c.payMethod)
                    .WithMany(e => e.UserPaymentTransactions)
                    .HasForeignKey(c => c.PayMethodID);
                entity
                    .HasOne(c => c.account)
                    .WithMany(e => e.UserPaymentTransaction)
                    .HasForeignKey(c => c.AccountId);
            });
            #endregion
        }
    }
}
