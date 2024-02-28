using Microsoft.EntityFrameworkCore;

namespace PatientInformationPortal.Models
{
    public class PIPContext : DbContext
    {
        public PIPContext(DbContextOptions options) : base(options) { }

        public DbSet<PatientsInformation> PatientsInformation { get; set; }
        public DbSet<Allergies> Allergies { get; set; }
        public DbSet<Allergies_Details> Allergies_Details { get; set; }
        public DbSet<DiseaseInformation> DiseaseInformation { get; set; }
        public DbSet<NCD_Details> NCD_Details { get; set; }
        public DbSet<NCDs> NCDs { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Configure table names
            modelBuilder.Entity<PatientsInformation>().ToTable("PatientsInformation");
            modelBuilder.Entity<Allergies>().ToTable("Allergies");
            modelBuilder.Entity<Allergies_Details>().ToTable("Allergies_Details");
            modelBuilder.Entity<DiseaseInformation>().ToTable("DiseaseInformation");
            modelBuilder.Entity<NCD_Details>().ToTable("NCD_Details");
            modelBuilder.Entity<NCDs>().ToTable("NCDs");

            // Configure primary keys
            modelBuilder.Entity<PatientsInformation>().HasKey(p => p.PatientsInfoId);
            modelBuilder.Entity<Allergies>().HasKey(c => c.AllergyId);
            modelBuilder.Entity<Allergies_Details>().HasKey(p => p.Allergies_DetailsId);
            modelBuilder.Entity<DiseaseInformation>().HasKey(c => c.DiseaseId);
            modelBuilder.Entity<NCD_Details>().HasKey(p => p.NCD_DetailsId);
            modelBuilder.Entity<NCDs>().HasKey(c => c.NCDId);

            // Configure relationships
            modelBuilder.Entity<DiseaseInformation>()
            .HasOne(d => d.patientsInformation)
            .WithOne(p => p.diseaseInformation)
            .HasForeignKey<PatientsInformation>(p => p.DiseaseId)
            .IsRequired();

            modelBuilder.Entity<NCD_Details>()
            .HasOne(ncd => ncd.patientsInformation)
            .WithMany(p => p.nCD_Details)
            .HasForeignKey(ncd => ncd.PatientsInfoId);

            modelBuilder.Entity<Allergies_Details>()
            .HasOne(al => al.patientsInformation)
            .WithMany(p => p.allergies_Details)
            .HasForeignKey(al => al.PatientsInfoId);

            // Configure column names
            //modelBuilder.Entity<PatientsInformation>().Property(p => p.PatientsName).HasColumnName("PatientsName");


            base.OnModelCreating(modelBuilder);


        }
    }
}
