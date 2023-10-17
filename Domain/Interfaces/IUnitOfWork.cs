namespace Domain.Interfaces;

public interface IUnitOfWork 
{
    IAppointment Appointments {get;}
    IBreed Breeds {get;}
    ILaboratory Laboratories {get;}
    IMedicalTreatment MedicalTreatments {get;}
    IMedicine Medicines {get;}
    IMedicinePurchase MedicinePurchases {get;}
    IMedicineSale MedicineSales {get;}
    IOwner Owners {get;}
    IPet Pets {get;}
    IPurchaseDetail PurchaseDetails {get;}
    IRole Roles {get;}
    ISaleDetail SaleDetails {get;}
    ISpecialization Specializations {get;}
    ISpecies Species {get;}
    ISupplier Suppliers {get;}
    IUser Users {get;}
    IVet Vets {get;}
    Task<int> SaveAsync(); 
}