using System;
using Microsoft.EntityFrameworkCore;
using MyBaseNet7Code.Models;

namespace MyBaseNet7Code.Data;

public class ApiDbContext: DbContext
{
	public DbSet<Driver> Drivers { get; set; }
	public ApiDbContext(DbContextOptions<ApiDbContext> options):base(options)
	{

	}	
}

