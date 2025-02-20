using UnityEngine;
using UnityEngine.UI;

public class Logic
{
    private Level _level;
    private readonly GameObject _magicianCardPrefab;
    
    public Logic(Level level, GameObject magicianCardPrefab)
    {
        _level = level;
        _magicianCardPrefab = magicianCardPrefab;
    
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
        GameObject cardObject = GameObject.Instantiate(_magicianCardPrefab);
        Button button = cardObject.GetComponentInChildren<Button>();

        _level.holdingCards.Add(card, cardObject);
    }
}