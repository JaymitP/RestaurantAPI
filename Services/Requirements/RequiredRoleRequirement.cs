using Microsoft.AspNetCore.Authorization;
namespace RestaurantAPI.Services.Requirements
{
    public class RequiredRoleRequirement : IAuthorizationRequirement
    {
        public List<string> Roles { get; }

        public RequiredRoleRequirement(List<string> roles)
        {
            Roles = roles;
        }
    }
}