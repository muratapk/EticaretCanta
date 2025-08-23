using System.ComponentModel.DataAnnotations;

namespace EticaretCanta.Models
{
    public class MemberShip
    {

        [Key]
        public int MemberId { get; set; }
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string Phone { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;


    }
}
