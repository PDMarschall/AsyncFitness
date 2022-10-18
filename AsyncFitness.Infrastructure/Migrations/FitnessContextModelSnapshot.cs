﻿// <auto-generated />
using System;
using AsyncFitness.Infrastructure.DbContexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace AsyncFitness.Infrastructure.Migrations
{
    [DbContext(typeof(FitnessContext))]
    partial class FitnessContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.10")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("AsyncFitness.Core.Models.Facility.FitnessCenter", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("GymLeaderId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("GymLeaderId");

                    b.ToTable("FitnessCenters");
                });

            modelBuilder.Entity("AsyncFitness.Core.Models.Facility.GroupFitnessClass", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("ConceptId")
                        .HasColumnType("int");

                    b.Property<DateTime>("End")
                        .HasColumnType("datetime2");

                    b.Property<int>("LocationId")
                        .HasColumnType("int");

                    b.Property<DateTime>("Start")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("ConceptId");

                    b.HasIndex("LocationId");

                    b.ToTable("FitnessClasses");
                });

            modelBuilder.Entity("AsyncFitness.Core.Models.Facility.GroupFitnessConcept", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(500)
                        .HasColumnType("nvarchar(500)");

                    b.Property<TimeSpan>("Duration")
                        .HasColumnType("time");

                    b.Property<int?>("FitnessCenterId")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<int?>("TrainerId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("FitnessCenterId");

                    b.HasIndex("TrainerId");

                    b.ToTable("FitnessConcepts");
                });

            modelBuilder.Entity("AsyncFitness.Core.Models.Facility.GroupFitnessLocation", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("Capacity")
                        .HasColumnType("int");

                    b.Property<int>("CenterId")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("CenterId");

                    b.ToTable("FitnessLocations");
                });

            modelBuilder.Entity("AsyncFitness.Core.Models.User.Admin", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("City")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<DateTime>("JoinDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("Phone")
                        .IsRequired()
                        .HasMaxLength(8)
                        .HasColumnType("nvarchar(8)");

                    b.Property<string>("PostalCode")
                        .IsRequired()
                        .HasMaxLength(7)
                        .HasColumnType("nvarchar(7)");

                    b.Property<byte[]>("ProfileImage")
                        .HasColumnType("varbinary(max)");

                    b.Property<string>("StreetName")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("StreetNumber")
                        .IsRequired()
                        .HasMaxLength(4)
                        .HasColumnType("nvarchar(4)");

                    b.HasKey("Id");

                    b.HasIndex("Email")
                        .IsUnique();

                    b.ToTable("FitnessAdmins");
                });

            modelBuilder.Entity("AsyncFitness.Core.Models.User.Customer", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("City")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<DateTime>("JoinDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("Phone")
                        .IsRequired()
                        .HasMaxLength(8)
                        .HasColumnType("nvarchar(8)");

                    b.Property<string>("PostalCode")
                        .IsRequired()
                        .HasMaxLength(7)
                        .HasColumnType("nvarchar(7)");

                    b.Property<byte[]>("ProfileImage")
                        .HasColumnType("varbinary(max)");

                    b.Property<string>("StreetName")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("StreetNumber")
                        .IsRequired()
                        .HasMaxLength(4)
                        .HasColumnType("nvarchar(4)");

                    b.Property<string>("SubscriptionName")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int?>("TrainerId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("Email")
                        .IsUnique();

                    b.HasIndex("SubscriptionName");

                    b.HasIndex("TrainerId");

                    b.ToTable("FitnessCustomers");
                });

            modelBuilder.Entity("AsyncFitness.Core.Models.User.Subscription", b =>
                {
                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(450)");

                    b.Property<decimal>("Cost")
                        .HasColumnType("decimal(18,2)");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(500)
                        .HasColumnType("nvarchar(500)");

                    b.Property<bool>("IsGroupFitness")
                        .HasColumnType("bit");

                    b.HasKey("Name");

                    b.ToTable("FitnessSubscriptions");
                });

            modelBuilder.Entity("AsyncFitness.Core.Models.User.Trainer", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("City")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<DateTime>("JoinDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("Phone")
                        .IsRequired()
                        .HasMaxLength(8)
                        .HasColumnType("nvarchar(8)");

                    b.Property<string>("PostalCode")
                        .IsRequired()
                        .HasMaxLength(7)
                        .HasColumnType("nvarchar(7)");

                    b.Property<byte[]>("ProfileImage")
                        .HasColumnType("varbinary(max)");

                    b.Property<string>("StreetName")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("StreetNumber")
                        .IsRequired()
                        .HasMaxLength(4)
                        .HasColumnType("nvarchar(4)");

                    b.HasKey("Id");

                    b.HasIndex("Email")
                        .IsUnique();

                    b.ToTable("FitnessTrainers");
                });

            modelBuilder.Entity("CustomerGroupFitnessClass", b =>
                {
                    b.Property<int>("BookedClassesId")
                        .HasColumnType("int");

                    b.Property<int>("BookedParticipantsId")
                        .HasColumnType("int");

                    b.HasKey("BookedClassesId", "BookedParticipantsId");

                    b.HasIndex("BookedParticipantsId");

                    b.ToTable("FitnessCustomerClassBookings", (string)null);
                });

            modelBuilder.Entity("GroupFitnessClassTrainer", b =>
                {
                    b.Property<int>("ClassesByTrainerId")
                        .HasColumnType("int");

                    b.Property<int>("InstructorsId")
                        .HasColumnType("int");

                    b.HasKey("ClassesByTrainerId", "InstructorsId");

                    b.HasIndex("InstructorsId");

                    b.ToTable("FitnessTrainerClassBookings", (string)null);
                });

            modelBuilder.Entity("AsyncFitness.Core.Models.Facility.FitnessCenter", b =>
                {
                    b.HasOne("AsyncFitness.Core.Models.User.Admin", "GymLeader")
                        .WithMany("AdministratedFitnessCenters")
                        .HasForeignKey("GymLeaderId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("GymLeader");
                });

            modelBuilder.Entity("AsyncFitness.Core.Models.Facility.GroupFitnessClass", b =>
                {
                    b.HasOne("AsyncFitness.Core.Models.Facility.GroupFitnessConcept", "Concept")
                        .WithMany("ClassesWithConcept")
                        .HasForeignKey("ConceptId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("AsyncFitness.Core.Models.Facility.GroupFitnessLocation", "Location")
                        .WithMany("Classes")
                        .HasForeignKey("LocationId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Concept");

                    b.Navigation("Location");
                });

            modelBuilder.Entity("AsyncFitness.Core.Models.Facility.GroupFitnessConcept", b =>
                {
                    b.HasOne("AsyncFitness.Core.Models.Facility.FitnessCenter", null)
                        .WithMany("AvailableClasses")
                        .HasForeignKey("FitnessCenterId");

                    b.HasOne("AsyncFitness.Core.Models.User.Trainer", null)
                        .WithMany("Certifications")
                        .HasForeignKey("TrainerId");
                });

            modelBuilder.Entity("AsyncFitness.Core.Models.Facility.GroupFitnessLocation", b =>
                {
                    b.HasOne("AsyncFitness.Core.Models.Facility.FitnessCenter", "Center")
                        .WithMany("Facilities")
                        .HasForeignKey("CenterId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Center");
                });

            modelBuilder.Entity("AsyncFitness.Core.Models.User.Customer", b =>
                {
                    b.HasOne("AsyncFitness.Core.Models.User.Subscription", "Subscription")
                        .WithMany("Subscribers")
                        .HasForeignKey("SubscriptionName");

                    b.HasOne("AsyncFitness.Core.Models.User.Trainer", "Trainer")
                        .WithMany("Clients")
                        .HasForeignKey("TrainerId");

                    b.Navigation("Subscription");

                    b.Navigation("Trainer");
                });

            modelBuilder.Entity("CustomerGroupFitnessClass", b =>
                {
                    b.HasOne("AsyncFitness.Core.Models.Facility.GroupFitnessClass", null)
                        .WithMany()
                        .HasForeignKey("BookedClassesId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("AsyncFitness.Core.Models.User.Customer", null)
                        .WithMany()
                        .HasForeignKey("BookedParticipantsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("GroupFitnessClassTrainer", b =>
                {
                    b.HasOne("AsyncFitness.Core.Models.Facility.GroupFitnessClass", null)
                        .WithMany()
                        .HasForeignKey("ClassesByTrainerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("AsyncFitness.Core.Models.User.Trainer", null)
                        .WithMany()
                        .HasForeignKey("InstructorsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("AsyncFitness.Core.Models.Facility.FitnessCenter", b =>
                {
                    b.Navigation("AvailableClasses");

                    b.Navigation("Facilities");
                });

            modelBuilder.Entity("AsyncFitness.Core.Models.Facility.GroupFitnessConcept", b =>
                {
                    b.Navigation("ClassesWithConcept");
                });

            modelBuilder.Entity("AsyncFitness.Core.Models.Facility.GroupFitnessLocation", b =>
                {
                    b.Navigation("Classes");
                });

            modelBuilder.Entity("AsyncFitness.Core.Models.User.Admin", b =>
                {
                    b.Navigation("AdministratedFitnessCenters");
                });

            modelBuilder.Entity("AsyncFitness.Core.Models.User.Subscription", b =>
                {
                    b.Navigation("Subscribers");
                });

            modelBuilder.Entity("AsyncFitness.Core.Models.User.Trainer", b =>
                {
                    b.Navigation("Certifications");

                    b.Navigation("Clients");
                });
#pragma warning restore 612, 618
        }
    }
}
