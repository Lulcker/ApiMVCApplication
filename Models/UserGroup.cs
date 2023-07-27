using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ApiMVCApplication.Models
{
    [Table("user_group")]
    public class UserGroup
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
