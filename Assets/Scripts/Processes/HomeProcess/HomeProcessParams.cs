using UnityEngine;

[CreateAssetMenu(fileName = "HomeProcessParams", menuName = "HomeProcessParams", order = 2)]
public class HomeProcessParams : ProcessParamsBase
{
    [SerializeField] private GameObject _homeViewPrefab;

    public override GameObject ViewPrefab => _homeViewPrefab;
}
