using EMA.Data;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using System.Security.Claims;

namespace EMA.Authorization
{
    public class NicknameAuthorization: AuthorizationHandler<NicknameRequirement>
    {
        public UserManager<IdentityUser> _userManager { get; set; }
        public DataContext _db { get; set; }

        public NicknameAuthorization(UserManager<IdentityUser> userManager, DataContext db)
        {
            _userManager = userManager;
            _db = db;
        }
        protected override Task HandleRequirementAsync(AuthorizationHandlerContext context, NicknameRequirement requirement)
        {
            string userid = context.User.FindFirst(ClaimTypes.NameIdentifier).Value;
            var user = _db.AppUser.FirstOrDefault(u => u.Id == userid);
            var claims = Task.Run(async () => await _userManager.GetClaimsAsync(user)).Result;
            var claim = claims.FirstOrDefault(c => c.Type == "FirstName");
            if (claim != null)
            {
                if (claim.Value.ToLower().Contains(requirement.Name.ToLower()))
                {
                    context.Succeed(requirement);
                    return Task.CompletedTask;
                }
            }
            return Task.CompletedTask;
        }
    }
}
