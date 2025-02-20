using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using VContainer;

public class Level
{
    public readonly Dictionary<Magician, GameObject> magicians = new();
    public readonly Dictionary<MagicianCard, GameObject> holdingCards = new();
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

    //private void TakeOneMagicianCard()
    //{
        //MagicianCard card = ;

        //GameObject game_object = GameObject.Instantiate(_game_objects.Get("magician_card_prefab"), Vector3.zero, Quaternion.identity);
        //Button button = game_object.GetComponentInChildren<Button>();

        //button.onClick.AddListener(() => UseMagicianCard(card, game_object));

        //_holding_cards.Add(card, game_object);

        //UpdateMagicianCards();
    //}

    //private void UseMagicianCard(MagicianCard card, GameObject game_object)
    //{
        //SummonMagician(card, new Vector3(0, -9, 0));

        //_holding_cards.Remove(card);
        //GameObject.Destroy(game_object);

        //UpdateMagicianCards();
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
