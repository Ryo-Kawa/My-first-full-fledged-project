using Cysharp.Threading.Tasks;
using System;
using System.Threading;
using VContainer;
using VContainer.Unity;

public class GameEntryPoint : IAsyncStartable
{
    [Inject] private Func<SplashScreenProcess> _createSplashScreenProcess;
    [Inject] private Func<HomeProcess> _createHomeProcess;
    [Inject] private Func<BattleProcess> _createBattleProcess;

    private Level? m_level = null;

    public async UniTask StartAsync(CancellationToken cancellation)
    {
        SplashScreenProcess splashScreenProcess = _createSplashScreenProcess();

        HomeProcess homeProcess = _createHomeProcess();
    
        BattleProcess battleProcess = _createBattleProcess();
    }

    private void StartBattle()
    {
        //m_level = new Level(_game_objects, _camera, 10, 10);
        //m_level.Init();
    }

    private void QuitBattle()
    {
        //m_level = null;

        //_game_objects.Get("in_battle").SetActive(false);
        //_game_objects.Get("out_battle").SetActive(true);
    }
}
