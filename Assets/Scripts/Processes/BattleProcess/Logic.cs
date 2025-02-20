using UnityEngine;
using UnityEngine.UI;

public class Logic
{
    private Level _level;
    private readonly BattleProcessParams _battleProcessParams;
    
    public Logic(Level level, BattleProcessParams battleProcessParams)
    {
        _level = level;
        _battleProcessParams = battleProcessParams;
    
        Init();
    }
    
    private void Init()
    {
        for(int i = 0; i < 5; i++)
        {
            TakeOneCard();
        }
    }
    
    private void TakeOneCard()
    {
        MagicianCard card = _level.deck.Pop();
        _level.holdingCards.Add(card);
        
        GameObject cardObject = GameObject.Instantiate(_battleProcessParams);
        Button button = cardObject.GetComponentInChildren<Button>();
        _battleProcessParams.GetComponent<GameView>();
    }
}
