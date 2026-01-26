using Portfolio.SharedKernel.Entities;

namespace Portfolio.Domain.Users;

public sealed class UserProfile : AuditableEntity<UserProfileId>
{
    private Guid _userId;

    public UserId UserId => new(_userId);
    public string FirstName { get; private set; } = string.Empty;
    public string LastName { get; private set; } = string.Empty;
    public DateTime DateOfBirth { get; private set; }
    public string? Country { get; private set; }
    public string Locale { get; private set; } = "en-US";
    public string TimeZone { get; private set; } = "UTC";

    private UserProfile()
        : base(new UserProfileId(Guid.Empty))
    {
        _userId = Guid.Empty;
        FirstName = string.Empty;
        LastName = string.Empty;
        DateOfBirth = default;
        Country = null;
        Locale = "en-US";
        TimeZone = "UTC";
    }

    public UserProfile(
        UserProfileId id,
        UserId userId,
        string firstName,
        string lastName,
        DateTime dateOfBirth,
        string? country,
        string? locale,
        string? timeZone)
        : base(id)
    {
        _userId = userId.Value;
        SetName(firstName, lastName);
        SetDateOfBirth(dateOfBirth);
        SetCountry(country);
        SetLocale(locale);
        SetTimeZone(timeZone);
    }

    public void UpdateName(string firstName, string lastName)
    {
        SetName(firstName, lastName);
    }

    public void UpdateDateOfBirth(DateTime dateOfBirth)
    {
        SetDateOfBirth(dateOfBirth);
    }

    public void UpdateCountry(string? country)
    {
        SetCountry(country);
    }

    public void UpdateLocale(string? locale)
    {
        SetLocale(locale);
    }

    public void UpdateTimeZone(string? timeZone)
    {
        SetTimeZone(timeZone);
    }

    private void SetName(string firstName, string lastName)
    {
        if (string.IsNullOrWhiteSpace(firstName))
        {
            throw new ArgumentException("First name is required.", nameof(firstName));
        }

        if (string.IsNullOrWhiteSpace(lastName))
        {
            throw new ArgumentException("Last name is required.", nameof(lastName));
        }

        FirstName = firstName.Trim();
        LastName = lastName.Trim();
    }

    private void SetDateOfBirth(DateTime dateOfBirth)
    {
        if (dateOfBirth == default)
        {
            throw new ArgumentException("Date of birth is required.", nameof(dateOfBirth));
        }

        DateOfBirth = dateOfBirth;
    }

    private void SetCountry(string? country)
    {
        if (string.IsNullOrWhiteSpace(country))
        {
            Country = null;
            return;
        }

        Country = country.Trim().ToUpperInvariant();
    }

    private void SetLocale(string? locale)
    {
        if (string.IsNullOrWhiteSpace(locale))
        {
            Locale = "en-US";
            return;
        }

        Locale = locale.Trim();
    }

    private void SetTimeZone(string? timeZone)
    {
        if (string.IsNullOrWhiteSpace(timeZone))
        {
            TimeZone = "UTC";
            return;
        }

        TimeZone = timeZone.Trim();
    }
}
