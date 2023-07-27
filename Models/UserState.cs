using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace ApiMVCApplication.Models
{
    [Table("user_state")]
    public class UserState
    {
        [Column("id")]
        public int Id { get; set; }

        [Column("code")]
        [Required]
        public string? Code { get; set; }

        [Column("description")]
        public string? Description { get; set; }

        public List<User> Users { get; set; } = new List<User>();
    }
}
