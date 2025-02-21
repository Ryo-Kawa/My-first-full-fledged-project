using Cysharp.Threading.Tasks;
using UnityEngine;

public class BattleProcess : ProcessBase<BattleProcessParams>
{
    private readonly BattleView _battleView;
    private readonly BattleLogic _battleLogic;

    public BattleProcess(BattleProcessParams processParams) : base(processParams) 
    {
        _battleView = view.GetComponent<BattleView>();
        _battleLogic = new(new(), _battleView, processParams.magicianCardPrefab);
    }

    public async UniTask WaitForBattleFinish()
    {
        _battleView.Init(_battleLogic.UseMagicCard, _battleLogic.EndTurn);
        _battleLogic.StartBattle();

        for(int i = 0; i < 10; i++)
        {
            await _battleView.endTurnButton.OnClickAsync();
        }

        _battleLogic.QuitBattle();
    }
}
