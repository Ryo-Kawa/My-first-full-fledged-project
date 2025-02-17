using UnityEngine;
using VContainer;
using VContainer.Unity;

public class ProcessBase : IProcess
{
    [Inject] private readonly Canvas _canvas;
    public Canvas canvas => _canvas;

    private LifetimeScope _lifetimeScope;
    public LifetimeScope LifetimeScope { private get; set; }

    public void Dispose()
    {
        if(_lifetimeScope != null) _lifetimeScope.Dispose();
    }
}
