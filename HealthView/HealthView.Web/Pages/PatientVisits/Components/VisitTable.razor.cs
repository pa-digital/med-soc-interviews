using HealthView.Domain.Entities;
using Microsoft.AspNetCore.Components;

namespace HealthView.Web.Pages.PatientVisits.Components;

public partial class VisitTable
{
    [Parameter]
    public int PageNo { get; set; }

    private Pager<PatientVisit>? Visits { get; set; }
    
    protected override void OnParametersSet()
    {
        Visits = WebService.GetPatientVisitsByPage(PageNo);
    }
}