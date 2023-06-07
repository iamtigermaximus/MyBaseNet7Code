using System;
namespace MyBaseNet7Code.Core;

public interface IUnitOfWork
{
    IDriverRepository Drivers { get; }
    Task CompleteAsync();
}

