public class Logic
{
  private Level _level;
  private readonly GameObject _magicianCardPrefab;
  
  public Logic(Level level)
  {
      this._level = level;

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
      _level.holdingCard.Add(card, );
  }
}
