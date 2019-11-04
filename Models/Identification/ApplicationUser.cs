using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations.Schema;

namespace CoreWebApi.Models.Identification
{
    public class ApplicationUser : IdentityUser
    {
        [Column(TypeName = "nvarchar(300)")]
        public string FullName { get; set; }
    }
}
