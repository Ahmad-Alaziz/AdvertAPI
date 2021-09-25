﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using WebApplication1.Entities;

namespace Test2.Migrations
{
    [DbContext(typeof(AdvertismentDbContext))]
    [Migration("20200617080921_InitializingDataBase")]
    partial class InitializingDataBase
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.4")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("WebApplication1.Entities.Banner", b =>
                {
                    b.Property<int>("IdAdvertisment")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<decimal>("Area")
                        .HasColumnType("decimal(6, 2)");

                    b.Property<int>("IdCampaign")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(100)")
                        .HasMaxLength(100);

                    b.Property<decimal>("Price")
                        .HasColumnType("decimal(6, 2)");

                    b.HasKey("IdAdvertisment");

                    b.HasIndex("IdCampaign");

                    b.ToTable("Banner");
                });

            modelBuilder.Entity("WebApplication1.Entities.Building", b =>
                {
                    b.Property<int>("IdBuilding")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("City")
                        .IsRequired()
                        .HasColumnType("nvarchar(100)")
                        .HasMaxLength(100);

                    b.Property<decimal>("Height")
                        .HasColumnType("decimal(6, 2)");

                    b.Property<string>("Street")
                        .IsRequired()
                        .HasColumnType("nvarchar(100)")
                        .HasMaxLength(100);

                    b.Property<int>("StreetNumber")
                        .HasColumnType("int");

                    b.HasKey("IdBuilding");

                    b.ToTable("Building");
                });

            modelBuilder.Entity("WebApplication1.Entities.Campaign", b =>
                {
                    b.Property<int>("IdCampaign")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("EndDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("FromIdBuilding")
                        .HasColumnType("int");

                    b.Property<int>("IdClient")
                        .HasColumnType("int");

                    b.Property<decimal>("PricePerSquareMeter")
                        .HasColumnType("decimal(6,2)");

                    b.Property<DateTime>("StartDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("ToIdBuilding")
                        .HasColumnType("int");

                    b.HasKey("IdCampaign");

                    b.HasIndex("FromIdBuilding");

                    b.HasIndex("IdClient");

                    b.HasIndex("ToIdBuilding");

                    b.ToTable("Campaign");
                });

            modelBuilder.Entity("WebApplication1.Entities.Client", b =>
                {
                    b.Property<int>("IdClient")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(100)")
                        .HasMaxLength(100);

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("nvarchar(100)")
                        .HasMaxLength(100);

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("nvarchar(100)")
                        .HasMaxLength(100);

                    b.Property<string>("Login")
                        .IsRequired()
                        .HasColumnType("nvarchar(100)")
                        .HasMaxLength(100);

                    b.Property<string>("Phone")
                        .IsRequired()
                        .HasColumnType("nvarchar(100)")
                        .HasMaxLength(100);

                    b.HasKey("IdClient");

                    b.ToTable("Client");
                });

            modelBuilder.Entity("WebApplication1.Entities.Banner", b =>
                {
                    b.HasOne("WebApplication1.Entities.Campaign", "Campaign")
                        .WithMany("Banners")
                        .HasForeignKey("IdCampaign")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("WebApplication1.Entities.Campaign", b =>
                {
                    b.HasOne("WebApplication1.Entities.Building", "FromBuilding")
                        .WithMany("StartCampaigns")
                        .HasForeignKey("FromIdBuilding")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.HasOne("WebApplication1.Entities.Client", "Client")
                        .WithMany("Campaigns")
                        .HasForeignKey("IdClient")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("WebApplication1.Entities.Building", "ToBuilding")
                        .WithMany("EndCampaigns")
                        .HasForeignKey("ToIdBuilding")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
