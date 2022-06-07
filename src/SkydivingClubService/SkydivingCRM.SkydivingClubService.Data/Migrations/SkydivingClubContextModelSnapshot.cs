﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using SkydivingCRM.SkydivingClubService.Data;

namespace SkydivingCRM.SkydivingClubService.Data.Migrations
{
    [DbContext(typeof(SkydivingClubContext))]
    partial class SkydivingClubContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.16")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("SkydivingCRM.SkydivingClubService.Data.Entities.EquipmentEntity", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("AssignedSportsmanId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("DateAdded")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime2")
                        .HasDefaultValue(new DateTime(2022, 6, 7, 10, 26, 21, 792, DateTimeKind.Local).AddTicks(5813));

                    b.Property<bool>("IsDecommissioned")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bit")
                        .HasDefaultValue(false);

                    b.Property<Guid>("StockId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("StockId");

                    b.ToTable("Equipments");
                });

            modelBuilder.Entity("SkydivingCRM.SkydivingClubService.Data.Entities.SkydivingClubEntity", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("FoundationDate")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime2")
                        .HasDefaultValueSql("GETUTCDATE()");

                    b.Property<DateTime?>("RegistrationDate")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime2")
                        .HasDefaultValueSql("GETUTCDATE()");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("SkydivingClubs");
                });

            modelBuilder.Entity("SkydivingCRM.SkydivingClubService.Data.Entities.SkydivingGroupEntity", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime?>("FoundationDate")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime2")
                        .HasDefaultValueSql("GETUTCDATE()");

                    b.Property<DateTime>("RegistrationDate")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime2")
                        .HasDefaultValueSql("GETUTCDATE()");

                    b.Property<Guid>("SkydivingClubId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("SkydivingClubId");

                    b.ToTable("SkydivingGroups");
                });

            modelBuilder.Entity("SkydivingCRM.SkydivingClubService.Data.Entities.StockEntity", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("SkydivingClubId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("SkydivingClubId");

                    b.ToTable("Stocks");
                });

            modelBuilder.Entity("SkydivingCRM.SkydivingClubService.Data.Entities.EquipmentEntity", b =>
                {
                    b.HasOne("SkydivingCRM.SkydivingClubService.Data.Entities.StockEntity", "Stock")
                        .WithMany("Equipments")
                        .HasForeignKey("StockId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Stock");
                });

            modelBuilder.Entity("SkydivingCRM.SkydivingClubService.Data.Entities.SkydivingGroupEntity", b =>
                {
                    b.HasOne("SkydivingCRM.SkydivingClubService.Data.Entities.SkydivingClubEntity", "SkydivingClub")
                        .WithMany("SkydivingGroups")
                        .HasForeignKey("SkydivingClubId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("SkydivingClub");
                });

            modelBuilder.Entity("SkydivingCRM.SkydivingClubService.Data.Entities.StockEntity", b =>
                {
                    b.HasOne("SkydivingCRM.SkydivingClubService.Data.Entities.SkydivingClubEntity", "SkydivingClub")
                        .WithMany("Stocks")
                        .HasForeignKey("SkydivingClubId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("SkydivingClub");
                });

            modelBuilder.Entity("SkydivingCRM.SkydivingClubService.Data.Entities.SkydivingClubEntity", b =>
                {
                    b.Navigation("SkydivingGroups");

                    b.Navigation("Stocks");
                });

            modelBuilder.Entity("SkydivingCRM.SkydivingClubService.Data.Entities.StockEntity", b =>
                {
                    b.Navigation("Equipments");
                });
#pragma warning restore 612, 618
        }
    }
}
