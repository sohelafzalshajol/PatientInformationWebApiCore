﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using PatientInformationPortal.Models;

#nullable disable

namespace PatientInformationPortal.Migrations
{
    [DbContext(typeof(PIPContext))]
    [Migration("20240226111048_All_Table_Init_Mig")]
    partial class All_Table_Init_Mig
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
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

                    b.ToTable("Allergies");
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

                    b.ToTable("Allergies_Details");
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

                    b.ToTable("DiseaseInformation");
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

                    b.ToTable("NCD_Details");
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

                    b.ToTable("NCDs");
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

                    b.ToTable("PatientsInformation");
                });
#pragma warning restore 612, 618
        }
    }
}