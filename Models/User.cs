using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ApiMVCApplication.Models
{
    [Table("user")]
    public class User
    {
        [Column("id")]
        public int Id { get; set; }

        [Column("login")]
        [Required]
        public string? Login { get; set; }

        [Column("password")]
        [Required]
        public string? Password { get; set; }

        [Column("created_date")]
        public DateTime? CreatedDate { get; set; } = DateTime.UtcNow;

        [Column("user_group_id")]
        [Required]
        public int? UserGroupId { get; set; }

        public UserGroup? UserGroup { get; set; }

        [Column("user_state_id")]
        [Required]
        public int? UserStateId { get; set; }

        public UserState? UserState { get; set; }
    }
}
