﻿// <auto-generated />
using System;
using Events.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Events.Data.Migrations
{
    [DbContext(typeof(EventsAPIContext))]
    partial class EventsAPIContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.2")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("Events.Core.Entities.CodeEvent", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("EventDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("Length")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("CodeEvent");
                });

            modelBuilder.Entity("Events.Core.Entities.Lecture", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("CodeEventId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("Level")
                        .HasColumnType("int");

                    b.Property<Guid?>("SpeakerId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Title")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("CodeEventId");

                    b.HasIndex("SpeakerId");

                    b.ToTable("Lecture");
                });

            modelBuilder.Entity("Events.Core.Entities.Location", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Address")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CityTown")
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("CodeEventId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Country")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PostalCode")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("StateProvince")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("CodeEventId")
                        .IsUnique();

                    b.ToTable("Location");
                });

            modelBuilder.Entity("Events.Core.Entities.Speaker", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("BlogUrl")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Company")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CompanyUrl")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FirstName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("GitHub")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LastName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Speaker");
                });

            modelBuilder.Entity("Events.Core.Entities.Lecture", b =>
                {
                    b.HasOne("Events.Core.Entities.CodeEvent", "CodeEvent")
                        .WithMany("Lectures")
                        .HasForeignKey("CodeEventId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Events.Core.Entities.Speaker", "Speaker")
                        .WithMany("Lectures")
                        .HasForeignKey("SpeakerId");

                    b.Navigation("CodeEvent");

                    b.Navigation("Speaker");
                });

            modelBuilder.Entity("Events.Core.Entities.Location", b =>
                {
                    b.HasOne("Events.Core.Entities.CodeEvent", "CodeEvent")
                        .WithOne("Location")
                        .HasForeignKey("Events.Core.Entities.Location", "CodeEventId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("CodeEvent");
                });

            modelBuilder.Entity("Events.Core.Entities.CodeEvent", b =>
                {
                    b.Navigation("Lectures");

                    b.Navigation("Location");
                });

            modelBuilder.Entity("Events.Core.Entities.Speaker", b =>
                {
                    b.Navigation("Lectures");
                });
#pragma warning restore 612, 618
        }
    }
}
