using UnityEngine;

[CreateAssetMenu(fileName = "TitleProcessParams", menuName = "TitleProcessParams", order = 1)]
public class TitleProcessParams : ProcessParamsBase
{
    [SerializeField] private GameObject _titleViewPrefab;
    
    public override GameObject ViewPrefab => _titleViewPrefab;
}
