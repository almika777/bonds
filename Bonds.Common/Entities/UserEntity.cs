using System.ComponentModel.DataAnnotations.Schema;
using Bonds.Common.Enums;

namespace Bonds.Common.Entities
{
    public class UserEntity
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public string Email { get; set; }
        public string PasswordHash { get; set; }
        public bool IsVerified { get; set; }
        public int? Totp { get; set; }
        public DateTime LastEnterDate { get; set; }
        public string Description { get; set; }
        public UserStatus Status { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime UpdatedDate { get; set; }
    }
}
