using System;
using System.Collections.Generic;
using UnityEngine;
using VContainer.Unity;

public abstract class ProcessBase<TProcessParams> : IDisposable where TProcessParams : ProcessParamsBase
{
    protected TProcessParams ProcessParams;
    protected readonly GameObject View;

    protected List<GameObject> WillDestroyObjectsOnDispose { get; } = new();

    protected ProcessBase(TProcessParams processParams) 
    { 
        ProcessParams = processParams;
        View = GameObject.Instantiate(ProcessParams.ViewPrefab);
        WillDestroyObjectsOnDispose.Add(View);
    }

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
