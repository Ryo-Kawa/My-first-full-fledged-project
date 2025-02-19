using Cysharp.Threading.Tasks;
using System;
using System.Threading;
using VContainer;
using VContainer.Unity;

public class GameEntryPoint : IAsyncStartable
{
    [Inject] private Func<SplashScreenProcess> _createSplashScreenProcess;
    [Inject] private Func<TitleProcess> _createTitleProcess;
    [Inject] private Func<HomeProcess> _createHomeProcess;
    [Inject] private Func<BattleProcess> _createBattleProcess;

    public async UniTask StartAsync(CancellationToken cancellation)
    {
        SplashScreenProcess splashScreenProcess = _createSplashScreenProcess();
        splashScreenProcess.Dispose();

        TitleProcess titleProcess = _createTitleProcess();
        titleProcess.Dispose();

        HomeProcess homeProcess = _createHomeProcess();
        await homeProcess.WaitForBattleStart(cancellation);
        homeProcess.Dispose();

        BattleProcess battleProcess = _createBattleProcess();
        await battleProcess.WaitForBattleFinish();
        battleProcess.Dispose();
    }
}
