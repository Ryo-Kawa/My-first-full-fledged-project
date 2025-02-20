using System;
using System.Collections.Generic;
using UnityEngine;
using VContainer.Unity;

public abstract class ProcessBase<TProcessParams> : IDisposable where TProcessParams : ProcessParamsBase
{
    protected TProcessParams processParams;
    protected readonly GameObject view;

    protected List<GameObject> willDestroyObjectsOnDispose = new();

    protected ProcessBase(TProcessParams processParams) 
    { 
        this.processParams = processParams;
        view = GameObject.Instantiate(this.processParams.ViewPrefab);
        willDestroyObjectsOnDispose.Add(view);
    }

    public void Dispose()
    {
        if(LifetimeScope != null) LifetimeScope.Dispose();

        foreach (var willDestroy in willDestroyObjectsOnDispose)
        {
            if (willDestroy == null) continue;
            GameObject.Destroy(willDestroy);
        }
    }

    public LifetimeScope LifetimeScope { private get; set; } 
}
