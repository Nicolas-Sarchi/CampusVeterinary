using Application.Repository;
using Domain.Interfaces;
using Persistence.Data;

namespace Aplicacion.UnitOfWork;
public class UnitOfWork : IUnitOfWork, IDisposable
{
    private readonly VeterinaryDBContext context;
    private AppointmentRepository _appointments;
    private BreedRepository _breeds;
    private LaboratoryRepository _laboratories;
    private MedicalTreatmentRepository _medicalTreatments;
    private MedicinePurchaseRepository _medicinePurchases;
    private MedicineRepository _medicines;
    private MedicineSaleRepository _medicineSales;
    private OwnerRepository _owners;
    private PetRepository _pets;
    private PurchaseDetailRepository _purchaseDetails;
    private RoleRepository _roles;
    private SaleDetailRepository _saleDetails;
    private SpecializationRepository _specializations;
    private SpeciesRepository _species;
    private SupplierRepository _suppliers;
    private UserRepository _users;
    private VetRepository _vets;



    public UnitOfWork(VeterinaryDBContext _context)
    {
        context = _context;
    }
public IBreed Breeds
    {
        get
        {
            if (_breeds == null)
            {
                _breeds = new BreedRepository(context);
            }
            return _breeds;
        }
    }
    public ILaboratory Laboratories
    {
        get
        {
            if (_laboratories == null)
            {
                _laboratories = new LaboratoryRepository(context);
            }
            return _laboratories;
        }
    }
    public IMedicalTreatment MedicalTreatments
    {
        get
        {
            if (_medicalTreatments == null)
            {
                _medicalTreatments = new MedicalTreatmentRepository(context);
            }
            return _medicalTreatments;
        }
    }
    public IMedicinePurchase MedicinePurchases
    {
        get
        {
            if (_medicinePurchases == null)
            {
                _medicinePurchases = new MedicinePurchaseRepository(context);
            }
            return _medicinePurchases;
        }
    }
    public IMedicine Medicines
    {
        get
        {
            if (_medicines == null)
            {
                _medicines = new MedicineRepository(context);
            }
            return _medicines;
        }
    }
    public IMedicineSale MedicineSales
    {
        get
        {
            if (_medicineSales == null)
            {
                _medicineSales = new MedicineSaleRepository(context);
            }
            return _medicineSales;
        }
    }
    public IOwner Owners
    {
        get
        {
            if (_owners == null)
            {
                _owners = new OwnerRepository(context);
            }
            return _owners;
        }
    }
    public IPet Pets
    {
        get
        {
            if (_pets == null)
            {
                _pets = new PetRepository(context);
            }
            return _pets;
        }
    }public IPurchaseDetail PurchaseDetails
    {
        get
        {
            if (_purchaseDetails == null)
            {
                _purchaseDetails = new PurchaseDetailRepository(context);
            }
            return _purchaseDetails;
        }
    }
    public IRole Roles
    {
        get
        {
            if (_roles == null)
            {
                _roles = new RoleRepository(context);
            }
            return _roles;
        }
    }
    public ISaleDetail SaleDetails
    {
        get
        {
            if (_saleDetails == null)
            {
                _saleDetails = new SaleDetailRepository(context);
            }
            return _saleDetails;
        }
    }public ISpecialization Specializations
    {
        get
        {
            if (_specializations == null)
            {
                _specializations = new SpecializationRepository(context);
            }
            return _specializations;
        }
    }

    public ISpecies Species
    {
        get
        {
            if (_species == null)
            {
                _species = new SpeciesRepository(context);
            }
            return _species;
        }
    }public ISupplier Suppliers
    {
        get
        {
            if (_suppliers == null)
            {
                _suppliers = new SupplierRepository(context);
            }
            return _suppliers;
        }
    }public IUser Users
    {
        get
        {
            if (_users == null)
            {
                _users = new UserRepository(context);
            }
            return _users;
        }
    }public IVet Vets
    {
        get
        {
            if (_vets == null)
            {
                _vets = new VetRepository(context);
            }
            return _vets;
        }
    }
    public IAppointment Appointments
    {
        get
        {
            if (_appointments == null)
            {
                _appointments = new AppointmentRepository(context);
            }
            return _appointments;
        }
    }

    public int Save()
    {
        return context.SaveChanges();
    }

    public void Dispose()
    {
        context.Dispose();
    }
     public async Task<int> SaveAsync()
    {
        return await context.SaveChangesAsync();
    }
}