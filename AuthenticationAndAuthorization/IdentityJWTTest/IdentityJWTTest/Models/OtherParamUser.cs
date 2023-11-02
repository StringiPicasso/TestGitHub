using System.ComponentModel.DataAnnotations;

namespace IdentityJWTTest.Models
{
    public class OtherParamUser:ParamUser
    {
        public string UserName { get; set; }
        public bool SeniorManager { get; set; }

        [Required]
        public EnumProfession Profession { get; set; }
    }
}
