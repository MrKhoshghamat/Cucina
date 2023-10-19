using Cucina.Domain.Entities.Base;

namespace Cucina.Domain;

public class User : BaseEntity<Guid>
{
    #region Properties
    
    public string? FirstName { get; set; }
    public string? LastName { get; set; }
    public string NationalNo { get; set; }
    public string PhoneNumber { get; set; }
    public string? Email { get; set; }
    public string? Password { get; set; }
    public string? Description { get; set; }
    public DateTime? BirthDate { get; set; }
    public long? CountryId { get; set; }
    public long? CityId { get; set; }
    public bool GetNewsLetter { get; set; }
    public bool IsPhoneNumberConfirmed { get; set; }
    public bool IsAdmin { get; set; }
    public bool IsBanned { get; set; }
    public string? ActivationCode { get; set; }
    public string? Avatar { get; set; }

    #endregion
}