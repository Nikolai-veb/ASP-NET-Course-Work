using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;
using System;

namespace AspNetCoreTests.Web.Models
{
    [ExcludeFromCodeCoverage]
    public class CustomerModel
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }
        
        [EmailAddress]
        public string Email { get; set; }

        public string Phone { get; set; }
        public DateTime Created { get; set; }
    }
}