using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace WeCanFixIt.Web.Models
{
    // You can add profile data for the user by adding more properties to your ApplicationUser class, please visit http://go.microsoft.com/fwlink/?LinkID=317594 to learn more.
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

    [Table("wo_worker")]
    public class Worker
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("wo_id")]
        public int Id { get; set; }

        [Required]
        [StringLength(50)]
        [Column("wo_name")]
        public string Name { get; set; }

        [Required]
        [StringLength(250)]
        [Column("wo_skills")]
        public string Skills { get; set; }

        [Required]
        [Column("wo_hours_worked")]
        [Range(1,8)]
        public decimal? HoursWorked { get; set; }

        [Required]
        [Column("wo_rate")]
        [Range(1,50)]    
        public int? Rate { get; set; }
    }

    [Table("jo_job")]
    public class Job
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("jo_id")]
        public int Id { get; set; }

        [Column("jo_date",TypeName = "datetime2")]
        public DateTime Date { get; set; }

        [Required]
        [StringLength(50)]
        [Column("jo_work_type")]
        public string WorkType { get; set; }

        [Required]
        [Column("jo_amount")]
        public decimal Amount { get; set; }

        [Column("jo_hours")]
        public int? Hours { get; set; }

        [Column("jo_total")]
        public decimal? Total { get; set; }

    } 

    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext()
            : base("DefaultConnection",false)
        {
        }

        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }

        public DbSet<Worker> Workers { get; set; }
        public DbSet<Job> Jobs { get; set; }

    }
}