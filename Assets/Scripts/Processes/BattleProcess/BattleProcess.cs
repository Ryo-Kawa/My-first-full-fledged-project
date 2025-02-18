using System.Threading;
using Cysharp.Threading.Tasks;

public class BattleProcess : ProcessBase<BattleProcessParams>
{
    private Level m_level = new();

    private async UniTask WaitForBattleFinish()
    {

    }
    
    private void QuitBattle()
    {
        //m_level = null;

        //_game_objects.Get("in_battle").SetActive(false);
        //_game_objects.Get("out_battle").SetActive(true);
    }
}
