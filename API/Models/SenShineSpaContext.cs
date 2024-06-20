using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace API.Models
{
    public partial class SenShineSpaContext : DbContext
    {
        public SenShineSpaContext()
        {
        }

        public SenShineSpaContext(DbContextOptions<SenShineSpaContext> options)
            : base(options)
        {
        }

        public virtual DbSet<AdministrativeRegion> AdministrativeRegions { get; set; } = null!;
        public virtual DbSet<AdministrativeUnit> AdministrativeUnits { get; set; } = null!;
        public virtual DbSet<Appointment> Appointments { get; set; } = null!;
        public virtual DbSet<Bed> Beds { get; set; } = null!;
        public virtual DbSet<Card> Cards { get; set; } = null!;
        public virtual DbSet<Category> Categories { get; set; } = null!;
        public virtual DbSet<Customer> Customers { get; set; } = null!;
        public virtual DbSet<District> Districts { get; set; } = null!;
        public virtual DbSet<Employee> Employees { get; set; } = null!;
        public virtual DbSet<Image> Images { get; set; } = null!;
        public virtual DbSet<ImageHomePage> ImageHomePages { get; set; } = null!;
        public virtual DbSet<Invoice> Invoices { get; set; } = null!;
        public virtual DbSet<News> News { get; set; } = null!;
        public virtual DbSet<Notification> Notifications { get; set; } = null!;
        //public virtual DbSet<Permission> Permissions { get; set; } = null!;
        public virtual DbSet<Product> Products { get; set; } = null!;
        public virtual DbSet<Promotion> Promotions { get; set; } = null!;
        public virtual DbSet<Province> Provinces { get; set; } = null!;
        public virtual DbSet<Review> Reviews { get; set; } = null!;
        public virtual DbSet<Role> Roles { get; set; } = null!;
        public virtual DbSet<Room> Rooms { get; set; } = null!;
        public virtual DbSet<Salary> Salaries { get; set; } = null!;
        public virtual DbSet<Service> Services { get; set; } = null!;
        public virtual DbSet<Spa> Spas { get; set; } = null!;
        public virtual DbSet<User> Users { get; set; } = null!;
        public virtual DbSet<Ward> Wards { get; set; } = null!;
        public virtual DbSet<WorkSchedule> WorkSchedules { get; set; } = null!;

//        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
//        {
//            if (!optionsBuilder.IsConfigured)
//            {
//                optionsBuilder.UseSqlServer("server=(local);database=SenShineSpa;uid=sa;pwd=123456;TrustServerCertificate=True;");
//            }
//        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<AdministrativeRegion>(entity =>
            {
                entity.ToTable("administrative_regions");

                entity.Property(e => e.Id)
                    .ValueGeneratedNever()
                    .HasColumnName("id");

                entity.Property(e => e.CodeName)
                    .HasMaxLength(255)
                    .HasColumnName("code_name");

                entity.Property(e => e.CodeNameEn)
                    .HasMaxLength(255)
                    .HasColumnName("code_name_en");

                entity.Property(e => e.Name)
                    .HasMaxLength(255)
                    .HasColumnName("name");

                entity.Property(e => e.NameEn)
                    .HasMaxLength(255)
                    .HasColumnName("name_en");
            });

            modelBuilder.Entity<AdministrativeUnit>(entity =>
            {
                entity.ToTable("administrative_units");

                entity.Property(e => e.Id)
                    .ValueGeneratedNever()
                    .HasColumnName("id");

                entity.Property(e => e.CodeName)
                    .HasMaxLength(255)
                    .HasColumnName("code_name");

                entity.Property(e => e.CodeNameEn)
                    .HasMaxLength(255)
                    .HasColumnName("code_name_en");

                entity.Property(e => e.FullName)
                    .HasMaxLength(255)
                    .HasColumnName("full_name");

                entity.Property(e => e.FullNameEn)
                    .HasMaxLength(255)
                    .HasColumnName("full_name_en");

                entity.Property(e => e.ShortName)
                    .HasMaxLength(255)
                    .HasColumnName("short_name");

                entity.Property(e => e.ShortNameEn)
                    .HasMaxLength(255)
                    .HasColumnName("short_name_en");
            });

            modelBuilder.Entity<Appointment>(entity =>
            {
                entity.HasKey(e => e.IdAppointment)
                    .HasName("PK__Appointm__CE24CCCC44949E12");

                entity.ToTable("Appointment");

                entity.Property(e => e.IdAppointment).HasColumnName("ID_Appointment");

                entity.Property(e => e.AppointmentDate).HasColumnType("datetime");

                entity.Property(e => e.CustomerId).HasColumnName("CustomerID");

                entity.Property(e => e.IdEmployee).HasColumnName("ID_Employee");

                entity.HasOne(d => d.Customer)
                    .WithMany(p => p.Appointments)
                    .HasForeignKey(d => d.CustomerId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Appointme__Custo__6383C8BA");

                entity.HasOne(d => d.IdEmployeeNavigation)
                    .WithMany(p => p.Appointments)
                    .HasForeignKey(d => d.IdEmployee)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Appointme__ID_Em__6477ECF3");

                entity.HasMany(d => d.Products)
                    .WithMany(p => p.Appointments)
                    .UsingEntity<Dictionary<string, object>>(
                        "AppointmentProduct",
                        l => l.HasOne<Product>().WithMany().HasForeignKey("ProductId").OnDelete(DeleteBehavior.ClientSetNull).HasConstraintName("FK__Appointme__Produ__6C190EBB"),
                        r => r.HasOne<Appointment>().WithMany().HasForeignKey("AppointmentId").OnDelete(DeleteBehavior.ClientSetNull).HasConstraintName("FK__Appointme__Appoi__6B24EA82"),
                        j =>
                        {
                            j.HasKey("AppointmentId", "ProductId").HasName("PK__Appointm__458D30CCA1C25A0C");

                            j.ToTable("Appointment_Product");

                            j.IndexerProperty<int>("AppointmentId").HasColumnName("AppointmentID");

                            j.IndexerProperty<int>("ProductId").HasColumnName("ProductID");
                        });

                entity.HasMany(d => d.Services)
                    .WithMany(p => p.Appointments)
                    .UsingEntity<Dictionary<string, object>>(
                        "AppointmentService",
                        l => l.HasOne<Service>().WithMany().HasForeignKey("ServiceId").OnDelete(DeleteBehavior.ClientSetNull).HasConstraintName("FK__Appointme__Servi__68487DD7"),
                        r => r.HasOne<Appointment>().WithMany().HasForeignKey("AppointmentId").OnDelete(DeleteBehavior.ClientSetNull).HasConstraintName("FK__Appointme__Appoi__6754599E"),
                        j =>
                        {
                            j.HasKey("AppointmentId", "ServiceId").HasName("PK__Appointm__329C47AC378A3F8B");

                            j.ToTable("Appointment_Service");

                            j.IndexerProperty<int>("AppointmentId").HasColumnName("AppointmentID");

                            j.IndexerProperty<int>("ServiceId").HasColumnName("ServiceID");
                        });
            });

            modelBuilder.Entity<Bed>(entity =>
            {
                entity.HasKey(e => e.IdBed)
                    .HasName("PK__Bed__142BA56A752E5C44");

                entity.ToTable("Bed");

                entity.Property(e => e.IdBed).HasColumnName("ID_Bed");

                entity.Property(e => e.BedNumber).HasMaxLength(50);
            });

            modelBuilder.Entity<Card>(entity =>
            {
                entity.HasKey(e => e.IdCard)
                    .HasName("PK__Card__72140EDF2E5A3CE9");

                entity.ToTable("Card");

                entity.Property(e => e.IdCard).HasColumnName("ID_Card");

                entity.Property(e => e.CardNumber).HasMaxLength(50);

                entity.HasMany(d => d.IdSers)
                    .WithMany(p => p.IdCards)
                    .UsingEntity<Dictionary<string, object>>(
                        "CardService",
                        l => l.HasOne<Service>().WithMany().HasForeignKey("IdSer").OnDelete(DeleteBehavior.ClientSetNull).HasConstraintName("FK__Card_Serv__ID_Se__3E52440B"),
                        r => r.HasOne<Card>().WithMany().HasForeignKey("IdCard").OnDelete(DeleteBehavior.ClientSetNull).HasConstraintName("FK__Card_Serv__ID_Ca__3D5E1FD2"),
                        j =>
                        {
                            j.HasKey("IdCard", "IdSer").HasName("PK__Card_Ser__A06B8FD75E1A1B54");

                            j.ToTable("Card_Service");

                            j.IndexerProperty<int>("IdCard").HasColumnName("ID_Card");

                            j.IndexerProperty<int>("IdSer").HasColumnName("ID_Ser");
                        });
            });

            modelBuilder.Entity<Category>(entity =>
            {
                entity.ToTable("Category");

                entity.Property(e => e.CategoryId).HasColumnName("CategoryID");

                entity.Property(e => e.CategoryName).HasMaxLength(100);
            });

            modelBuilder.Entity<Customer>(entity =>
            {
                entity.HasKey(e => e.IdCus)
                    .HasName("PK__Customer__2BFE53FC1198DE79");

                entity.ToTable("Customer");

                entity.Property(e => e.IdCus).HasColumnName("ID_Cus");

                entity.Property(e => e.Name).HasMaxLength(100);

                entity.Property(e => e.Phone)
                    .HasMaxLength(11)
                    .IsUnicode(false);

                entity.HasMany(d => d.IdCards)
                    .WithMany(p => p.IdCus)
                    .UsingEntity<Dictionary<string, object>>(
                        "CustomerCard",
                        l => l.HasOne<Card>().WithMany().HasForeignKey("IdCard").OnDelete(DeleteBehavior.ClientSetNull).HasConstraintName("FK__Customer___ID_Ca__4222D4EF"),
                        r => r.HasOne<Customer>().WithMany().HasForeignKey("IdCus").OnDelete(DeleteBehavior.ClientSetNull).HasConstraintName("FK__Customer___ID_Cu__412EB0B6"),
                        j =>
                        {
                            j.HasKey("IdCus", "IdCard").HasName("PK__Customer__CCDF1311649A6F5B");

                            j.ToTable("Customer_Card");

                            j.IndexerProperty<int>("IdCus").HasColumnName("ID_Cus");

                            j.IndexerProperty<int>("IdCard").HasColumnName("ID_Card");
                        });
            });

            modelBuilder.Entity<District>(entity =>
            {
                entity.HasKey(e => e.Code)
                    .HasName("districts_pkey");

                entity.ToTable("districts");

                entity.HasIndex(e => e.ProvinceCode, "idx_districts_province");

                entity.HasIndex(e => e.AdministrativeUnitId, "idx_districts_unit");

                entity.Property(e => e.Code)
                    .HasMaxLength(20)
                    .HasColumnName("code");

                entity.Property(e => e.AdministrativeUnitId).HasColumnName("administrative_unit_id");

                entity.Property(e => e.CodeName)
                    .HasMaxLength(255)
                    .HasColumnName("code_name");

                entity.Property(e => e.FullName)
                    .HasMaxLength(255)
                    .HasColumnName("full_name");

                entity.Property(e => e.FullNameEn)
                    .HasMaxLength(255)
                    .HasColumnName("full_name_en");

                entity.Property(e => e.Name)
                    .HasMaxLength(255)
                    .HasColumnName("name");

                entity.Property(e => e.NameEn)
                    .HasMaxLength(255)
                    .HasColumnName("name_en");

                entity.Property(e => e.ProvinceCode)
                    .HasMaxLength(20)
                    .HasColumnName("province_code");

                entity.HasOne(d => d.AdministrativeUnit)
                    .WithMany(p => p.Districts)
                    .HasForeignKey(d => d.AdministrativeUnitId)
                    .HasConstraintName("districts_administrative_unit_id_fkey");

                entity.HasOne(d => d.ProvinceCodeNavigation)
                    .WithMany(p => p.Districts)
                    .HasForeignKey(d => d.ProvinceCode)
                    .HasConstraintName("districts_province_code_fkey");
            });

            modelBuilder.Entity<Employee>(entity =>
            {
                entity.HasKey(e => e.IdEmployee)
                    .HasName("PK__Employee__D9EE4F36637C0FDD");

                entity.ToTable("Employee");

                entity.Property(e => e.IdEmployee).HasColumnName("ID_Employee");

                entity.Property(e => e.Address).HasMaxLength(50);

                entity.Property(e => e.BirthDate).HasColumnType("date");

                entity.Property(e => e.FirstName).HasMaxLength(50);

                entity.Property(e => e.IdUser).HasColumnName("ID_User");

                entity.Property(e => e.LastName).HasMaxLength(50);

                entity.Property(e => e.Location).HasMaxLength(50);

                entity.HasOne(d => d.IdUserNavigation)
                    .WithMany(p => p.Employees)
                    .HasForeignKey(d => d.IdUser)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Employee__ID_Use__31EC6D26");
            });

            modelBuilder.Entity<Image>(entity =>
            {
                entity.HasKey(e => e.IdImg)
                    .HasName("PK__Image__2C7D296CAFC6AFD8");

                entity.ToTable("Image");

                entity.Property(e => e.IdImg).HasColumnName("ID_Img");

                entity.Property(e => e.ImageUrl)
                    .HasMaxLength(255)
                    .HasColumnName("ImageURL");
            });

            modelBuilder.Entity<ImageHomePage>(entity =>
            {
                entity.HasKey(e => e.IdImgHomePage)
                    .HasName("PK__ImageHom__7906BD263268BC57");

                entity.ToTable("ImageHomePage");

                entity.Property(e => e.IdImgHomePage).HasColumnName("ID_ImgHomePage");

                entity.Property(e => e.ImageUrl)
                    .HasMaxLength(255)
                    .HasColumnName("ImageURL");
            });

            modelBuilder.Entity<Invoice>(entity =>
            {
                entity.ToTable("Invoice");

                entity.Property(e => e.InvoiceId).HasColumnName("InvoiceID");

                entity.Property(e => e.Amount).HasColumnType("decimal(10, 2)");

                entity.Property(e => e.CustomerId).HasColumnName("CustomerID");

                entity.Property(e => e.InvoiceDate).HasColumnType("date");

                entity.Property(e => e.PromotionId).HasColumnName("PromotionID");

                entity.Property(e => e.SpaId).HasColumnName("SpaID");

                entity.HasOne(d => d.Customer)
                    .WithMany(p => p.Invoices)
                    .HasForeignKey(d => d.CustomerId)
                    .HasConstraintName("FK__Invoice__Custome__7E37BEF6");

                entity.HasOne(d => d.Promotion)
                    .WithMany(p => p.Invoices)
                    .HasForeignKey(d => d.PromotionId)
                    .HasConstraintName("FK__Invoice__Promoti__7F2BE32F");

                entity.HasOne(d => d.Spa)
                    .WithMany(p => p.Invoices)
                    .HasForeignKey(d => d.SpaId)
                    .HasConstraintName("FK__Invoice__SpaID__7D439ABD");

                entity.HasMany(d => d.Services)
                    .WithMany(p => p.Invoices)
                    .UsingEntity<Dictionary<string, object>>(
                        "InvoiceService",
                        l => l.HasOne<Service>().WithMany().HasForeignKey("ServiceId").OnDelete(DeleteBehavior.ClientSetNull).HasConstraintName("FK__Invoice_S__Servi__02FC7413"),
                        r => r.HasOne<Invoice>().WithMany().HasForeignKey("InvoiceId").OnDelete(DeleteBehavior.ClientSetNull).HasConstraintName("FK__Invoice_S__Invoi__02084FDA"),
                        j =>
                        {
                            j.HasKey("InvoiceId", "ServiceId").HasName("PK__Invoice___6BC711DB58A3CE2D");

                            j.ToTable("Invoice_Service");

                            j.IndexerProperty<int>("InvoiceId").HasColumnName("InvoiceID");

                            j.IndexerProperty<int>("ServiceId").HasColumnName("ServiceID");
                        });
            });

            modelBuilder.Entity<News>(entity =>
            {
                entity.HasKey(e => e.IdNew)
                    .HasName("PK__News__253A42695BF4E914");

                entity.Property(e => e.IdNew).HasColumnName("ID_New");

                entity.Property(e => e.Content).HasColumnType("text");

                entity.Property(e => e.PublishedDate).HasColumnType("datetime");

                entity.Property(e => e.Title).HasMaxLength(255);
            });

            modelBuilder.Entity<Notification>(entity =>
            {
                entity.Property(e => e.NotificationId).HasColumnName("NotificationID");

                entity.Property(e => e.IsRead).HasColumnName("Is_Read");

                entity.Property(e => e.NotificationDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.UserId).HasColumnName("UserID");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.Notifications)
                    .HasForeignKey(d => d.UserId)
                    .HasConstraintName("FK__Notificat__UserI__778AC167");
            });

            /*modelBuilder.Entity<Permission>(entity =>
            {
                entity.HasKey(e => e.IdPer)
                    .HasName("PK__Permissi__20AEE6F63AEF0436");

                entity.ToTable("Permission");

                entity.Property(e => e.IdPer).HasColumnName("ID_Per");

                entity.Property(e => e.PerName).HasMaxLength(50);
            });*/

            modelBuilder.Entity<Product>(entity =>
            {
                entity.HasKey(e => e.IdProduct)
                    .HasName("PK__Product__522DE496B42A4390");

                entity.ToTable("Product");

                entity.Property(e => e.IdProduct).HasColumnName("ID_Product");

                entity.Property(e => e.Price).HasColumnType("decimal(18, 2)");

                entity.Property(e => e.ProductName).HasMaxLength(100);

                entity.HasMany(d => d.Categories)
                    .WithMany(p => p.Products)
                    .UsingEntity<Dictionary<string, object>>(
                        "ProductCategory",
                        l => l.HasOne<Category>().WithMany().HasForeignKey("CategoryId").OnDelete(DeleteBehavior.ClientSetNull).HasConstraintName("FK__ProductCa__Categ__571DF1D5"),
                        r => r.HasOne<Product>().WithMany().HasForeignKey("ProductId").OnDelete(DeleteBehavior.ClientSetNull).HasConstraintName("FK__ProductCa__Produ__5629CD9C"),
                        j =>
                        {
                            j.HasKey("ProductId", "CategoryId").HasName("PK__ProductC__159C554F996EA334");

                            j.ToTable("ProductCategories");

                            j.IndexerProperty<int>("ProductId").HasColumnName("ProductID");

                            j.IndexerProperty<int>("CategoryId").HasColumnName("CategoryID");
                        });

                entity.HasMany(d => d.IdImgs)
                    .WithMany(p => p.IdProducts)
                    .UsingEntity<Dictionary<string, object>>(
                        "ProductImg",
                        l => l.HasOne<Image>().WithMany().HasForeignKey("IdImg").OnDelete(DeleteBehavior.ClientSetNull).HasConstraintName("FK__Product_I__ID_Im__5CD6CB2B"),
                        r => r.HasOne<Product>().WithMany().HasForeignKey("IdProduct").OnDelete(DeleteBehavior.ClientSetNull).HasConstraintName("FK__Product_I__ID_Pr__5BE2A6F2"),
                        j =>
                        {
                            j.HasKey("IdProduct", "IdImg").HasName("PK__Product___80EA36003F3BB847");

                            j.ToTable("Product_Img");

                            j.IndexerProperty<int>("IdProduct").HasColumnName("ID_Product");

                            j.IndexerProperty<int>("IdImg").HasColumnName("ID_Img");
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
                    .HasConstraintName("FK__Promotion__SpaID__7A672E12");
            });

            modelBuilder.Entity<Province>(entity =>
            {
                entity.HasKey(e => e.Code)
                    .HasName("provinces_pkey");

                entity.ToTable("provinces");

                entity.HasIndex(e => e.AdministrativeRegionId, "idx_provinces_region");

                entity.HasIndex(e => e.AdministrativeUnitId, "idx_provinces_unit");

                entity.Property(e => e.Code)
                    .HasMaxLength(20)
                    .HasColumnName("code");

                entity.Property(e => e.AdministrativeRegionId).HasColumnName("administrative_region_id");

                entity.Property(e => e.AdministrativeUnitId).HasColumnName("administrative_unit_id");

                entity.Property(e => e.CodeName)
                    .HasMaxLength(255)
                    .HasColumnName("code_name");

                entity.Property(e => e.FullName)
                    .HasMaxLength(255)
                    .HasColumnName("full_name");

                entity.Property(e => e.FullNameEn)
                    .HasMaxLength(255)
                    .HasColumnName("full_name_en");

                entity.Property(e => e.Name)
                    .HasMaxLength(255)
                    .HasColumnName("name");

                entity.Property(e => e.NameEn)
                    .HasMaxLength(255)
                    .HasColumnName("name_en");

                entity.HasOne(d => d.AdministrativeRegion)
                    .WithMany(p => p.Provinces)
                    .HasForeignKey(d => d.AdministrativeRegionId)
                    .HasConstraintName("provinces_administrative_region_id_fkey");

                entity.HasOne(d => d.AdministrativeUnit)
                    .WithMany(p => p.Provinces)
                    .HasForeignKey(d => d.AdministrativeUnitId)
                    .HasConstraintName("provinces_administrative_unit_id_fkey");
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
                    .HasConstraintName("FK__Reviews__Custome__6FE99F9F");

                entity.HasOne(d => d.Service)
                    .WithMany(p => p.Reviews)
                    .HasForeignKey(d => d.ServiceId)
                    .HasConstraintName("FK__Reviews__Service__70DDC3D8");
            });

            modelBuilder.Entity<Role>(entity =>
            {
                entity.HasKey(e => e.IdRole)
                    .HasName("PK__Role__43DCD32D22964C98");

                entity.ToTable("Role");

                entity.Property(e => e.IdRole).HasColumnName("ID_Role");

                entity.Property(e => e.RoleName).HasMaxLength(50);

               /*entity.HasMany(d => d.IdPers)
                    .WithMany(p => p.IdRoles)
                    .UsingEntity<Dictionary<string, object>>(
                        "RolePermission",
                        l => l.HasOne<Permission>().WithMany().HasForeignKey("IdPer").OnDelete(DeleteBehavior.ClientSetNull).HasConstraintName("FK__Role_Perm__ID_Pe__2B3F6F97"),
                        r => r.HasOne<Role>().WithMany().HasForeignKey("IdRole").OnDelete(DeleteBehavior.ClientSetNull).HasConstraintName("FK__Role_Perm__ID_Ro__2A4B4B5E"),
                        j =>
                        {
                            j.HasKey("IdRole", "IdPer").HasName("PK__Role_Per__31D63D42809CDAD4");

                            j.ToTable("Role_Permission");

                            j.IndexerProperty<int>("IdRole").HasColumnName("ID_Role");

                            j.IndexerProperty<int>("IdPer").HasColumnName("ID_Per");
                        });*/
            });

            modelBuilder.Entity<Room>(entity =>
            {
                entity.HasKey(e => e.IdRoom)
                    .HasName("PK__Room__43DC0E41E32733E2");

                entity.ToTable("Room");

                entity.Property(e => e.IdRoom).HasColumnName("ID_Room");

                entity.Property(e => e.RoomName).HasMaxLength(100);

                entity.HasMany(d => d.IdBeds)
                    .WithMany(p => p.IdRooms)
                    .UsingEntity<Dictionary<string, object>>(
                        "RoomBed",
                        l => l.HasOne<Bed>().WithMany().HasForeignKey("IdBed").OnDelete(DeleteBehavior.ClientSetNull).HasConstraintName("FK__Room_Bed__ID_Bed__4F7CD00D"),
                        r => r.HasOne<Room>().WithMany().HasForeignKey("IdRoom").OnDelete(DeleteBehavior.ClientSetNull).HasConstraintName("FK__Room_Bed__ID_Roo__4E88ABD4"),
                        j =>
                        {
                            j.HasKey("IdRoom", "IdBed").HasName("PK__Room_Bed__F29EB41701EC13ED");

                            j.ToTable("Room_Bed");

                            j.IndexerProperty<int>("IdRoom").HasColumnName("ID_Room");

                            j.IndexerProperty<int>("IdBed").HasColumnName("ID_Bed");
                        });
            });

            modelBuilder.Entity<Salary>(entity =>
            {
                entity.HasKey(e => e.IdSalary)
                    .HasName("PK__Salary__28CBC2C45D3D95B5");

                entity.ToTable("Salary");

                entity.Property(e => e.IdSalary).HasColumnName("ID_Salary");

                entity.Property(e => e.BaseSalary).HasColumnType("decimal(10, 2)");

                entity.Property(e => e.IdEmployee).HasColumnName("ID_Employee");

                entity.Property(e => e.TotalSalary).HasColumnType("decimal(10, 2)");

                entity.HasOne(d => d.IdEmployeeNavigation)
                    .WithMany(p => p.Salaries)
                    .HasForeignKey(d => d.IdEmployee)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Salary__ID_Emplo__34C8D9D1");
            });

            modelBuilder.Entity<Service>(entity =>
            {
                entity.HasKey(e => e.IdSer)
                    .HasName("PK__Service__27F8108CEB3B49C4");

                entity.ToTable("Service");

                entity.Property(e => e.IdSer).HasColumnName("ID_Ser");

                entity.Property(e => e.Description).HasMaxLength(255);

                entity.Property(e => e.ServiceName).HasMaxLength(100);
            });

            modelBuilder.Entity<Spa>(entity =>
            {
                entity.HasKey(e => e.IdSpa)
                    .HasName("PK__Spa__27F83923A6D6C2E7");

                entity.ToTable("Spa");

                entity.Property(e => e.IdSpa).HasColumnName("ID_Spa");

                entity.Property(e => e.Address).HasMaxLength(50);

                entity.Property(e => e.Location).HasMaxLength(100);

                entity.Property(e => e.SpaName).HasMaxLength(100);

                entity.HasMany(d => d.IdRooms)
                    .WithMany(p => p.IdSpas)
                    .UsingEntity<Dictionary<string, object>>(
                        "SpaRoom",
                        l => l.HasOne<Room>().WithMany().HasForeignKey("IdRoom").OnDelete(DeleteBehavior.ClientSetNull).HasConstraintName("FK__Spa_Room__ID_Roo__49C3F6B7"),
                        r => r.HasOne<Spa>().WithMany().HasForeignKey("IdSpa").OnDelete(DeleteBehavior.ClientSetNull).HasConstraintName("FK__Spa_Room__ID_Spa__48CFD27E"),
                        j =>
                        {
                            j.HasKey("IdSpa", "IdRoom").HasName("PK__Spa_Room__23C5F9C705E72523");

                            j.ToTable("Spa_Room");

                            j.IndexerProperty<int>("IdSpa").HasColumnName("ID_Spa");

                            j.IndexerProperty<int>("IdRoom").HasColumnName("ID_Room");
                        });
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.HasKey(e => e.IdUser)
                    .HasName("PK__User__ED4DE442BBDF7F72");

                entity.ToTable("User");

                entity.Property(e => e.IdUser).HasColumnName("ID_User");

                entity.Property(e => e.Password)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.UserName)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.HasMany(d => d.IdRoles)
                    .WithMany(p => p.IdUsers)
                    .UsingEntity<Dictionary<string, object>>(
                        "UserRole",
                        l => l.HasOne<Role>().WithMany().HasForeignKey("IdRole").OnDelete(DeleteBehavior.ClientSetNull).HasConstraintName("FK__User_Role__ID_Ro__2F10007B"),
                        r => r.HasOne<User>().WithMany().HasForeignKey("IdUser").OnDelete(DeleteBehavior.ClientSetNull).HasConstraintName("FK__User_Role__ID_Us__2E1BDC42"),
                        j =>
                        {
                            j.HasKey("IdUser", "IdRole").HasName("PK__User_Rol__2970297099C439DC");

                            j.ToTable("User_Role");

                            j.IndexerProperty<int>("IdUser").HasColumnName("ID_User");

                            j.IndexerProperty<int>("IdRole").HasColumnName("ID_Role");
                        });
            });

            modelBuilder.Entity<Ward>(entity =>
            {
                entity.HasKey(e => e.Code)
                    .HasName("wards_pkey");

                entity.ToTable("wards");

                entity.HasIndex(e => e.DistrictCode, "idx_wards_district");

                entity.HasIndex(e => e.AdministrativeUnitId, "idx_wards_unit");

                entity.Property(e => e.Code)
                    .HasMaxLength(20)
                    .HasColumnName("code");

                entity.Property(e => e.AdministrativeUnitId).HasColumnName("administrative_unit_id");

                entity.Property(e => e.CodeName)
                    .HasMaxLength(255)
                    .HasColumnName("code_name");

                entity.Property(e => e.DistrictCode)
                    .HasMaxLength(20)
                    .HasColumnName("district_code");

                entity.Property(e => e.FullName)
                    .HasMaxLength(255)
                    .HasColumnName("full_name");

                entity.Property(e => e.FullNameEn)
                    .HasMaxLength(255)
                    .HasColumnName("full_name_en");

                entity.Property(e => e.Name)
                    .HasMaxLength(255)
                    .HasColumnName("name");

                entity.Property(e => e.NameEn)
                    .HasMaxLength(255)
                    .HasColumnName("name_en");

                entity.HasOne(d => d.AdministrativeUnit)
                    .WithMany(p => p.Wards)
                    .HasForeignKey(d => d.AdministrativeUnitId)
                    .HasConstraintName("wards_administrative_unit_id_fkey");

                entity.HasOne(d => d.DistrictCodeNavigation)
                    .WithMany(p => p.Wards)
                    .HasForeignKey(d => d.DistrictCode)
                    .HasConstraintName("wards_district_code_fkey");
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
                    .HasConstraintName("FK__WorkSched__Emplo__73BA3083");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
