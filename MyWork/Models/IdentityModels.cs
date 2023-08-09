using System.Data.Entity;
using System.Reflection.Emit;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace MyWork.Models
{
    // You can add profile data for the user by adding more properties to your ApplicationUser class, please visit https://go.microsoft.com/fwlink/?LinkID=317594 to learn more.
    public class ApplicationUser : IdentityUser
    {
        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<ApplicationUser> manager)
        {
            // Note the authenticationType must match the one defined in CookieAuthenticationOptions.AuthenticationType
            var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);
            // Add custom user claims here
            return userIdentity;
        }
    }

    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext()
            : base("MyWebsiteConnection", throwIfV1Schema: false)
        {
        }
        public DbSet<BlogC> BlogCs { get; set; }
        public DbSet<Couerse> Couerses { get; set; }
        public DbSet<Lesson> Lessons{ get; set; }
        public DbSet<VideoTitle> VideoTitles { get; set; }
        public DbSet<CartItem> ShoppingCartItems { get; set; }

        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
    }
}
}