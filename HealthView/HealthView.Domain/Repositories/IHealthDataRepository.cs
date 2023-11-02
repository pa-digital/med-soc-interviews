using HealthView.Domain.Entities;

namespace HealthView.Domain.Repositories;

public interface IHealthDataRepository
{
    Patient? GetPatient(int id);

    Doctor? GetDoctor(int id);

    PatientVisit? GetPatientVisit(int id);

    IEnumerable<Patient> GetPatientsOfDoctor(int doctorId);

    IEnumerable<Doctor> GetDoctorsOfPatient(int patientId);

    IQueryable<PatientVisit> GetPatientVisitQueryable();

    int CountPatientVisits();
}