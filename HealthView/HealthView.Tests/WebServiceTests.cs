using HealthView.Domain.Entities;
using HealthView.Domain.Repositories;
using Moq;

namespace HealthView.Tests;

public class WebServiceTests
{
    private Mock<IHealthDataRepository> _healthDataRepository { get; set; }
    
    [SetUp]
    public void Setup()
    {
        _healthDataRepository = new Mock<IHealthDataRepository>();
    }

    // TODO: Add your tests for the pager here.
    
    [Test]
    public void TestPatientVisitsPager()
    {
        var queryablePatientVisits = new List<PatientVisit>
        {
            new PatientVisit(),
            new PatientVisit(),
            new PatientVisit(),
            new PatientVisit(),
        };

        _healthDataRepository
            .Setup(x => x.GetPatientVisitQueryable())
            .Returns(queryablePatientVisits.AsQueryable());
    }
}