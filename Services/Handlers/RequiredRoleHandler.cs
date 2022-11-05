using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;
using RestaurantAPI.Services.Requirements;

namespace RestaurantAPI.Services.Handlers
{
    public class RequiredRoleHandler : AuthorizationHandler<RequiredRoleRequirement>
    {
        private readonly IConfiguration configuration;
        public RequiredRoleHandler(IConfiguration configuration)
        {
            this.configuration = configuration;
        }
        protected override Task HandleRequirementAsync(AuthorizationHandlerContext context, RequiredRoleRequirement requirement)
        {
            if (!context.User.HasClaim(c => c.Type == ClaimTypes.Role && c.Issuer == configuration["Jwt:Issuer"]))
            {
                return Task.CompletedTask;
            }

            if (requirement.Roles.Contains(context.User.FindFirst(c => c.Type == ClaimTypes.Role)?.Value ?? ""))
            {
                context.Succeed(requirement);
            }
            return Task.CompletedTask;
        }
    }
}