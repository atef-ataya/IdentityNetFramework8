using IdentityNetFramework8.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace IdentityNetFramework8
{
    public class AppDbContext(DbContextOptions<AppDbContext> options) : IdentityDbContext<MyUser>(options)
    {
    }
}
