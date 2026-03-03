using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Project_smarties.Models
{
    public class UserApplicationData : IdentityUser
    {
        
        public string? Name { get; set; }
        [Required][EmailAddress] public string? EmailAddress { get; set; }
        public List<string>? CompletedQuizes { get; set; }
    }
}
