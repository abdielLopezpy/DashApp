using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using appDash.Models;

namespace appDash.Data;


public class ApplicationDbContext : IdentityDbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
    {
    }
    //agregar el DbSet para Product
    public DbSet<Product> Products { get; set; }
    //agregar el DbSet para Customer
    public DbSet<Customer> Customers { get; set; }
    //agregar el DbSet para Employee
    public DbSet<Employee> Employees { get; set; }
    //agregar el DbSet para EmployeeAttendance
    public DbSet<EmployeeAttendance> EmployeeAttendances { get; set; }
    //agregar el DbSet para Order
    public DbSet<Order> Orders { get; set; }
    //agregar el DbSet para Order
    public DbSet<appDash.Models.Blog> Blog { get; set; } = default!;

}
