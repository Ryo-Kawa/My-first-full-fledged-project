using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BattleLogic
{
    private readonly Level _level;
    private readonly BattleView _battleView;
    private readonly GameObject _magicianCardPrefab;
    
    public BattleLogic(Level level, BattleView battleView, GameObject magicianCardPrefab)
    {
        _level = level;
        _battleView = battleView;
        _magicianCardPrefab = magicianCardPrefab;
    }
    
    public void StartBattle()
    {
        for(int i = 0; i < 5; i++)
        {
            TakeOneCard();
        }
    }

    public void QuitBattle()
    {
        
    }
    
    private void TakeOneCard()
    {
        MagicianCard card = _level.deck.Pop();
        _level.holdingMagicianCards.Add(card);
        
        GameObject cardObject = GameObject.Instantiate(_magicianCardPrefab);
        cardObject.transform.SetParent(_battleView.transform);

        Button button = cardObject.GetComponentInChildren<Button>();
        _battleView.magicianCardButtons.Add(button);
    }

    public void UseMagicCard(Button button)
    {
        _battleView.magicianCardButtons.Remove(button);
    }

    public void EndTurn()
    {

    }
}
