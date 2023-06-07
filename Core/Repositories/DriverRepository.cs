using System;
using Microsoft.EntityFrameworkCore;
using MyBaseNet7Code.Data;
using MyBaseNet7Code.Models;

namespace MyBaseNet7Code.Core.Repositories;

public class DriverRepository : GenericRepository<Driver>, IDriverRepository
{
    public DriverRepository(ApiDbContext context, ILogger logger) : base(context, logger)
    {
    }

    public override async Task<IEnumerable<Driver>> All()
    {
        try
        {
            return await _context.Drivers.Where(x => x.Id < 100).ToListAsync();
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex);
            throw;
        }
    }

    public override async Task<Driver?> GetById(int id)
    {
        try
        {
            return await _context.Drivers.AsNoTracking().FirstOrDefaultAsync(x => x.Id == id);
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex);
            throw;
        }
    }

    public async Task<Driver?> GetByDriverNb(int driverNb)
    {
        try
        {
            return await _context.Drivers.FirstOrDefaultAsync(x => x.DriverNumber == driverNb);
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex);
            throw;
        }
    }
}

