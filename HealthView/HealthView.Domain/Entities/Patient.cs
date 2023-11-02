namespace HealthView.Domain.Entities;

public record Patient
{
    public int? Id { get; set; }  // Assuming ID can be nullable for a new patient not yet persisted to the database
    public string? FirstName { get; set; }
    public string? LastName { get; set; }
    public DateTime? DateOfBirth { get; set; }
    public string? SocialSecurityNumber { get; set; }
    public string? PhoneNumber { get; set; }
    public string? Email { get; set; }
    public string? Address { get; set; }
    public string? InsuranceProvider { get; set; }
    public string? InsurancePolicyNumber { get; set; }
    public string? MedicalRecordNumber { get; set; }
    public string? EmergencyContactName { get; set; }
    public string? EmergencyContactPhone { get; set; }
    public string? Allergies { get; set; }
    public string? CurrentMedications { get; set; }
    public string? MedicalHistory { get; set; }
    public string? Notes { get; set; }
}