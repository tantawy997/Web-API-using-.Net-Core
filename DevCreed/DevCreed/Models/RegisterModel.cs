using Microsoft.Build.Framework;
using System.ComponentModel.DataAnnotations;
using RequiredAttribute = System.ComponentModel.DataAnnotations.RequiredAttribute;

namespace DevCreed.Models
{
    public class RegisterModel
    {

        [Required, StringLength(100)]
        public string FirstName { get; set; } = "";

        [Required, StringLength(100)]

        public string LastName { get; set; } = "";
        [Required, StringLength(50)]

        public string UserName { get; set; } = "";
        [Required, StringLength(125)]

        public string email { get; set; } = "";
        [Required, StringLength(256)]
        
        public string password { get; set; } = "";

       

    }
}
