using System;
using MyBaseNet7Code.Core;
using MyBaseNet7Code.Core.Repositories;

namespace MyBaseNet7Code.Data;

public class UnitOfWork : IUnitOfWork, IDisposable
{
    private readonly ApiDbContext _context;

    public IDriverRepository Drivers { get; private set; }

    public UnitOfWork(ApiDbContext context, ILoggerFactory loggerFactory)
    {
        _context = context;
       var _logger = loggerFactory.CreateLogger("logs");

        Drivers = new DriverRepository(_context, _logger);
    }

    public IDriverRepository Driver => throw new NotImplementedException();

    public async Task CompleteAsync()
    {
        await _context.SaveChangesAsync();
    }

    public void Dispose()
    {
        _context.Dispose();
    }
}

