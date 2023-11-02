using HealthView.Domain.Entities;
using HealthView.Domain.Repositories;
using HealthView.Infrastructure.Persistence;

namespace HealthView.Infrastructure.Repositories;

public class HealthDataRepository : IHealthDataRepository
{
    private MainDatabase MainDatabase { get; }
    
    public HealthDataRepository(MainDatabase mainDatabase)
    {
        MainDatabase = mainDatabase;
    }
    
    public Patient? GetPatient(int id)
    {
        return MainDatabase.Patients.Find(x => x.Id == id);
    }

    public Doctor? GetDoctor(int id)
    {
        return MainDatabase.Doctors.Find(x => x.Id == id);
    }

    public PatientVisit? GetPatientVisit(int id)
    {
        return MainDatabase.PatientVisits.Find(x => x.VisitId == id);
    }

    public IEnumerable<Patient> GetPatientsOfDoctor(int doctorId)
    {
        var visitsOfDoctor = MainDatabase.PatientVisits.Where(x => x.DoctorId == doctorId);
        var patientIds = visitsOfDoctor.Select(x => x.PatientId);
        return MainDatabase.Patients.FindAll(x => patientIds.Contains(x.Id));
    }

    public IEnumerable<Doctor> GetDoctorsOfPatient(int patientId)
    {
        var visitsOfPatient = MainDatabase.PatientVisits.Where(x => x.PatientId == patientId);
        var doctorIds = visitsOfPatient.Select(x => x.DoctorId);
        return MainDatabase.Doctors.FindAll(x => doctorIds.Contains(x.Id));
    }

    public IQueryable<PatientVisit> GetPatientVisitQueryable()
    {
        return MainDatabase.PatientVisits.AsQueryable();
    }

    public int CountPatientVisits()
    {
        return MainDatabase.PatientVisits.Count;
    }
}