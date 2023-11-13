using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

namespace Lucent_Library.Areas.Identity.Data;

// Add profile data for application users by adding properties to the User class
public class User : IdentityUser
{
    [Key]
    public int Id { get; set; }
    [PersonalData]
    [Required]
    public string FirstName { get; set; }
    [Required]
    [PersonalData]
    public string LastName { get; set; }
    [Required]
    [PersonalData]
    public string AddressLine1 { get; set; }
    [Required]
    [PersonalData]
    public string AddressLine2 { get; set; }
    [PersonalData]
    public string? AddressLine3 { get; set; }
    [Required]
    [PersonalData]
    public int Postcode { get; set; }
    [Required]
    [PersonalData]
    public string City { get; set; }
    [Required]
    [PersonalData]
    public string State { get; set; }
    [Required]
    public UserStatus Status { get; set; }
    [Required]
    public UserRole Role { get; set; }
}

public enum UserStatus
    {
        Verified,
        Pending,
        Suspended
    }

    public enum UserRole
    {
        Admin,
        User
    }

