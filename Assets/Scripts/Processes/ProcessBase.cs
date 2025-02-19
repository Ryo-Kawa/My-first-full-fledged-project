using System;
using System.Collections.Generic;
using UnityEngine;
using VContainer;
using VContainer.Unity;

public abstract class ProcessBase<TProcessParams> : IDisposable where TProcessParams : ProcessParamsBase
{
    [Inject] protected readonly Canvas _canvas;

    protected List<GameObject> WillDestroyObjectsOnDispose { get; } = new();

    public void Dispose()
    {
        if(LifetimeScope != null) LifetimeScope.Dispose();

        foreach (var willDestroy in WillDestroyObjectsOnDispose)
        {
            if (willDestroy == null) continue;
            GameObject.Destroy(willDestroy);
        }
    }

    public LifetimeScope LifetimeScope { private get; set; } 
}
