using Cysharp.Threading.Tasks;
using System;
using System.Threading;
using VContainer;
using VContainer.Unity;

public class GameManager : IAsyncStartable, ITickable
{
    [Inject] private Func<BattleProcess> _createBattleProcess;

    private Level? m_level = null;

    public async UniTask StartAsync(CancellationToken cancellation)
    {
        BattleProcess battleProcess = _createBattleProcess();
    }

    public void Tick()
    {
        
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