using System.Collections.Generic;
using UnityEngine;
using VContainer;
using VContainer.Unity;

public abstract class ProcessBase<TProcessParams> : IProcess<TProcessParams> where TProcessParams : IProcessParams
{
    [Inject] protected readonly Canvas _canvas;

    protected List<GameObject> _willDestroyObjectsOnDispose { get; } = new();

    public void Dispose()
    {
        if(LifetimeScope != null) LifetimeScope.Dispose();

        foreach (var willDestroy in _willDestroyObjectsOnDispose)
        {
            if (willDestroy == null) continue;
            Object.Destroy(willDestroy);
        }
    }

    public LifetimeScope LifetimeScope { private get; set; } 
}
