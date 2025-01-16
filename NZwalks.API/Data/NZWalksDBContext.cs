namespace NZwalks.API.Data;
using Microsoft.EntityFrameworkCore;
using NZwalks.API.Models.Domain;

public class NZWalksDBContext : DbContext
{
    public NZWalksDBContext(DbContextOptions<NZWalksDBContext> options) : base(options)
    {

    }



    public DbSet<Difficulty> Difficulties { get; set; }

   

    public DbSet<Client> Clients { get; set; }

    public DbSet<Project> Projects { get; set; }

    public DbSet<Employee> Employees { get; set; }

    public DbSet<Assignmenent> Assignmenents { get; set; }

    public DbSet<LogTime> LogTimes { get; set; }




    





    }



