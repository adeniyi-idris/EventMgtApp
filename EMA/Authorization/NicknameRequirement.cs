using Microsoft.AspNetCore.Authorization;

namespace EMA.Authorization
{
    public class NicknameRequirement:IAuthorizationRequirement
    {
        public string Name { get; set; }
        public NicknameRequirement(string name)
        {
            Name = name;
        }
    }
}
