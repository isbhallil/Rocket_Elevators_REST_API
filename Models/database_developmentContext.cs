using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Rocket_REST_API.Models
{
    public partial class database_developmentContext : DbContext
    {
        public database_developmentContext()
        {
        }

        public database_developmentContext(DbContextOptions<database_developmentContext> options)
            : base(options)
        {
        }

        public virtual DbSet<ActiveStorageAttachments> ActiveStorageAttachments { get; set; }
        public virtual DbSet<ActiveStorageBlobs> ActiveStorageBlobs { get; set; }
        public virtual DbSet<ActiveStorageData> ActiveStorageData { get; set; }
        public virtual DbSet<Addresses> Addresses { get; set; }
        public virtual DbSet<ArInternalMetadata> ArInternalMetadata { get; set; }
        public virtual DbSet<Awards> Awards { get; set; }
        public virtual DbSet<Batteries> Batteries { get; set; }
        public virtual DbSet<BuildingDetails> BuildingDetails { get; set; }
        public virtual DbSet<Buildings> Buildings { get; set; }
        public virtual DbSet<Clients> Clients { get; set; }
        public virtual DbSet<Columns> Columns { get; set; }
        public virtual DbSet<Customers> Customers { get; set; }
        public virtual DbSet<Elevators> Elevators { get; set; }
        public virtual DbSet<Employees> Employees { get; set; }
        public virtual DbSet<Interventions> Interventions { get; set; }
        public virtual DbSet<Leads> Leads { get; set; }
        public virtual DbSet<Navs> Navs { get; set; }
        public virtual DbSet<News> News { get; set; }
        public virtual DbSet<Quotes> Quotes { get; set; }
        public virtual DbSet<SchemaMigrations> SchemaMigrations { get; set; }
        public virtual DbSet<Users> Users { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseMySql("server=localhost;port=3306;user=root;password=test;database=database_development");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ActiveStorageAttachments>(entity =>
            {
                entity.ToTable("active_storage_attachments");

                entity.HasIndex(e => e.BlobId)
                    .HasName("index_active_storage_attachments_on_blob_id");

                entity.HasIndex(e => new { e.RecordType, e.RecordId, e.Name, e.BlobId })
                    .HasName("index_active_storage_attachments_uniqueness")
                    .IsUnique();

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasColumnType("bigint(20)");

                entity.Property(e => e.BlobId)
                    .HasColumnName("blob_id")
                    .HasColumnType("bigint(20)");

                entity.Property(e => e.CreatedAt)
                    .HasColumnName("created_at")
                    .HasColumnType("datetime");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnName("name")
                    .HasColumnType("varchar(255)");

                entity.Property(e => e.RecordId)
                    .HasColumnName("record_id")
                    .HasColumnType("bigint(20)");

                entity.Property(e => e.RecordType)
                    .IsRequired()
                    .HasColumnName("record_type")
                    .HasColumnType("varchar(255)");

                entity.HasOne(d => d.Blob)
                    .WithMany(p => p.ActiveStorageAttachments)
                    .HasForeignKey(d => d.BlobId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_rails_c3b3935057");
            });

            modelBuilder.Entity<ActiveStorageBlobs>(entity =>
            {
                entity.ToTable("active_storage_blobs");

                entity.HasIndex(e => e.Key)
                    .HasName("index_active_storage_blobs_on_key")
                    .IsUnique();

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasColumnType("bigint(20)");

                entity.Property(e => e.ByteSize)
                    .HasColumnName("byte_size")
                    .HasColumnType("bigint(20)");

                entity.Property(e => e.Checksum)
                    .IsRequired()
                    .HasColumnName("checksum")
                    .HasColumnType("varchar(255)");

                entity.Property(e => e.ContentType)
                    .HasColumnName("content_type")
                    .HasColumnType("varchar(255)");

                entity.Property(e => e.CreatedAt)
                    .HasColumnName("created_at")
                    .HasColumnType("datetime");

                entity.Property(e => e.Filename)
                    .IsRequired()
                    .HasColumnName("filename")
                    .HasColumnType("varchar(255)");

                entity.Property(e => e.Key)
                    .IsRequired()
                    .HasColumnName("key")
                    .HasColumnType("varchar(255)");

                entity.Property(e => e.Metadata)
                    .HasColumnName("metadata")
                    .HasColumnType("text");
            });

            modelBuilder.Entity<ActiveStorageData>(entity =>
            {
                entity.ToTable("active_storage_data");

                entity.HasIndex(e => e.Key)
                    .HasName("index_active_storage_data_on_key");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasColumnType("bigint(20)");

                entity.Property(e => e.CreatedAt)
                    .HasColumnName("created_at")
                    .HasColumnType("datetime");

                entity.Property(e => e.Io)
                    .IsRequired()
                    .HasColumnName("io");

                entity.Property(e => e.Key)
                    .IsRequired()
                    .HasColumnName("key")
                    .HasColumnType("varchar(255)");

                entity.Property(e => e.UpdatedAt)
                    .HasColumnName("updated_at")
                    .HasColumnType("datetime");
            });

            modelBuilder.Entity<Addresses>(entity =>
            {
                entity.ToTable("addresses");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasColumnType("bigint(20)");

                entity.Property(e => e.AptNumber)
                    .HasColumnName("apt_number")
                    .HasColumnType("varchar(255)");

                entity.Property(e => e.City)
                    .IsRequired()
                    .HasColumnName("city")
                    .HasColumnType("varchar(255)");

                entity.Property(e => e.Country)
                    .IsRequired()
                    .HasColumnName("country")
                    .HasColumnType("varchar(255)");

                entity.Property(e => e.CreatedAt)
                    .HasColumnName("created_at")
                    .HasColumnType("datetime");

                entity.Property(e => e.Entity)
                    .IsRequired()
                    .HasColumnName("entity")
                    .HasColumnType("varchar(255)");

                entity.Property(e => e.Latitude).HasColumnName("latitude");

                entity.Property(e => e.Longitude).HasColumnName("longitude");

                entity.Property(e => e.Notes)
                    .HasColumnName("notes")
                    .HasColumnType("text");

                entity.Property(e => e.PostalCode)
                    .IsRequired()
                    .HasColumnName("postal_code")
                    .HasColumnType("varchar(255)");

                entity.Property(e => e.Status)
                    .HasColumnName("status")
                    .HasColumnType("varchar(255)");

                entity.Property(e => e.Street)
                    .IsRequired()
                    .HasColumnName("street")
                    .HasColumnType("varchar(255)");

                entity.Property(e => e.UpdatedAt)
                    .HasColumnName("updated_at")
                    .HasColumnType("datetime");
            });

            modelBuilder.Entity<ArInternalMetadata>(entity =>
            {
                entity.HasKey(e => e.Key)
                    .HasName("PRIMARY");

                entity.ToTable("ar_internal_metadata");

                entity.Property(e => e.Key)
                    .HasColumnName("key")
                    .HasColumnType("varchar(255)");

                entity.Property(e => e.CreatedAt)
                    .HasColumnName("created_at")
                    .HasColumnType("datetime");

                entity.Property(e => e.UpdatedAt)
                    .HasColumnName("updated_at")
                    .HasColumnType("datetime");

                entity.Property(e => e.Value)
                    .HasColumnName("value")
                    .HasColumnType("varchar(255)");
            });

            modelBuilder.Entity<Awards>(entity =>
            {
                entity.ToTable("awards");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasColumnType("bigint(20)");

                entity.Property(e => e.BuildingFile)
                    .HasColumnName("building_file")
                    .HasColumnType("varchar(255)");

                entity.Property(e => e.BuildingName)
                    .HasColumnName("building_name")
                    .HasColumnType("varchar(255)");

                entity.Property(e => e.BuildingType)
                    .HasColumnName("building_type")
                    .HasColumnType("varchar(255)");

                entity.Property(e => e.CreatedAt)
                    .HasColumnName("created_at")
                    .HasColumnType("datetime");

                entity.Property(e => e.UpdatedAt)
                    .HasColumnName("updated_at")
                    .HasColumnType("datetime");
            });

            modelBuilder.Entity<Batteries>(entity =>
            {
                entity.ToTable("batteries");

                entity.HasIndex(e => e.BuildingId)
                    .HasName("index_batteries_on_building_id");

                entity.HasIndex(e => e.EmployeeId)
                    .HasName("index_batteries_on_employee_id");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasColumnType("bigint(20)");

                entity.Property(e => e.BuildingId)
                    .HasColumnName("building_id")
                    .HasColumnType("bigint(20)");

                entity.Property(e => e.CreatedAt)
                    .HasColumnName("created_at")
                    .HasColumnType("datetime");

                entity.Property(e => e.DateOfInspection)
                    .HasColumnName("date_of_inspection")
                    .HasColumnType("date");

                entity.Property(e => e.DateOfInstallation)
                    .HasColumnName("date_of_installation")
                    .HasColumnType("date");

                entity.Property(e => e.EmployeeId)
                    .HasColumnName("employee_id")
                    .HasColumnType("bigint(20)");

                entity.Property(e => e.Information)
                    .HasColumnName("information")
                    .HasColumnType("text");

                entity.Property(e => e.InspectionCertificate)
                    .HasColumnName("inspection_certificate")
                    .HasColumnType("varchar(255)");

                entity.Property(e => e.Notes)
                    .HasColumnName("notes")
                    .HasColumnType("text");

                entity.Property(e => e.Status)
                    .HasColumnName("status")
                    .HasColumnType("varchar(255)");

                entity.Property(e => e.UpdatedAt)
                    .HasColumnName("updated_at")
                    .HasColumnType("datetime");

                entity.HasOne(d => d.Building)
                    .WithMany(p => p.Batteries)
                    .HasForeignKey(d => d.BuildingId)
                    .HasConstraintName("fk_rails_fc40470545");

                entity.HasOne(d => d.Employee)
                    .WithMany(p => p.Batteries)
                    .HasForeignKey(d => d.EmployeeId)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("fk_rails_ceeeaf55f7");
            });

            modelBuilder.Entity<BuildingDetails>(entity =>
            {
                entity.ToTable("building_details");

                entity.HasIndex(e => e.BuildingId)
                    .HasName("index_building_details_on_building_id");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasColumnType("bigint(20)");

                entity.Property(e => e.BuildingId)
                    .HasColumnName("building_id")
                    .HasColumnType("bigint(20)");

                entity.Property(e => e.CreatedAt)
                    .HasColumnName("created_at")
                    .HasColumnType("datetime");

                entity.Property(e => e.InfoKey)
                    .HasColumnName("info_key")
                    .HasColumnType("varchar(255)");

                entity.Property(e => e.UpdatedAt)
                    .HasColumnName("updated_at")
                    .HasColumnType("datetime");

                entity.Property(e => e.Value)
                    .HasColumnName("value")
                    .HasColumnType("varchar(255)");

                entity.HasOne(d => d.Building)
                    .WithMany(p => p.BuildingDetails)
                    .HasForeignKey(d => d.BuildingId)
                    .HasConstraintName("fk_rails_51749f8eac");
            });

            modelBuilder.Entity<Buildings>(entity =>
            {
                entity.ToTable("buildings");

                entity.HasIndex(e => e.AddressId)
                    .HasName("index_buildings_on_address_id");

                entity.HasIndex(e => e.CustomerId)
                    .HasName("index_buildings_on_customer_id");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasColumnType("bigint(20)");

                entity.Property(e => e.AddressId)
                    .HasColumnName("address_id")
                    .HasColumnType("bigint(20)");

                entity.Property(e => e.BuildingType)
                    .HasColumnName("building_type")
                    .HasColumnType("varchar(255)");

                entity.Property(e => e.CreatedAt)
                    .HasColumnName("created_at")
                    .HasColumnType("datetime");

                entity.Property(e => e.CustomerId)
                    .HasColumnName("customer_id")
                    .HasColumnType("bigint(20)");

                entity.Property(e => e.EmailAdminPerson)
                    .HasColumnName("email_admin_person")
                    .HasColumnType("varchar(255)");

                entity.Property(e => e.EmailTechPerson)
                    .HasColumnName("email_tech_person")
                    .HasColumnType("varchar(255)");

                entity.Property(e => e.Floors)
                    .HasColumnName("floors")
                    .HasColumnType("int(11)");

                entity.Property(e => e.FullNameAdminPerson)
                    .HasColumnName("full_name_admin_person")
                    .HasColumnType("varchar(255)");

                entity.Property(e => e.FullNameTechPerson)
                    .HasColumnName("full_name_tech_person")
                    .HasColumnType("varchar(255)");

                entity.Property(e => e.PhoneNumberAdminPerson)
                    .HasColumnName("phone_number_admin_person")
                    .HasColumnType("varchar(255)");

                entity.Property(e => e.PhoneNumberTechPerson)
                    .HasColumnName("phone_number_tech_person")
                    .HasColumnType("varchar(255)");

                entity.Property(e => e.UpdatedAt)
                    .HasColumnName("updated_at")
                    .HasColumnType("datetime");

                entity.HasOne(d => d.Address)
                    .WithMany(p => p.Buildings)
                    .HasForeignKey(d => d.AddressId)
                    .HasConstraintName("fk_rails_6dc7a885ab");

                entity.HasOne(d => d.Customer)
                    .WithMany(p => p.Buildings)
                    .HasForeignKey(d => d.CustomerId)
                    .HasConstraintName("fk_rails_c29cbe7fb8");
            });

            modelBuilder.Entity<Clients>(entity =>
            {
                entity.ToTable("clients");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasColumnType("bigint(20)");

                entity.Property(e => e.CreatedAt)
                    .HasColumnName("created_at")
                    .HasColumnType("datetime");

                entity.Property(e => e.ImageSrc)
                    .HasColumnName("image_src")
                    .HasColumnType("varchar(255)");

                entity.Property(e => e.Name)
                    .HasColumnName("name")
                    .HasColumnType("varchar(255)");

                entity.Property(e => e.UpdatedAt)
                    .HasColumnName("updated_at")
                    .HasColumnType("datetime");
            });

            modelBuilder.Entity<Columns>(entity =>
            {
                entity.ToTable("columns");

                entity.HasIndex(e => e.BatteryId)
                    .HasName("index_columns_on_battery_id");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasColumnType("bigint(20)");

                entity.Property(e => e.BatteryId)
                    .HasColumnName("battery_id")
                    .HasColumnType("bigint(20)");

                entity.Property(e => e.CreatedAt)
                    .HasColumnName("created_at")
                    .HasColumnType("datetime");

                entity.Property(e => e.Floors)
                    .HasColumnName("floors")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Information)
                    .HasColumnName("information")
                    .HasColumnType("text");

                entity.Property(e => e.Notes)
                    .HasColumnName("notes")
                    .HasColumnType("text");

                entity.Property(e => e.Status)
                    .HasColumnName("status")
                    .HasColumnType("varchar(255)");

                entity.Property(e => e.UpdatedAt)
                    .HasColumnName("updated_at")
                    .HasColumnType("datetime");

                entity.HasOne(d => d.Battery)
                    .WithMany(p => p.Columns)
                    .HasForeignKey(d => d.BatteryId)
                    .HasConstraintName("fk_rails_021eb14ac4");
            });

            modelBuilder.Entity<Customers>(entity =>
            {
                entity.ToTable("customers");

                entity.HasIndex(e => e.AddressId)
                    .HasName("index_customers_on_address_id");

                entity.HasIndex(e => e.UserId)
                    .HasName("index_customers_on_user_id");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasColumnType("bigint(20)");

                entity.Property(e => e.AddressId)
                    .HasColumnName("address_id")
                    .HasColumnType("bigint(20)");

                entity.Property(e => e.CompanyDescription)
                    .HasColumnName("company_description")
                    .HasColumnType("text");

                entity.Property(e => e.CompanyName)
                    .IsRequired()
                    .HasColumnName("company_name")
                    .HasColumnType("varchar(255)");

                entity.Property(e => e.CreatedAt)
                    .HasColumnName("created_at")
                    .HasColumnType("datetime");

                entity.Property(e => e.DateOfCreation)
                    .HasColumnName("date_of_creation")
                    .HasColumnType("date");

                entity.Property(e => e.EmailContactPerson)
                    .HasColumnName("email_contact_person")
                    .HasColumnType("varchar(255)");

                entity.Property(e => e.EmailServicePerson)
                    .HasColumnName("email_service_person")
                    .HasColumnType("varchar(255)");

                entity.Property(e => e.FullNameContactPerson)
                    .HasColumnName("full_name_contact_person")
                    .HasColumnType("varchar(255)");

                entity.Property(e => e.FullNameServicePerson)
                    .HasColumnName("full_name_service_person")
                    .HasColumnType("varchar(255)");

                entity.Property(e => e.PhoneNumberContactPerson)
                    .HasColumnName("phone_number_contact_person")
                    .HasColumnType("varchar(255)");

                entity.Property(e => e.PhoneNumberServicePerson)
                    .HasColumnName("phone_number_service_person")
                    .HasColumnType("varchar(255)");

                entity.Property(e => e.UpdatedAt)
                    .HasColumnName("updated_at")
                    .HasColumnType("datetime");

                entity.Property(e => e.UserId)
                    .HasColumnName("user_id")
                    .HasColumnType("bigint(20)");

                entity.HasOne(d => d.Address)
                    .WithMany(p => p.Customers)
                    .HasForeignKey(d => d.AddressId)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("fk_rails_3f9404ba26");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.Customers)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("fk_rails_9917eeaf5d");
            });

            modelBuilder.Entity<Elevators>(entity =>
            {
                entity.ToTable("elevators");

                entity.HasIndex(e => e.ColumnId)
                    .HasName("index_elevators_on_column_id");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasColumnType("bigint(20)");

                entity.Property(e => e.ColumnId)
                    .HasColumnName("column_id")
                    .HasColumnType("bigint(20)");

                entity.Property(e => e.CreatedAt)
                    .HasColumnName("created_at")
                    .HasColumnType("datetime");

                entity.Property(e => e.DateOfInspection)
                    .HasColumnName("date_of_inspection")
                    .HasColumnType("date");

                entity.Property(e => e.DateOfInstallation)
                    .HasColumnName("date_of_installation")
                    .HasColumnType("date");

                entity.Property(e => e.Information)
                    .HasColumnName("information")
                    .HasColumnType("text");

                entity.Property(e => e.InspectionCertificate)
                    .HasColumnName("inspection_certificate")
                    .HasColumnType("varchar(255)");

                entity.Property(e => e.ModelType)
                    .IsRequired()
                    .HasColumnName("model_type")
                    .HasColumnType("varchar(255)");

                entity.Property(e => e.Notes)
                    .HasColumnName("notes")
                    .HasColumnType("text");

                entity.Property(e => e.SerialNumber)
                    .IsRequired()
                    .HasColumnName("serial_number")
                    .HasColumnType("varchar(255)");

                entity.Property(e => e.Status)
                    .HasColumnName("status")
                    .HasColumnType("varchar(255)");

                entity.Property(e => e.UpdatedAt)
                    .HasColumnName("updated_at")
                    .HasColumnType("datetime");

                entity.HasOne(d => d.Column)
                    .WithMany(p => p.Elevators)
                    .HasForeignKey(d => d.ColumnId)
                    .HasConstraintName("fk_rails_69442d7bc2");
            });

            modelBuilder.Entity<Employees>(entity =>
            {
                entity.ToTable("employees");

                entity.HasIndex(e => e.UserId)
                    .HasName("index_employees_on_user_id");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasColumnType("bigint(20)");

                entity.Property(e => e.CreatedAt)
                    .HasColumnName("created_at")
                    .HasColumnType("datetime");

                entity.Property(e => e.Email)
                    .HasColumnName("email")
                    .HasColumnType("varchar(255)");

                entity.Property(e => e.EncryptedPassword)
                    .HasColumnName("encrypted_password")
                    .HasColumnType("varchar(255)");

                entity.Property(e => e.FirstName)
                    .HasColumnName("first_name")
                    .HasColumnType("varchar(255)");

                entity.Property(e => e.LastName)
                    .HasColumnName("last_name")
                    .HasColumnType("varchar(255)");

                entity.Property(e => e.Title)
                    .HasColumnName("title")
                    .HasColumnType("varchar(255)");

                entity.Property(e => e.UpdatedAt)
                    .HasColumnName("updated_at")
                    .HasColumnType("datetime");

                entity.Property(e => e.UserId)
                    .HasColumnName("user_id")
                    .HasColumnType("bigint(20)");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.Employees)
                    .HasForeignKey(d => d.UserId)
                    .HasConstraintName("fk_rails_dcfd3d4fc3");
            });

            modelBuilder.Entity<Interventions>(entity =>
            {
                entity.ToTable("interventions");

                entity.HasIndex(e => e.AuthorId)
                    .HasName("index_interventions_on_author_id");

                entity.HasIndex(e => e.BatteryId)
                    .HasName("index_interventions_on_battery_id");

                entity.HasIndex(e => e.BuildingId)
                    .HasName("index_interventions_on_building_id");

                entity.HasIndex(e => e.ColumnId)
                    .HasName("index_interventions_on_column_id");

                entity.HasIndex(e => e.CustomerId)
                    .HasName("index_interventions_on_customer_id");

                entity.HasIndex(e => e.ElevatorId)
                    .HasName("index_interventions_on_elevator_id");

                entity.HasIndex(e => e.EmployeeId)
                    .HasName("index_interventions_on_employee_id");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasColumnType("bigint(20)");

                entity.Property(e => e.AuthorId)
                    .HasColumnName("author_id")
                    .HasColumnType("bigint(20)");

                entity.Property(e => e.BatteryId)
                    .HasColumnName("battery_id")
                    .HasColumnType("bigint(20)");

                entity.Property(e => e.BuildingId)
                    .HasColumnName("building_id")
                    .HasColumnType("bigint(20)");

                entity.Property(e => e.ColumnId)
                    .HasColumnName("column_id")
                    .HasColumnType("bigint(20)");

                entity.Property(e => e.CreatedAt)
                    .HasColumnName("created_at")
                    .HasColumnType("datetime");

                entity.Property(e => e.CustomerId)
                    .HasColumnName("customer_id")
                    .HasColumnType("bigint(20)");

                entity.Property(e => e.ElevatorId)
                    .HasColumnName("elevator_id")
                    .HasColumnType("bigint(20)");

                entity.Property(e => e.EmployeeId)
                    .HasColumnName("employee_id")
                    .HasColumnType("bigint(20)");

                entity.Property(e => e.InterventionBeginsAt)
                    .HasColumnName("intervention_begins_at")
                    .HasColumnType("varchar(255)");

                entity.Property(e => e.InterventionFinishedAt)
                    .HasColumnName("intervention_finished_at")
                    .HasColumnType("varchar(255)");

                entity.Property(e => e.Report)
                    .HasColumnName("report")
                    .HasColumnType("varchar(255)");

                entity.Property(e => e.Result)
                    .HasColumnName("result")
                    .HasColumnType("varchar(255)")
                    .HasDefaultValueSql("'Incomplete'");

                entity.Property(e => e.Status)
                    .HasColumnName("status")
                    .HasColumnType("varchar(255)")
                    .HasDefaultValueSql("'Pending'");

                entity.Property(e => e.UpdatedAt)
                    .HasColumnName("updated_at")
                    .HasColumnType("datetime");

                entity.HasOne(d => d.Author)
                    .WithMany(p => p.Interventions)
                    .HasForeignKey(d => d.AuthorId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_rails_6766059600");
            });

            modelBuilder.Entity<Leads>(entity =>
            {
                entity.ToTable("leads");

                entity.HasIndex(e => e.CustomerId)
                    .HasName("index_leads_on_customer_id");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasColumnType("bigint(20)");

                entity.Property(e => e.BuildingProjectName)
                    .HasColumnName("building_project_name")
                    .HasColumnType("varchar(255)");

                entity.Property(e => e.BuildingType)
                    .HasColumnName("building_type")
                    .HasColumnType("varchar(255)");

                entity.Property(e => e.BusinessName)
                    .HasColumnName("business_name")
                    .HasColumnType("varchar(255)");

                entity.Property(e => e.CreatedAt)
                    .HasColumnName("created_at")
                    .HasColumnType("datetime");

                entity.Property(e => e.CustomerId)
                    .HasColumnName("customer_id")
                    .HasColumnType("bigint(20)");

                entity.Property(e => e.Email)
                    .HasColumnName("email")
                    .HasColumnType("varchar(255)");

                entity.Property(e => e.FullName)
                    .HasColumnName("full_name")
                    .HasColumnType("varchar(255)");

                entity.Property(e => e.Message)
                    .HasColumnName("message")
                    .HasColumnType("varchar(255)");

                entity.Property(e => e.OriginalFilename)
                    .HasColumnName("original_filename")
                    .HasColumnType("varchar(255)");

                entity.Property(e => e.PhoneNumber)
                    .HasColumnName("phone_number")
                    .HasColumnType("varchar(255)");

                entity.Property(e => e.ProjectDescription)
                    .HasColumnName("project_description")
                    .HasColumnType("varchar(255)");

                entity.Property(e => e.UpdatedAt)
                    .HasColumnName("updated_at")
                    .HasColumnType("datetime");

                entity.HasOne(d => d.Customer)
                    .WithMany(p => p.Leads)
                    .HasForeignKey(d => d.CustomerId)
                    .HasConstraintName("fk_rails_da25e077a0");
            });

            modelBuilder.Entity<Navs>(entity =>
            {
                entity.ToTable("navs");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasColumnType("bigint(20)");

                entity.Property(e => e.CreatedAt)
                    .HasColumnName("created_at")
                    .HasColumnType("datetime");

                entity.Property(e => e.IdName)
                    .HasColumnName("id_name")
                    .HasColumnType("varchar(255)");

                entity.Property(e => e.Title)
                    .HasColumnName("title")
                    .HasColumnType("varchar(255)");

                entity.Property(e => e.UpdatedAt)
                    .HasColumnName("updated_at")
                    .HasColumnType("datetime");
            });

            modelBuilder.Entity<News>(entity =>
            {
                entity.ToTable("news");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasColumnType("bigint(20)");

                entity.Property(e => e.CreatedAt)
                    .HasColumnName("created_at")
                    .HasColumnType("datetime");

                entity.Property(e => e.ImageSrc)
                    .HasColumnName("image_src")
                    .HasColumnType("varchar(255)");

                entity.Property(e => e.LinkSrc)
                    .HasColumnName("link_src")
                    .HasColumnType("varchar(255)");

                entity.Property(e => e.P)
                    .HasColumnName("p")
                    .HasColumnType("varchar(255)");

                entity.Property(e => e.Title)
                    .HasColumnName("title")
                    .HasColumnType("varchar(255)");

                entity.Property(e => e.UpdatedAt)
                    .HasColumnName("updated_at")
                    .HasColumnType("datetime");
            });

            modelBuilder.Entity<Quotes>(entity =>
            {
                entity.ToTable("quotes");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasColumnType("bigint(20)");

                entity.Property(e => e.Basements)
                    .HasColumnName("basements")
                    .HasColumnType("int(11)");

                entity.Property(e => e.BuildingProjectName)
                    .HasColumnName("building_project_name")
                    .HasColumnType("varchar(255)");

                entity.Property(e => e.BuildingType)
                    .HasColumnName("building_type")
                    .HasColumnType("varchar(255)");

                entity.Property(e => e.BusinessName)
                    .HasColumnName("business_name")
                    .HasColumnType("varchar(255)");

                entity.Property(e => e.CreatedAt)
                    .HasColumnName("created_at")
                    .HasColumnType("datetime");

                entity.Property(e => e.DepartementInChargeOfElevators)
                    .HasColumnName("departement_in_charge_of_elevators")
                    .HasColumnType("varchar(255)");

                entity.Property(e => e.ElevatorShafts)
                    .HasColumnName("elevator_shafts")
                    .HasColumnType("int(11)");

                entity.Property(e => e.ElevatorUnitCost).HasColumnName("elevator_unit_cost");

                entity.Property(e => e.Email)
                    .HasColumnName("email")
                    .HasColumnType("varchar(255)");

                entity.Property(e => e.FullName)
                    .HasColumnName("full_name")
                    .HasColumnType("varchar(255)");

                entity.Property(e => e.Hours)
                    .HasColumnName("hours")
                    .HasColumnType("int(11)");

                entity.Property(e => e.MaxOccupants)
                    .HasColumnName("max_occupants")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Message)
                    .HasColumnName("message")
                    .HasColumnType("varchar(255)");

                entity.Property(e => e.ParkingSpaces)
                    .HasColumnName("parking_spaces")
                    .HasColumnType("int(11)");

                entity.Property(e => e.PhoneNumber)
                    .HasColumnName("phone_number")
                    .HasColumnType("varchar(255)");

                entity.Property(e => e.ProjectDescription)
                    .HasColumnName("project_description")
                    .HasColumnType("varchar(255)");

                entity.Property(e => e.RangeType)
                    .HasColumnName("range_type")
                    .HasColumnType("varchar(255)");

                entity.Property(e => e.SetupFees).HasColumnName("setup_fees");

                entity.Property(e => e.Stories)
                    .HasColumnName("stories")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Total).HasColumnName("total");

                entity.Property(e => e.Units)
                    .HasColumnName("units")
                    .HasColumnType("int(11)");

                entity.Property(e => e.UpdatedAt)
                    .HasColumnName("updated_at")
                    .HasColumnType("datetime");
            });

            modelBuilder.Entity<SchemaMigrations>(entity =>
            {
                entity.HasKey(e => e.Version)
                    .HasName("PRIMARY");

                entity.ToTable("schema_migrations");

                entity.Property(e => e.Version)
                    .HasColumnName("version")
                    .HasColumnType("varchar(255)");
            });

            modelBuilder.Entity<Users>(entity =>
            {
                entity.ToTable("users");

                entity.HasIndex(e => e.Email)
                    .HasName("index_users_on_email")
                    .IsUnique();

                entity.HasIndex(e => e.ResetPasswordToken)
                    .HasName("index_users_on_reset_password_token")
                    .IsUnique();

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasColumnType("bigint(20)");

                entity.Property(e => e.CreatedAt)
                    .HasColumnName("created_at")
                    .HasColumnType("datetime");

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasColumnName("email")
                    .HasColumnType("varchar(255)");

                entity.Property(e => e.EncryptedPassword)
                    .IsRequired()
                    .HasColumnName("encrypted_password")
                    .HasColumnType("varchar(255)");

                entity.Property(e => e.RememberCreatedAt)
                    .HasColumnName("remember_created_at")
                    .HasColumnType("datetime");

                entity.Property(e => e.ResetPasswordSentAt)
                    .HasColumnName("reset_password_sent_at")
                    .HasColumnType("datetime");

                entity.Property(e => e.ResetPasswordToken)
                    .HasColumnName("reset_password_token")
                    .HasColumnType("varchar(255)");

                entity.Property(e => e.UpdatedAt)
                    .HasColumnName("updated_at")
                    .HasColumnType("datetime");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
