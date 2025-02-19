using UnityEngine;
using VContainer;
using VContainer.Unity;

public class ProcessInstaller<TProcessParams, TProcess> : IInstaller where TProcessParams : ProcessParamsBase where TProcess : ProcessBase<TProcessParams>
{
    protected readonly TProcessParams _processParams;

    public ProcessInstaller(TProcessParams processParams)
    {
        _processParams = processParams;
    }

    public void Install(IContainerBuilder builder)
    {
        builder.RegisterInstance(_processParams).As(typeof(TProcessParams));
        builder.Register<TProcess>(Lifetime.Scoped).As(typeof(TProcess));
    }
}
