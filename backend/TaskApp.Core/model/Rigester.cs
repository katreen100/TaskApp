using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskApp.Core.model
{
    public class Rigester
    {
     

        [Required, StringLength(50)]
        public string Username { get; set; }

        [Required, StringLength(128)]
        public string Email { get; set; }
        public string Role {  get; set; }

        [Required, StringLength(256)]
        public string Password { get; set; }
    }
}
