using System.Collections.Generic;
using UnityEngine;

public class Level
{
    public readonly Dictionary<Magician, GameObject> magicians = new();
    public readonly List<MagicianCard> holdingMagicianCards = new();
    public readonly Stack<MagicianCard> deck = new();
    
    public const int Rows = 10;
    public const int Columns = 10;

    public Level()
    {
        for(int i = 0; i < 10; i++)
        {
            deck.Push(new(100, 5, 1));
        }
    }

    //public void Init()
    //{
        //GameObject tile = _game_objects.Get("tile_prefab");
        //Vector3 size = tile.GetComponent<Renderer>().bounds.size;

        //Debug.Log(size);

        //for (int i = -_rows / 2; i < _rows / 2; i += (int) size.x)
        //{
            //for (int j = -_columns / 2; j < _columns / 2; j += (int) size.z)
            //{
                //GameObject.Instantiate(tile, new Vector3(i, 0, j), Quaternion.identity);
            //}
        //}

        //for (int i = 0; i < 5; i++)
        //{
            //TakeOneMagicianCard();
        //}
    //}

    //private Magician SummonMagician(MagicianCard card, Vector2 position)
    //{
        //Magician temp = new Magician(card.MaxHp, card.Attack, position);
        //_magicians.Add(temp, GameObject.Instantiate(_game_objects.Get("magician_prefab"), position, Quaternion.identity));

        //return temp;
    //}

    //private void UpdateMagicianCards()
    //{
        //List<GameObject> magician_cards = new(_holding_cards.Values);
        //int count = magician_cards.Count;

        //for (int i = 0; i < count; i++)
        //{
            //Button button = magician_cards[i].GetComponentInChildren<Button>();
            //button.transform.position = new Vector3((float) (i - (float) count / 2 + 0.5) * button.GetComponent<RectTransform>().sizeDelta.x, -125) + button.GetComponentInParent<Canvas>().transform.position;
        //}
    //}
}
