using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using VContainer;

public class Level
{
    private readonly Components<GameObject> _game_objects;

    private readonly Dictionary<Magician, GameObject> _magicians = new();
    private readonly Dictionary<MagicianCard, GameObject> _holding_cards = new();

    private readonly Camera _camera;

    private readonly int _rows;
    private readonly int _columns;

    public List<Magician> Magicians { get => new(_magicians.Keys); }
    public List<MagicianCard> HoldingMagicianCards { get => new(_holding_cards.Keys);  }

    [Inject]
    public Level(Components<GameObject> game_objects, Camera camera, int rows, int colums)
    {
        _game_objects = game_objects;
        _camera = camera;
        _rows = rows;
        _columns = colums;
    }

    public void Init()
    {
        _game_objects.Get("in_battle").SetActive(true);
        _game_objects.Get("out_battle").SetActive(false);

        GameObject tile = _game_objects.Get("tile_prefab");
        Vector3 size = tile.GetComponent<Renderer>().bounds.size;

        Debug.Log(size);

        for (int i = -_rows / 2; i < _rows / 2; i += (int) size.x)
        {
            for (int j = -_columns / 2; j < _columns / 2; j += (int) size.z)
            {
                GameObject.Instantiate(tile, new Vector3(i, 0, j), Quaternion.identity);
            }
        }

        for (int i = 0; i < 5; i++)
        {
            TakeOneMagicianCard();
        }
    }

    private void TakeOneMagicianCard()
    {
        MagicianCard card = new(100, 5, 1);

        GameObject game_object = GameObject.Instantiate(_game_objects.Get("magician_card_prefab"), Vector3.zero, Quaternion.identity);
        Button button = game_object.GetComponentInChildren<Button>();

        button.onClick.AddListener(() => UseMagicianCard(card, game_object));

        _holding_cards.Add(card, game_object);

        UpdateMagicianCards();
    }

    private void UseMagicianCard(MagicianCard card, GameObject game_object)
    {
        SummonMagician(card, new Vector3(0, -9, 0));

        _holding_cards.Remove(card);
        GameObject.Destroy(game_object);

        UpdateMagicianCards();
    }

    private Magician SummonMagician(MagicianCard card, Vector2 position)
    {
        Magician temp = new Magician(card.MaxHp, card.Attack, position);
        _magicians.Add(temp, GameObject.Instantiate(_game_objects.Get("magician_prefab"), position, Quaternion.identity));

        return temp;
    }

    private void UpdateMagicianCards()
    {
        List<GameObject> magician_cards = new(_holding_cards.Values);
        int count = magician_cards.Count;

        for (int i = 0; i < count; i++)
        {
            Button button = magician_cards[i].GetComponentInChildren<Button>();
            button.transform.position = new Vector3((float) (i - (float) count / 2 + 0.5) * button.GetComponent<RectTransform>().sizeDelta.x, -125) + button.GetComponentInParent<Canvas>().transform.position;
        }
    }
}
