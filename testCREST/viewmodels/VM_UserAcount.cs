using System.ComponentModel.DataAnnotations;

namespace testCREST.viewmodels
{
    public class VM_UserAcount
    {
        [Required,DataType(DataType.Text,ErrorMessage ="is not text")]
        [MinLength(3)]
        public string UserName { get; set; }
        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }
        [Required]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }
        [Required]
        [DataType(DataType.Password)]
        [Compare("Password",ErrorMessage ="is not match your password")]
        public string ConfirmPass { get; set; }
    }
}
