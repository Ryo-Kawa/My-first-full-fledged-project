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
            TakeMagicianCard();
        }
    }
    
    private void TakeMagicianCard()
    {
        MagicianCard card = _level.deck.Pop();
        _level.holdingMagicianCards.Add(card);
        
        GameObject cardObject = GameObject.Instantiate(_magicianCardPrefab);
        cardObject.transform.SetParent(_battleView.transform);

        Button button = cardObject.GetComponentInChildren<Button>();
        _battleView.magicianCardButtons.Add(button);
    }

    public void QuitBattle()
    {
        
    }

    public void UseMagicCard(Button button)
    {
        SummonMagician();
        _battleView.magicianCardButtons.Remove(button);
    }

    private void SummonMagician()
    {

    }

    public void EndTurn()
    {

    }
}
