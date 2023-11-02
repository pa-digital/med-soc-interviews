namespace HealthView.Domain.Entities;

public record Doctor
{
    public int? Id { get; set; }  // ID can be nullable if it's auto-generated upon insertion into a database
    public string? FirstName { get; set; }
    public string? LastName { get; set; }
    public string? Email { get; set; }
    public string? PhoneNumber { get; set; }
    public DateTime? DateOfBirth { get; set; }
    public string? SocialSecurityNumber { get; set; } // This might be required to be non-nullable in some contexts
    public string? Address { get; set; }
    public string? Specialty { get; set; }
    public string? LicenseNumber { get; set; }
    public DateTime? LicenseExpiration { get; set; }
    public string? Education { get; set; }
    public string? Certifications { get; set; }
    public string? HospitalAffiliations { get; set; }
    public string? Biography { get; set; }
    public string? ResearchInterests { get; set; }
    public string? Publications { get; set; }
    public string? HeadshotImg { get; set; }
}