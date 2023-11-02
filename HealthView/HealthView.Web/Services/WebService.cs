using HealthView.Domain.Entities;
using HealthView.Domain.Repositories;
using Microsoft.AspNetCore.Identity;

namespace HealthView.Web.Services;

public class WebService
{
    private IHealthDataRepository HealthDataRepository { get; }
    
    public WebService(IHealthDataRepository healthDataRepository)
    {
        HealthDataRepository = healthDataRepository;
    }

    public Pager<PatientVisit> GetPatientVisitsByPage(int pageNo, int pageSize = 25)
    {
        var indexStart = (pageNo-1) * pageSize;
        var patientVisits = HealthDataRepository.GetPatientVisitQueryable();
        
        return new Pager<PatientVisit>
        {
            PageSize = pageSize,
            CurrentPage = pageNo,
            TotalPages = (int)Math.Ceiling((double)HealthDataRepository.CountPatientVisits() / pageSize),
            PageItems = patientVisits.Skip(indexStart).Take(pageSize),
        };
    }

    public Doctor? GetDoctorById(int id)
    {
        return HealthDataRepository.GetDoctor(id);
    }

    public Patient? GetPatientById(int id)
    {
        return HealthDataRepository.GetPatient(id);
    }

    public IdentityUser GetUserByEmail(string email)
    {
        throw new NotImplementedException();
    }

    public string CreateUser(string firstName, string lastName, string email)
    {
        throw new NotImplementedException();
    }
}