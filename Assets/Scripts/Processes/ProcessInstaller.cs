using VContainer;
using VContainer.Unity;

public class ProcessInstaller<TProcessParams, TProcess> : IInstaller where TProcessParams : IProcessParams where TProcess : IProcess<TProcessParams>
{
    protected readonly TProcessParams _processParams;

    public ProcessInstaller(TProcessParams processParams)
    {
        _processParams = processParams;
    }

    public void Install(IContainerBuilder builder)
    {
        builder.RegisterEntryPoint<TProcess>().As(typeof(TProcess));
        builder.RegisterInstance(_processParams).As(typeof(TProcessParams));
    }
}
