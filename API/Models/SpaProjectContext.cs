using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace API.Models
{
    public partial class SpaProjectContext : DbContext
    {
        public SpaProjectContext()
        {
        }

        public SpaProjectContext(DbContextOptions<SpaProjectContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Appointment> Appointments { get; set; } = null!;
        public virtual DbSet<Asset> Assets { get; set; } = null!;
        public virtual DbSet<Bed> Beds { get; set; } = null!;
        public virtual DbSet<Bulletin> Bulletins { get; set; } = null!;
        public virtual DbSet<Category> Categories { get; set; } = null!;
        public virtual DbSet<Customer> Customers { get; set; } = null!;
        public virtual DbSet<CustomerSegmentation> CustomerSegmentations { get; set; } = null!;
        public virtual DbSet<Employee> Employees { get; set; } = null!;
        public virtual DbSet<Notification> Notifications { get; set; } = null!;
        public virtual DbSet<Permission> Permissions { get; set; } = null!;
        public virtual DbSet<Product> Products { get; set; } = null!;
        public virtual DbSet<Promotion> Promotions { get; set; } = null!;
        public virtual DbSet<Review> Reviews { get; set; } = null!;
        public virtual DbSet<RewardPoint> RewardPoints { get; set; } = null!;
        public virtual DbSet<Role> Roles { get; set; } = null!;
        public virtual DbSet<RolePermission> RolePermissions { get; set; } = null!;
        public virtual DbSet<Room> Rooms { get; set; } = null!;
        public virtual DbSet<Salary> Salaries { get; set; } = null!;
        public virtual DbSet<Sale> Sales { get; set; } = null!;
        public virtual DbSet<SaleItem> SaleItems { get; set; } = null!;
        public virtual DbSet<Service> Services { get; set; } = null!;
        public virtual DbSet<ServiceCard> ServiceCards { get; set; } = null!;
        public virtual DbSet<Spa> Spas { get; set; } = null!;
        public virtual DbSet<SystemSetting> SystemSettings { get; set; } = null!;
        public virtual DbSet<Transaction> Transactions { get; set; } = null!;
        public virtual DbSet<User> Users { get; set; } = null!;
        public virtual DbSet<UserRole> UserRoles { get; set; } = null!;
        public virtual DbSet<WorkSchedule> WorkSchedules { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
<<<<<<< HEAD
<<<<<<< HEAD
                var builder = new ConfigurationBuilder()
                              .SetBasePath(Directory.GetCurrentDirectory())
                              .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);
                IConfigurationRoot configuration = builder.Build();
                optionsBuilder.UseSqlServer(configuration.GetConnectionString("MyCnn"));
=======
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("server =localhost; database = SpaProject;uid=sa;pwd=123;");
>>>>>>> 80d94dc5e6631bb94fe479a2e337b265a77ebfa9
=======
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("server =localhost; database = SpaProject;uid=sa;pwd=123;");
>>>>>>> 80d94dc5e6631bb94fe479a2e337b265a77ebfa9
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Appointment>(entity =>
            {
                entity.Property(e => e.AppointmentId)
                    .ValueGeneratedNever()
                    .HasColumnName("AppointmentID");

                entity.Property(e => e.AppointmentDate).HasColumnType("date");

                entity.Property(e => e.CustomerId).HasColumnName("CustomerID");

                entity.Property(e => e.EmployeeId).HasColumnName("EmployeeID");

                entity.Property(e => e.RoomId).HasColumnName("RoomID");

                entity.Property(e => e.ServiceId).HasColumnName("ServiceID");

                entity.Property(e => e.SpaId).HasColumnName("SpaID");

                entity.Property(e => e.Status)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.HasOne(d => d.Customer)
                    .WithMany(p => p.AppointmentCustomers)
                    .HasForeignKey(d => d.CustomerId)
                    .HasConstraintName("FK__Appointme__Custo__3E52440B");

                entity.HasOne(d => d.Employee)
                    .WithMany(p => p.AppointmentEmployees)
                    .HasForeignKey(d => d.EmployeeId)
                    .HasConstraintName("FK__Appointme__Emplo__3F466844");

                entity.HasOne(d => d.Room)
                    .WithMany(p => p.Appointments)
                    .HasForeignKey(d => d.RoomId)
                    .HasConstraintName("FK__Appointme__RoomI__3D5E1FD2");

                entity.HasOne(d => d.Service)
                    .WithMany(p => p.Appointments)
                    .HasForeignKey(d => d.ServiceId)
                    .HasConstraintName("FK__Appointme__Servi__403A8C7D");

                entity.HasOne(d => d.Spa)
                    .WithMany(p => p.Appointments)
                    .HasForeignKey(d => d.SpaId)
                    .HasConstraintName("FK__Appointme__SpaID__3C69FB99");
            });

            modelBuilder.Entity<Asset>(entity =>
            {
                entity.Property(e => e.AssetId).HasColumnName("AssetID");

                entity.Property(e => e.AssetName).HasMaxLength(100);

                entity.Property(e => e.PurchaseDate).HasColumnType("date");

                entity.Property(e => e.SpaId).HasColumnName("SpaID");

                entity.Property(e => e.Status).HasMaxLength(50);

                entity.Property(e => e.Value).HasColumnType("decimal(10, 2)");

                entity.HasOne(d => d.Spa)
                    .WithMany(p => p.Assets)
                    .HasForeignKey(d => d.SpaId)
                    .HasConstraintName("FK__Assets__SpaID__6B24EA82");
            });

            modelBuilder.Entity<Bed>(entity =>
            {
                entity.Property(e => e.BedId).HasColumnName("BedID");

                entity.Property(e => e.BedName).HasMaxLength(100);

                entity.Property(e => e.MaintenanceDate).HasColumnType("date");

                entity.Property(e => e.RoomId).HasColumnName("RoomID");

                entity.Property(e => e.Status).HasMaxLength(50);

                entity.HasOne(d => d.Room)
                    .WithMany(p => p.Beds)
                    .HasForeignKey(d => d.RoomId)
                    .HasConstraintName("FK__Beds__RoomID__76969D2E");
            });

            modelBuilder.Entity<Bulletin>(entity =>
            {
                entity.Property(e => e.BulletinId).HasColumnName("BulletinID");

                entity.Property(e => e.PostedDate).HasColumnType("date");

                entity.Property(e => e.SpaId).HasColumnName("SpaID");

                entity.Property(e => e.Title).HasMaxLength(100);

                entity.HasOne(d => d.Spa)
                    .WithMany(p => p.Bulletins)
                    .HasForeignKey(d => d.SpaId)
                    .HasConstraintName("FK__Bulletins__SpaID__797309D9");
            });

            modelBuilder.Entity<Category>(entity =>
            {
                entity.ToTable("Category");

                entity.Property(e => e.CategoryId).HasColumnName("CategoryID");

                entity.Property(e => e.CategoryName).HasMaxLength(100);
            });

            modelBuilder.Entity<Customer>(entity =>
            {
                entity.Property(e => e.CustomerId)
                    .ValueGeneratedNever()
                    .HasColumnName("CustomerID");

                entity.Property(e => e.Address).HasMaxLength(255);

                entity.Property(e => e.DateOfBirth).HasColumnType("date");

                entity.Property(e => e.Email).HasMaxLength(100);

                entity.Property(e => e.FullName).HasMaxLength(100);

                entity.Property(e => e.PhoneNumber).HasMaxLength(15);

                entity.HasOne(d => d.CustomerNavigation)
                    .WithOne(p => p.Customer)
                    .HasForeignKey<Customer>(d => d.CustomerId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Customers__Custo__4316F928");
            });

            modelBuilder.Entity<CustomerSegmentation>(entity =>
            {
                entity.HasKey(e => e.SegmentId)
<<<<<<< HEAD
<<<<<<< HEAD
                    .HasName("PK__Customer__C680609B31D6F427");
=======
                    .HasName("PK__Customer__C680609BC9090BA7");
>>>>>>> 80d94dc5e6631bb94fe479a2e337b265a77ebfa9
=======
                    .HasName("PK__Customer__C680609BC9090BA7");
>>>>>>> 80d94dc5e6631bb94fe479a2e337b265a77ebfa9

                entity.ToTable("CustomerSegmentation");

                entity.Property(e => e.SegmentId).HasColumnName("SegmentID");

                entity.Property(e => e.SegmentName).HasMaxLength(100);

                entity.Property(e => e.SpaId).HasColumnName("SpaID");

                entity.HasOne(d => d.Spa)
                    .WithMany(p => p.CustomerSegmentations)
                    .HasForeignKey(d => d.SpaId)
                    .HasConstraintName("FK__CustomerS__SpaID__7F2BE32F");
            });

            modelBuilder.Entity<Employee>(entity =>
            {
                entity.Property(e => e.EmployeeId)
                    .ValueGeneratedNever()
                    .HasColumnName("EmployeeID");

                entity.Property(e => e.Email).HasMaxLength(100);

                entity.Property(e => e.FullName).HasMaxLength(100);

                entity.Property(e => e.PhoneNumber).HasMaxLength(15);

                entity.Property(e => e.Position).HasMaxLength(50);

                entity.Property(e => e.Salary).HasColumnType("decimal(10, 2)");

                entity.Property(e => e.SpaId).HasColumnName("SpaID");

                entity.HasOne(d => d.EmployeeNavigation)
                    .WithOne(p => p.Employee)
                    .HasForeignKey<Employee>(d => d.EmployeeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Employees__Emplo__45F365D3");

                entity.HasOne(d => d.Spa)
                    .WithMany(p => p.Employees)
                    .HasForeignKey(d => d.SpaId)
                    .HasConstraintName("FK__Employees__SpaID__46E78A0C");
            });

            modelBuilder.Entity<Notification>(entity =>
            {
                entity.Property(e => e.NotificationId).HasColumnName("NotificationID");

                entity.Property(e => e.NotificationDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.UserId).HasColumnName("UserID");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.Notifications)
                    .HasForeignKey(d => d.UserId)
                    .HasConstraintName("FK__Notificat__UserI__73BA3083");
            });

            modelBuilder.Entity<Permission>(entity =>
            {
                entity.Property(e => e.PermissionId).HasColumnName("PermissionID");

                entity.Property(e => e.PermissionName).HasMaxLength(100);
            });

            modelBuilder.Entity<Product>(entity =>
            {
                entity.Property(e => e.ProductId).HasColumnName("ProductID");

                entity.Property(e => e.Price).HasColumnType("decimal(10, 2)");

                entity.Property(e => e.ProductName).HasMaxLength(100);

                entity.Property(e => e.SpaId).HasColumnName("SpaID");

                entity.HasOne(d => d.Spa)
                    .WithMany(p => p.Products)
                    .HasForeignKey(d => d.SpaId)
                    .HasConstraintName("FK__Products__SpaID__52593CB8");

                entity.HasMany(d => d.Categories)
                    .WithMany(p => p.Products)
                    .UsingEntity<Dictionary<string, object>>(
                        "ProductCategory",
                        l => l.HasOne<Category>().WithMany().HasForeignKey("CategoryId").OnDelete(DeleteBehavior.ClientSetNull).HasConstraintName("FK__ProductCa__Categ__5812160E"),
                        r => r.HasOne<Product>().WithMany().HasForeignKey("ProductId").OnDelete(DeleteBehavior.ClientSetNull).HasConstraintName("FK__ProductCa__Produ__571DF1D5"),
                        j =>
                        {
<<<<<<< HEAD
<<<<<<< HEAD
                            j.HasKey("ProductId", "CategoryId").HasName("PK__ProductC__159C554F8A2A34A5");
=======
                            j.HasKey("ProductId", "CategoryId").HasName("PK__ProductC__159C554FC76578F4");
>>>>>>> 80d94dc5e6631bb94fe479a2e337b265a77ebfa9
=======
                            j.HasKey("ProductId", "CategoryId").HasName("PK__ProductC__159C554FC76578F4");
>>>>>>> 80d94dc5e6631bb94fe479a2e337b265a77ebfa9

                            j.ToTable("ProductCategories");

                            j.IndexerProperty<int>("ProductId").HasColumnName("ProductID");

                            j.IndexerProperty<int>("CategoryId").HasColumnName("CategoryID");
                        });
            });

            modelBuilder.Entity<Promotion>(entity =>
            {
                entity.Property(e => e.PromotionId).HasColumnName("PromotionID");

                entity.Property(e => e.DiscountPercentage).HasColumnType("decimal(5, 2)");

                entity.Property(e => e.EndDate).HasColumnType("date");

                entity.Property(e => e.PromotionName).HasMaxLength(100);

                entity.Property(e => e.SpaId).HasColumnName("SpaID");

                entity.Property(e => e.StartDate).HasColumnType("date");

                entity.HasOne(d => d.Spa)
                    .WithMany(p => p.Promotions)
                    .HasForeignKey(d => d.SpaId)
                    .HasConstraintName("FK__Promotion__SpaID__68487DD7");
            });

            modelBuilder.Entity<Review>(entity =>
            {
                entity.Property(e => e.ReviewId).HasColumnName("ReviewID");

                entity.Property(e => e.CustomerId).HasColumnName("CustomerID");

                entity.Property(e => e.ReviewDate).HasColumnType("date");

                entity.Property(e => e.ServiceId).HasColumnName("ServiceID");

                entity.HasOne(d => d.Customer)
                    .WithMany(p => p.Reviews)
                    .HasForeignKey(d => d.CustomerId)
                    .HasConstraintName("FK__Reviews__Custome__6EF57B66");

                entity.HasOne(d => d.Service)
                    .WithMany(p => p.Reviews)
                    .HasForeignKey(d => d.ServiceId)
                    .HasConstraintName("FK__Reviews__Service__6FE99F9F");
            });

            modelBuilder.Entity<RewardPoint>(entity =>
            {
                entity.HasKey(e => e.RewardId)
<<<<<<< HEAD
<<<<<<< HEAD
                    .HasName("PK__RewardPo__82501599F81FC558");
=======
                    .HasName("PK__RewardPo__82501599B8F2D39B");
>>>>>>> 80d94dc5e6631bb94fe479a2e337b265a77ebfa9
=======
                    .HasName("PK__RewardPo__82501599B8F2D39B");
>>>>>>> 80d94dc5e6631bb94fe479a2e337b265a77ebfa9

                entity.Property(e => e.RewardId).HasColumnName("RewardID");

                entity.Property(e => e.CustomerId).HasColumnName("CustomerID");

                entity.Property(e => e.DateEarned).HasColumnType("date");

                entity.Property(e => e.DateRedeemed).HasColumnType("date");

                entity.HasOne(d => d.Customer)
                    .WithMany(p => p.RewardPoints)
                    .HasForeignKey(d => d.CustomerId)
                    .HasConstraintName("FK__RewardPoi__Custo__7C4F7684");
            });

            modelBuilder.Entity<Role>(entity =>
            {
                entity.Property(e => e.RoleId).HasColumnName("RoleID");

                entity.Property(e => e.RoleName).HasMaxLength(50);
            });

            modelBuilder.Entity<RolePermission>(entity =>
            {
                entity.Property(e => e.RolePermissionId).HasColumnName("RolePermissionID");

                entity.Property(e => e.PermissionId).HasColumnName("PermissionID");

                entity.Property(e => e.RoleId).HasColumnName("RoleID");

                entity.HasOne(d => d.Permission)
                    .WithMany(p => p.RolePermissions)
                    .HasForeignKey(d => d.PermissionId)
                    .HasConstraintName("FK__RolePermi__Permi__31EC6D26");

                entity.HasOne(d => d.Role)
                    .WithMany(p => p.RolePermissions)
                    .HasForeignKey(d => d.RoleId)
                    .HasConstraintName("FK__RolePermi__RoleI__30F848ED");
            });

            modelBuilder.Entity<Room>(entity =>
            {
                entity.Property(e => e.RoomId).HasColumnName("RoomID");

                entity.Property(e => e.RoomName).HasMaxLength(100);

                entity.Property(e => e.SpaId).HasColumnName("SpaID");

                entity.Property(e => e.Status).HasMaxLength(50);

                entity.HasOne(d => d.Spa)
                    .WithMany(p => p.Rooms)
                    .HasForeignKey(d => d.SpaId)
                    .HasConstraintName("FK__Rooms__SpaID__2A4B4B5E");
            });

            modelBuilder.Entity<Salary>(entity =>
            {
                entity.Property(e => e.SalaryId).HasColumnName("SalaryID");

                entity.Property(e => e.BaseSalary).HasColumnType("decimal(10, 2)");

                entity.Property(e => e.EmployeeId).HasColumnName("EmployeeID");

                entity.Property(e => e.TotalSalary).HasColumnType("decimal(10, 2)");

                entity.HasOne(d => d.Employee)
                    .WithMany(p => p.Salaries)
                    .HasForeignKey(d => d.EmployeeId)
                    .HasConstraintName("FK__Salaries__Employ__5EBF139D");
            });

            modelBuilder.Entity<Sale>(entity =>
            {
                entity.Property(e => e.SaleId).HasColumnName("SaleID");

                entity.Property(e => e.CustomerId).HasColumnName("CustomerID");

                entity.Property(e => e.PaymentStatus).HasMaxLength(50);

                entity.Property(e => e.SaleDate).HasColumnType("date");

                entity.Property(e => e.SpaId).HasColumnName("SpaID");

                entity.Property(e => e.TotalAmount).HasColumnType("decimal(10, 2)");

                entity.HasOne(d => d.Customer)
                    .WithMany(p => p.Sales)
                    .HasForeignKey(d => d.CustomerId)
                    .HasConstraintName("FK__Sales__CustomerI__4F7CD00D");

                entity.HasOne(d => d.Spa)
                    .WithMany(p => p.Sales)
                    .HasForeignKey(d => d.SpaId)
                    .HasConstraintName("FK__Sales__SpaID__4E88ABD4");
            });

            modelBuilder.Entity<SaleItem>(entity =>
            {
                entity.Property(e => e.SaleItemId).HasColumnName("SaleItemID");

                entity.Property(e => e.ProductId).HasColumnName("ProductID");

                entity.Property(e => e.SaleId).HasColumnName("SaleID");

                entity.Property(e => e.TotalPrice).HasColumnType("decimal(10, 2)");

                entity.Property(e => e.UnitPrice).HasColumnType("decimal(10, 2)");

                entity.HasOne(d => d.Product)
                    .WithMany(p => p.SaleItems)
                    .HasForeignKey(d => d.ProductId)
                    .HasConstraintName("FK__SaleItems__Produ__5BE2A6F2");

                entity.HasOne(d => d.Sale)
                    .WithMany(p => p.SaleItems)
                    .HasForeignKey(d => d.SaleId)
                    .HasConstraintName("FK__SaleItems__SaleI__5AEE82B9");
            });

            modelBuilder.Entity<Service>(entity =>
            {
                entity.Property(e => e.ServiceId).HasColumnName("ServiceID");

                entity.Property(e => e.Price).HasColumnType("decimal(10, 2)");

                entity.Property(e => e.ServiceName).HasMaxLength(100);

                entity.Property(e => e.SpaId).HasColumnName("SpaID");

                entity.HasOne(d => d.Spa)
                    .WithMany(p => p.Services)
                    .HasForeignKey(d => d.SpaId)
                    .HasConstraintName("FK__Services__SpaID__398D8EEE");
            });

            modelBuilder.Entity<ServiceCard>(entity =>
            {
                entity.Property(e => e.ServiceCardId).HasColumnName("ServiceCardID");

                entity.Property(e => e.CustomerId).HasColumnName("CustomerID");

                entity.Property(e => e.ExpiryDate).HasColumnType("date");

                entity.Property(e => e.PurchaseDate).HasColumnType("date");

                entity.Property(e => e.ServiceId).HasColumnName("ServiceID");

                entity.Property(e => e.SpaId).HasColumnName("SpaID");

                entity.Property(e => e.Status).HasMaxLength(50);

                entity.HasOne(d => d.Customer)
                    .WithMany(p => p.ServiceCards)
                    .HasForeignKey(d => d.CustomerId)
                    .HasConstraintName("FK__ServiceCa__Custo__4BAC3F29");

                entity.HasOne(d => d.Service)
                    .WithMany(p => p.ServiceCards)
                    .HasForeignKey(d => d.ServiceId)
                    .HasConstraintName("FK__ServiceCa__Servi__4AB81AF0");

                entity.HasOne(d => d.Spa)
                    .WithMany(p => p.ServiceCards)
                    .HasForeignKey(d => d.SpaId)
                    .HasConstraintName("FK__ServiceCa__SpaID__49C3F6B7");
            });

            modelBuilder.Entity<Spa>(entity =>
            {
                entity.Property(e => e.SpaId).HasColumnName("SpaID");

                entity.Property(e => e.Email).HasMaxLength(100);

                entity.Property(e => e.Location).HasMaxLength(255);

                entity.Property(e => e.ManagerId).HasColumnName("ManagerID");

                entity.Property(e => e.PhoneNumber).HasMaxLength(15);

                entity.Property(e => e.SpaName).HasMaxLength(100);

                entity.HasOne(d => d.Manager)
                    .WithMany(p => p.Spas)
                    .HasForeignKey(d => d.ManagerId)
                    .HasConstraintName("FK__Spas__ManagerID__276EDEB3");
            });

            modelBuilder.Entity<SystemSetting>(entity =>
            {
                entity.HasKey(e => e.SettingId)
<<<<<<< HEAD
<<<<<<< HEAD
                    .HasName("PK__SystemSe__54372AFD913D4C80");
=======
                    .HasName("PK__SystemSe__54372AFDE6BEEEB5");
>>>>>>> 80d94dc5e6631bb94fe479a2e337b265a77ebfa9
=======
                    .HasName("PK__SystemSe__54372AFDE6BEEEB5");
>>>>>>> 80d94dc5e6631bb94fe479a2e337b265a77ebfa9

                entity.Property(e => e.SettingId).HasColumnName("SettingID");

                entity.Property(e => e.SettingName).HasMaxLength(100);
            });

            modelBuilder.Entity<Transaction>(entity =>
            {
                entity.Property(e => e.TransactionId).HasColumnName("TransactionID");

                entity.Property(e => e.Amount).HasColumnType("decimal(10, 2)");

                entity.Property(e => e.CustomerId).HasColumnName("CustomerID");

                entity.Property(e => e.SpaId).HasColumnName("SpaID");

                entity.Property(e => e.TransactionDate).HasColumnType("date");

                entity.Property(e => e.TransactionType).HasMaxLength(50);

                entity.HasOne(d => d.Customer)
                    .WithMany(p => p.Transactions)
                    .HasForeignKey(d => d.CustomerId)
                    .HasConstraintName("FK__Transacti__Custo__656C112C");

                entity.HasOne(d => d.Spa)
                    .WithMany(p => p.Transactions)
                    .HasForeignKey(d => d.SpaId)
                    .HasConstraintName("FK__Transacti__SpaID__6477ECF3");
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.Property(e => e.UserId).HasColumnName("UserID");

                entity.Property(e => e.Address).HasMaxLength(1000);

                entity.Property(e => e.DateOfBirth).HasColumnType("date");

                entity.Property(e => e.DateRegistered)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Email).HasMaxLength(100);

                entity.Property(e => e.Password).HasMaxLength(255);

                entity.Property(e => e.PhoneNumber).HasMaxLength(15);

                entity.Property(e => e.Username).HasMaxLength(50);
            });

            modelBuilder.Entity<UserRole>(entity =>
            {
                entity.Property(e => e.UserRoleId).HasColumnName("UserRoleID");

                entity.Property(e => e.RoleId).HasColumnName("RoleID");

                entity.Property(e => e.SpaId).HasColumnName("SpaID");

                entity.Property(e => e.UserId).HasColumnName("UserID");

                entity.HasOne(d => d.Role)
                    .WithMany(p => p.UserRoles)
                    .HasForeignKey(d => d.RoleId)
                    .HasConstraintName("FK__UserRoles__RoleI__36B12243");

                entity.HasOne(d => d.Spa)
                    .WithMany(p => p.UserRoles)
                    .HasForeignKey(d => d.SpaId)
                    .HasConstraintName("FK__UserRoles__SpaID__35BCFE0A");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.UserRoles)
                    .HasForeignKey(d => d.UserId)
                    .HasConstraintName("FK__UserRoles__UserI__34C8D9D1");
            });

            modelBuilder.Entity<WorkSchedule>(entity =>
            {
                entity.Property(e => e.WorkScheduleId).HasColumnName("WorkScheduleID");

                entity.Property(e => e.DayOfWeek).HasMaxLength(20);

                entity.Property(e => e.EmployeeId).HasColumnName("EmployeeID");

                entity.Property(e => e.EndDate).HasColumnType("date");

                entity.Property(e => e.StartDate).HasColumnType("date");

                entity.HasOne(d => d.Employee)
                    .WithMany(p => p.WorkSchedules)
                    .HasForeignKey(d => d.EmployeeId)
                    .HasConstraintName("FK__WorkSched__Emplo__619B8048");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
