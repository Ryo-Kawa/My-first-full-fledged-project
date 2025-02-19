using UnityEngine;
using VContainer;
using VContainer.Unity; 

public class RootLifetimeScope : LifetimeScope
{
    [SerializeField] private SplashScreenProcessParams splashScreenProcessParams;
    [SerializeField] private TitleProcessParams titleProcessParams;
    [SerializeField] private HomeProcessParams homeProcessParams;
    [SerializeField] private BattleProcessParams battleProcessParams;

    protected override void Configure(IContainerBuilder builder)
    {
        ProcessInstaller<SplashScreenProcessParams, SplashScreenProcess> splashScreenInstaller = new(splashScreenProcessParams);
        ProcessInstaller<TitleProcessParams, TitleProcess> titleInstaller = new(titleProcessParams);
        ProcessInstaller<HomeProcessParams, HomeProcess> homeInstaller = new(homeProcessParams);
        ProcessInstaller<BattleProcessParams, BattleProcess> battleInstaller = new(battleProcessParams);

        builder.RegisterFactory(() => CreateProcess(splashScreenInstaller, this));
        builder.RegisterFactory(() => CreateProcess(titleInstaller, this));
        builder.RegisterFactory(() => CreateProcess(homeInstaller, this));
        builder.RegisterFactory(() => CreateProcess(battleInstaller, this));

        builder.RegisterEntryPoint<GameEntryPoint>();
    }

    private static TProcess CreateProcess<TProcessParams, TProcess>(ProcessInstaller<TProcessParams, TProcess> installer, LifetimeScope parentLifetimeScope) where TProcessParams : ProcessParamsBase where TProcess : ProcessBase<TProcessParams>
    {
        LifetimeScope childScope = parentLifetimeScope.CreateChild(installer);
        childScope.name = $"{typeof(TProcess).Name}LifetimeScope";
        TProcess process = childScope.Container.Resolve<TProcess>();
        process.LifetimeScope = childScope;
        return process;
    }
}
