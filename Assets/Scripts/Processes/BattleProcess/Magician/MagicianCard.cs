using UnityEngine;

public class MagicianCard
{
    public readonly int MaxHp;
    public readonly int Attack;
    public readonly int Cost;

    public MagicianCard(int max_hp, int attack, int cost)
    {
        MaxHp = max_hp;
        Attack = attack;
        Cost = cost;
    }
}
