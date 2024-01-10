using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace SmartSchool.Web.Data;

public class AppDbContext(DbContextOptions options) : IdentityDbContext(options)
{
}
