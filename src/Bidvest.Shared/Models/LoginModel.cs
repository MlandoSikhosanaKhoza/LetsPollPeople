using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bidvest.Shared.Models
{
    public class LoginModel
    {
        /// <summary>
        /// The username must be unique.
        /// You are required to enter a username
        /// </summary>
        [Required(ErrorMessage = "Required *")]
        [MaxLength(50, ErrorMessage = "Length exceeds 25 for Username")]
        public string Username { get; set; }

        /// <summary>
        /// The password is a sha256 Hash Key.
        /// You are required to enter the password.
        /// Length musn't exceed 25 for password
        /// </summary>
        [Required(ErrorMessage = "Required *")]
        [MaxLength(25, ErrorMessage = "Length exceeds 25 for Password")]
        public string Password { get; set; }
    }
}
