using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Mvc;

namespace HealthView.Web.Pages.Doctor;

public partial class Doctor
{
    [Parameter]
    [FromRoute(Name = "doctorId")]
    public string? DoctorId { get; set; }

    private Domain.Entities.Doctor? DoctorEntity { get; set; }
    
    protected override void OnParametersSet()
    {
        if (!int.TryParse(DoctorId, out int doctorId))
        {
            return;
        }
        
        DoctorEntity = WebService.GetDoctorById(doctorId);
    }
}