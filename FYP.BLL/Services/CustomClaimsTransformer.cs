using Microsoft.AspNetCore.Authentication;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using FYP.DAL.Entities;
using FYP.DAL;



public class CustomClaimsTransformer : IClaimsTransformation
{
    private readonly ApplicationDbContext _dbContext;

    public CustomClaimsTransformer(ApplicationDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<ClaimsPrincipal> TransformAsync(ClaimsPrincipal principal)
    {
        var identity = (ClaimsIdentity)principal.Identity!;
        var email = identity.FindFirst(ClaimTypes.Email)?.Value;

        if (!identity.HasClaim(claim => claim.Type == ClaimTypes.Role) && email != null)
        {
            var user = await _dbContext.GoogleUsers.FirstOrDefaultAsync(u => u.Email == email);
            if (user != null)
            {
                identity.AddClaim(new Claim(ClaimTypes.Role, user.Role ?? "User"));
            }
            else
            {
                identity.AddClaim(new Claim(ClaimTypes.Role, "Guest")); // fallback
            }
        }

        return principal;
    }
}
