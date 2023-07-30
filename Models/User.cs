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
        [Required(ErrorMessage = "Поле обязательно для заполнения")]
        public string? Login { get; set; }

        [Column("password")]
        [MinLength(8, ErrorMessage = "Длина пароля не мнее 8 символов")]
        [Required(ErrorMessage = "Поле обязательно для заполнения")]
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
