namespace HealthView.Domain.Entities;

public class PatientVisit
{
    public int? VisitId { get; set; }
    public DateTime? VisitDate { get; set; }
    public string? ReasonForVisit { get; set; }
    public string? Diagnosis { get; set; }
    public string? Treatment { get; set; }
    public string? Notes { get; set; }
    public int? PatientId { get; set; } // The patient details for the visit
    public int? DoctorId { get; set; } // The doctor details for the visit
}