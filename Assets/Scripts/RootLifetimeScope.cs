using UnityEngine;
using VContainer;
using VContainer.Unity; 

public class RootLifetimeScope : LifetimeScope
{
    [SerializeField] private BattleProcessParams battleProcessParams;

    protected override void Configure(IContainerBuilder builder)
    {
        builder.RegisterInstance(FindAnyObjectByType<Canvas>());

        ProcessInstaller<BattleProcessParams, BattleProcess> battleInstaller = new(battleProcessParams);

        builder.RegisterFactory(() => CreateProcess(battleInstaller, this));

        builder.RegisterEntryPoint<GameManager>();
    }

    private static TProcess CreateProcess<TProcessParams, TProcess>(ProcessInstaller<TProcessParams, TProcess> installer, LifetimeScope parentLifetimeScope) where TProcessParams : IProcessParams where TProcess : IProcess<TProcessParams>
    {
        LifetimeScope childScope = parentLifetimeScope.CreateChild(installer);
        childScope.name = $"{typeof(TProcess).Name}LifetimeScope";
        TProcess process = childScope.Container.Resolve<TProcess>();
        process.LifetimeScope = childScope;
        return process;
    }
}
