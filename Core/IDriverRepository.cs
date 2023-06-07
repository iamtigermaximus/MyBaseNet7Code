using System;
using MyBaseNet7Code.Models;

namespace MyBaseNet7Code.Core;

public interface IDriverRepository : IGenericRepository<Driver>
{
    Task<Driver?> GetByDriverNb(int driverNb);
}

