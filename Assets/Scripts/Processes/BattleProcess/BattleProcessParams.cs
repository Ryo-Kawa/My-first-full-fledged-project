using UnityEngine;

[CreateAssetMenu(fileName = "BattleProcessParams", menuName = "BattleProcessParams", order = 3)]
public class BattleProcessParams : ProcessParamsBase
{
    [SerializeField] private GameObject _battleViewPrefab;

    public GameObject magicianCardPrefab;
    public override GameObject ViewPrefab => _battleViewPrefab;
}
