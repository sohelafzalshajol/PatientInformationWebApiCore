﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using PatientInformationPortal.Models;

#nullable disable

namespace PatientInformationPortal.Migrations
{
    [DbContext(typeof(PIPContext))]
    partial class PIPContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.16")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("PatientInformationPortal.Models.Allergies", b =>
                {
                    b.Property<int>("AllergyId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("AllergyId"));

                    b.Property<string>("AllergyName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("AllergyId");

                    b.ToTable("Allergies", (string)null);
                });

            modelBuilder.Entity("PatientInformationPortal.Models.Allergies_Details", b =>
                {
                    b.Property<int>("Allergies_DetailsId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Allergies_DetailsId"));

                    b.Property<int>("AllergyId")
                        .HasColumnType("int");

                    b.Property<int>("PatientsInfoId")
                        .HasColumnType("int");

                    b.HasKey("Allergies_DetailsId");

                    b.HasIndex("PatientsInfoId");

                    b.ToTable("Allergies_Details", (string)null);
                });

            modelBuilder.Entity("PatientInformationPortal.Models.DiseaseInformation", b =>
                {
                    b.Property<int>("DiseaseId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("DiseaseId"));

                    b.Property<string>("DiseaseName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("DiseaseId");

                    b.ToTable("DiseaseInformation", (string)null);
                });

            modelBuilder.Entity("PatientInformationPortal.Models.NCD_Details", b =>
                {
                    b.Property<int>("NCD_DetailsId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("NCD_DetailsId"));

                    b.Property<int>("NCDId")
                        .HasColumnType("int");

                    b.Property<int>("PatientsInfoId")
                        .HasColumnType("int");

                    b.HasKey("NCD_DetailsId");

                    b.HasIndex("PatientsInfoId");

                    b.ToTable("NCD_Details", (string)null);
                });

            modelBuilder.Entity("PatientInformationPortal.Models.NCDs", b =>
                {
                    b.Property<int>("NCDId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("NCDId"));

                    b.Property<string>("NCDName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("NCDId");

                    b.ToTable("NCDs", (string)null);
                });

            modelBuilder.Entity("PatientInformationPortal.Models.PatientsInformation", b =>
                {
                    b.Property<int>("PatientsInfoId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("PatientsInfoId"));

                    b.Property<int>("DiseaseId")
                        .HasColumnType("int");

                    b.Property<bool>("IsEpilepsy")
                        .HasColumnType("bit");

                    b.Property<string>("PatientsName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("PatientsInfoId");

                    b.HasIndex("DiseaseId")
                        .IsUnique();

                    b.ToTable("PatientsInformation", (string)null);
                });

            modelBuilder.Entity("PatientInformationPortal.Models.Allergies_Details", b =>
                {
                    b.HasOne("PatientInformationPortal.Models.PatientsInformation", "patientsInformation")
                        .WithMany("allergies_Details")
                        .HasForeignKey("PatientsInfoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("patientsInformation");
                });

            modelBuilder.Entity("PatientInformationPortal.Models.NCD_Details", b =>
                {
                    b.HasOne("PatientInformationPortal.Models.PatientsInformation", "patientsInformation")
                        .WithMany("nCD_Details")
                        .HasForeignKey("PatientsInfoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("patientsInformation");
                });

            modelBuilder.Entity("PatientInformationPortal.Models.PatientsInformation", b =>
                {
                    b.HasOne("PatientInformationPortal.Models.DiseaseInformation", "diseaseInformation")
                        .WithOne("patientsInformation")
                        .HasForeignKey("PatientInformationPortal.Models.PatientsInformation", "DiseaseId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("diseaseInformation");
                });

            modelBuilder.Entity("PatientInformationPortal.Models.DiseaseInformation", b =>
                {
                    b.Navigation("patientsInformation")
                        .IsRequired();
                });

            modelBuilder.Entity("PatientInformationPortal.Models.PatientsInformation", b =>
                {
                    b.Navigation("allergies_Details");

                    b.Navigation("nCD_Details");
                });
#pragma warning restore 612, 618
        }
    }
}
