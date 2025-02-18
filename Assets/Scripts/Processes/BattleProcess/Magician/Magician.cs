using UnityEngine;

public class Magician
{
    public readonly int Attack;

    private int _hp;
    private int _mana = 0;

    public Vector2 Position { get; private set; }

    public Magician(int hp, int attack, Vector2 position)
    {
        _hp = hp;
        Attack = attack;
        Position = position;
    }
}
