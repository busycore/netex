using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using dotnetex.shared.Validations;
using Microsoft.EntityFrameworkCore;

namespace modules.users.Models
{
    [Table("users")]
    public class Users
    {

        public Users(string name, string email, string password, DateTime birthday)
        {
            this.name = name;
            this.email = email;
            this.password = password;
            this.birthday = birthday;
        }
        public Users() { }

        [Column("user_id")]
        [Required]
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Column("user_name")]
        [MaxLength(100)]
        [Required(ErrorMessage = "The name is important")]

        public string name { get; set; }

        [Column("user_email", TypeName = "varchar", Order = 2)]
        [MaxLength(100)]
        [Required]

        public string email { get; set; }

        [Column("user_password")]
        [MaxLength(30)]
        [Required]
        public string password { get; set; }

        [Column("user_birthday")]
        [Required]
        [IsAdult(ErrorMessage = "You are not old enough")]
        //[IsAdult]
        public DateTime birthday { get; set; }


    }
}