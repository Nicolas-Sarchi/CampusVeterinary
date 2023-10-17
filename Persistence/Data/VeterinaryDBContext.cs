using System.Reflection;
using System.Threading.Tasks;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Persistence.Data
{
    public class VeterinaryDBContext : DbContext
    {
        public VeterinaryDBContext(DbContextOptions<VeterinaryDBContext> options) : base(options)
        {

        }

        public DbSet<Appointment> Appointments {get;set;}
        public DbSet<Breed> Breeds {get;set;}
        public DbSet<Laboratory> Laboratories {get;set;}
        public DbSet<MedicalTreatment> MedicalTreatments {get;set;}
        public DbSet<Medicine> Medicines {get;set;}
        public DbSet<MedicinePurchase> MedicinePurchases {get;set;}
        public DbSet<MedicineSale> MedicineSales {get;set;}
        public DbSet<Owner> Owners {get;set;}
        public DbSet<Pet> Pets {get;set;}
        public DbSet<PurchaseDetail> PurchaseDetails {get;set;}
        public DbSet<RefreshToken> RefreshTokens {get;set;}
        public DbSet<Role> Roles {get;set;}
        public DbSet<SaleDetail> SaleDetails {get;set;}
        public DbSet<Specialization> Specializations {get;set;}
        public DbSet<Supplier> Suppliers {get;set;}
        public DbSet<Species> Species {get;set;}
        public DbSet<User> Users {get;set;}
        public DbSet<UserRole> UserRoles {get;set;}
        public DbSet<Vet> Vets {get;set;}

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }
    }
}