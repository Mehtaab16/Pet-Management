using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace Pet_Management.Models;

public partial class PetManagementContext : DbContext
{
    public PetManagementContext()
    {
    }

    public PetManagementContext(DbContextOptions<PetManagementContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Appointment> Appointments { get; set; }

    public virtual DbSet<MedicalRecord> MedicalRecords { get; set; }

    public virtual DbSet<Owner> Owners { get; set; }

    public virtual DbSet<Pet> Pets { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Data Source=MEHTAAB\\MSSQLSERVER02;Initial Catalog=Pet Management;Integrated Security=True;TrustServerCertificate=True");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Appointment>(entity =>
        {
            entity.HasKey(e => e.AppointmentId).HasName("PK__appointm__A50828FC668D4968");

            entity.ToTable("appointments");

            entity.Property(e => e.AppointmentId).HasColumnName("appointment_id");
            entity.Property(e => e.AppointmentDate)
                .HasColumnType("datetime")
                .HasColumnName("appointment_date");
            entity.Property(e => e.OwnerId).HasColumnName("owner_id");
            entity.Property(e => e.PetId).HasColumnName("pet_id");
            entity.Property(e => e.Status)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("status");
            entity.Property(e => e.Type)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("type");

            entity.HasOne(d => d.Owner).WithMany(p => p.Appointments)
                .HasForeignKey(d => d.OwnerId)
                .HasConstraintName("FK__appointme__owner__5BE2A6F2");

            entity.HasOne(d => d.Pet).WithMany(p => p.Appointments)
                .HasForeignKey(d => d.PetId)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("FK__appointme__pet_i__5AEE82B9");
        });

        modelBuilder.Entity<MedicalRecord>(entity =>
        {
            entity.HasKey(e => e.RecordId).HasName("PK__medical___BFCFB4DDCAFD78EB");

            entity.ToTable("medical_records");

            entity.Property(e => e.RecordId).HasColumnName("record_id");
            entity.Property(e => e.Date)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("date");
            entity.Property(e => e.Diagnosis)
                .HasColumnType("text")
                .HasColumnName("diagnosis");
            entity.Property(e => e.PetId).HasColumnName("pet_id");
            entity.Property(e => e.Treatment)
                .HasColumnType("text")
                .HasColumnName("treatment");
            entity.Property(e => e.VetName)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("vet_name");

            entity.HasOne(d => d.Pet).WithMany(p => p.MedicalRecords)
                .HasForeignKey(d => d.PetId)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("FK__medical_r__pet_i__5FB337D6");
        });

        modelBuilder.Entity<Owner>(entity =>
        {
            entity.HasKey(e => e.OwnerId).HasName("PK__owners__3C4FBEE452CFD47D");

            entity.ToTable("owners");

            entity.HasIndex(e => e.Email, "UQ__owners__AB6E616433559F54").IsUnique();

            entity.Property(e => e.OwnerId).HasColumnName("owner_id");
            entity.Property(e => e.Address)
                .HasColumnType("text")
                .HasColumnName("address");
            entity.Property(e => e.Email)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("email");
            entity.Property(e => e.Name)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("name");
            entity.Property(e => e.Phone)
                .HasMaxLength(15)
                .IsUnicode(false)
                .HasColumnName("phone");
        });

        modelBuilder.Entity<Pet>(entity =>
        {
            entity.HasKey(e => e.PetId).HasName("PK__pets__390CC5FEF9024024");

            entity.ToTable("pets");

            entity.Property(e => e.PetId).HasColumnName("pet_id");
            entity.Property(e => e.Age).HasColumnName("age");
            entity.Property(e => e.Breed)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("breed");
            entity.Property(e => e.DateRegistered)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("date_registered");
            entity.Property(e => e.Gender)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("gender");
            entity.Property(e => e.MedicalHistory)
                .HasColumnType("text")
                .HasColumnName("medical_history");
            entity.Property(e => e.Name)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("name");
            entity.Property(e => e.OwnerId).HasColumnName("owner_id");
            entity.Property(e => e.Species)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("species");

            entity.HasOne(d => d.Owner).WithMany(p => p.Pets)
                .HasForeignKey(d => d.OwnerId)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("FK__pets__owner_id__5629CD9C");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
