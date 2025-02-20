using Cysharp.Threading.Tasks;

public class BattleProcess : ProcessBase<BattleProcessParams>
{


    public BattleProcess(BattleProcessParams processParams) : base(processParams) {}

    public async UniTask WaitForBattleFinish()
    {
        Logic logic = new(new(), processParams);
    }
    
    private void QuitBattle()
    {
        //m_level = null;

        //_game_objects.Get("in_battle").SetActive(false);
        //_game_objects.Get("out_battle").SetActive(true);
    }
}
