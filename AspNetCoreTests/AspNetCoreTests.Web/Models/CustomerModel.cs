using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;
using System;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace AspNetCoreTests.Web.Models
{
    [ExcludeFromCodeCoverage]
    public class CustomerModel
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }
        
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        public string Phone { get; set; }
        public DateTime Created { get; set; }
    }
}