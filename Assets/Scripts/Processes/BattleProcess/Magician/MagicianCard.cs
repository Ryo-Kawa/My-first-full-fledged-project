using UnityEngine;

public class MagicianCard
{
    public readonly int MaxHp;
    public readonly int Attack;
    public readonly int Cost;

    public MagicianCard(int maxHp, int attack, int cost)
    {
        MaxHp = maxHp;
        Attack = attack;
        Cost = cost;
    }
}
