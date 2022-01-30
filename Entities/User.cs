using System.ComponentModel.DataAnnotations;

namespace FPIS.Entities
{
    public class User
    {
        [Key]
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Surname { get; set; }
        public string? Username { get; set; }
        public string? LoginToken { get; set; }
        public string? Password { get; set; }
    }
}
