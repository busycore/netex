using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

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
        public int Id { get; private set; }

        [Column("user_name")]
        [Required]
        [MaxLength(100)]
        public string name { get; private set; }

        [Column("user_email")]
        [Required]
        [MaxLength(100)]
        public string email { get; private set; }

        [Column("user_password")]
        [Required]
        [MaxLength(30)]
        public string password { get; private set; }

        [Column("user_birthday")]
        public DateTime birthday { get; private set; }


    }
}