using System;
using System.Collections.Generic;
using DAL.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace DAL;

public partial class Sp25researchDbContext : DbContext
{
    public Sp25researchDbContext()
    {
    }

    public Sp25researchDbContext(DbContextOptions<Sp25researchDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<ResearchProject> ResearchProjects { get; set; }

    public virtual DbSet<Researcher> Researchers { get; set; }

    public virtual DbSet<UserAccount> UserAccounts { get; set; }

    private string GetConnectionString()
    {
        var config = new ConfigurationBuilder()
             .SetBasePath(Directory.GetCurrentDirectory())
                    .AddJsonFile("appsettings.json", true, true)
                    .Build();
        var strConn = config.GetConnectionString("DefaultConnectionStringDB");

        return strConn;
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder.UseSqlServer(GetConnectionString());

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<ResearchProject>(entity =>
        {
            entity.HasKey(e => e.ProjectId).HasName("PK__Research__761ABED03BFD6A41");

            entity.ToTable("ResearchProject");

            entity.Property(e => e.ProjectId)
                .ValueGeneratedNever()
                .HasColumnName("ProjectID");
            entity.Property(e => e.Budget).HasColumnType("decimal(18, 2)");
            entity.Property(e => e.LeadResearcherId).HasColumnName("LeadResearcherID");
            entity.Property(e => e.ProjectTitle)
                .IsRequired()
                .HasMaxLength(200);
            entity.Property(e => e.ResearchField)
                .IsRequired()
                .HasMaxLength(100);

            entity.HasOne(d => d.LeadResearcher).WithMany(p => p.ResearchProjects)
                .HasForeignKey(d => d.LeadResearcherId)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("FK__ResearchP__LeadR__3F466844");
        });

        modelBuilder.Entity<Researcher>(entity =>
        {
            entity.HasKey(e => e.ResearcherId).HasName("PK__Research__7CC06F05D8F5ED1C");

            entity.ToTable("Researcher");

            entity.HasIndex(e => e.Email, "UQ__Research__A9D1053498F5D1D4").IsUnique();

            entity.Property(e => e.ResearcherId)
                .ValueGeneratedNever()
                .HasColumnName("ResearcherID");
            entity.Property(e => e.Affiliation)
                .IsRequired()
                .HasMaxLength(150);
            entity.Property(e => e.Email)
                .IsRequired()
                .HasMaxLength(100);
            entity.Property(e => e.Expertise)
                .IsRequired()
                .HasMaxLength(200);
            entity.Property(e => e.FullName)
                .IsRequired()
                .HasMaxLength(100);
        });

        modelBuilder.Entity<UserAccount>(entity =>
        {
            entity.HasKey(e => e.UserId).HasName("PK__UserAcco__1788CCAC9D775CB7");

            entity.ToTable("UserAccount");

            entity.HasIndex(e => e.Email, "UQ__UserAcco__A9D10534458BDA55").IsUnique();

            entity.Property(e => e.UserId)
                .ValueGeneratedNever()
                .HasColumnName("UserID");
            entity.Property(e => e.CreatedDate)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.Email)
                .IsRequired()
                .HasMaxLength(100);
            entity.Property(e => e.Password)
                .IsRequired()
                .HasMaxLength(60);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
