using Bogus;
using HealthView.Domain.Entities;

namespace HealthView.Infrastructure.Persistence;

public class MainDatabase
{
    public List<Patient> Patients = new();

    public List<Doctor> Doctors = new();

    public List<PatientVisit> PatientVisits = new();
        
    // The rest of this can be ignored, it is simply window dressing to ensure the code runs.
    // Theoretically, assume this is a standard Entity Framework setup.
    
    #region IgnoreMe
    public MainDatabase()
    {
        Randomizer.Seed = new Random(123456789);
    }

    public void Generate()
    {
        Patients = new Faker<Patient>("en_US")
                .RuleFor(p => p.Id, f => f.IndexFaker)
                .RuleFor(p => p.FirstName, f => f.Name.FirstName())
                .RuleFor(p => p.LastName, f => f.Name.LastName())
                .RuleFor(p => p.DateOfBirth, f => f.Date.Past(120, DateTime.Today.AddYears(-18))) // Adult patients
                .RuleFor(p => p.SocialSecurityNumber, f => f.Random.Replace("###-##-####"))
                .RuleFor(p => p.PhoneNumber, f => f.Phone.PhoneNumber())
                .RuleFor(p => p.Email, f => f.Internet.Email())
                .RuleFor(p => p.Address, f => f.Address.StreetAddress())
                .RuleFor(p => p.InsuranceProvider, f => f.Company.CompanyName())
                .RuleFor(p => p.InsurancePolicyNumber, f => f.Finance.Account())
                .RuleFor(p => p.MedicalRecordNumber, f => f.Random.Guid().ToString())
                .RuleFor(p => p.EmergencyContactName, f => f.Name.FullName())
                .RuleFor(p => p.EmergencyContactPhone, f => f.Phone.PhoneNumber())
                .RuleFor(p => p.Allergies, f => f.Lorem.Word())
                .RuleFor(p => p.CurrentMedications, f => f.Lorem.Sentence())
                .RuleFor(p => p.MedicalHistory, f => f.Lorem.Paragraph())
                .RuleFor(p => p.Notes, f => f.Lorem.Sentence())
            .GenerateBetween(50, 80);

        Doctors = new Faker<Doctor>("en_US")
            .RuleFor(d => d.Id, f => f.IndexFaker)
            .RuleFor(d => d.FirstName, f => f.Name.FirstName())
            .RuleFor(d => d.LastName, f => f.Name.LastName())
            .RuleFor(d => d.Email, f => f.Internet.Email())
            .RuleFor(d => d.PhoneNumber, f => f.Phone.PhoneNumber())
            .RuleFor(d => d.DateOfBirth, f => f.Date.Past(60, DateTime.Today.AddYears(-30))) // Doctors typically aged 30+
            .RuleFor(d => d.SocialSecurityNumber, f => f.Random.Replace("###-##-####"))
            .RuleFor(d => d.Address, f => f.Address.FullAddress())
            .RuleFor(d => d.Specialty, f => f.Commerce.Department())
            .RuleFor(d => d.LicenseNumber, f => f.Random.Replace("####-####"))
            .RuleFor(d => d.LicenseExpiration, f => f.Date.Future().Date)
            .RuleFor(d => d.Education, f => f.PickRandom("College", "High School", "University", "Unknown"))
            .RuleFor(d => d.Certifications, f => f.Lorem.Sentence())
            .RuleFor(d => d.HospitalAffiliations, f => f.Company.CompanyName())
            .RuleFor(d => d.Biography, f => f.Lorem.Paragraph())
            .RuleFor(d => d.ResearchInterests, f => f.Lorem.Sentence())
            .RuleFor(d => d.Publications, f => f.Lorem.Sentence())
            .RuleFor(d => d.HeadshotImg, f => f.Image.PicsumUrl(width: 240, height: 320))
            .GenerateBetween(15, 30);
        
        PatientVisits = new Faker<PatientVisit>("en_US")
            .RuleFor(x => x.DoctorId, f => f.PickRandom(Doctors).Id)
            .RuleFor(x => x.PatientId, f => f.PickRandom(Patients).Id)
            .RuleFor(v => v.VisitId, f => f.IndexFaker)
            .RuleFor(v => v.VisitDate, f => f.Date.Recent(90))
            .RuleFor(v => v.ReasonForVisit, f => f.Lorem.Sentence())
            .RuleFor(v => v.Diagnosis, f => f.Lorem.Sentence())
            .RuleFor(v => v.Treatment, f => f.Lorem.Sentence())
            .RuleFor(v => v.Notes, f => f.Lorem.Paragraph())
            .GenerateBetween(100, 200);
    }

    #endregion
}