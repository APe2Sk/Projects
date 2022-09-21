using LotoApplication.Application;
using System.Security.Claims;

namespace LotoApplication.Api
{
    public class ClaimsPrincipalWrapper
        : IRolePrincipal
    {
        private readonly ClaimsPrincipal claimsPrincipal;

        public ClaimsPrincipalWrapper(ClaimsPrincipal claimsPrincipal)
        {
            this.claimsPrincipal = claimsPrincipal;
        }

        public string Name => claimsPrincipal.FindFirstValue(ClaimTypes.Name);
        public int Id => int.Parse(claimsPrincipal.FindFirstValue(ClaimTypes.NameIdentifier));

        public bool IsInRole(string role)
        {
            return claimsPrincipal.IsInRole(role);
        }
    }
}
