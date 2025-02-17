using System;
using VContainer.Unity;

public interface IProcess<TProcessParams> : IDisposable where TProcessParams : IProcessParams 
{
    public LifetimeScope LifetimeScope { set; }
}