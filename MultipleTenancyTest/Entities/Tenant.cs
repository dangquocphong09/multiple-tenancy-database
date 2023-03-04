using Microsoft.EntityFrameworkCore.Storage.ValueConversion.Internal;
using System.ComponentModel.DataAnnotations;

namespace MultipleTenancyTest.Entities
{
    public class Tenant
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        
    }
}
