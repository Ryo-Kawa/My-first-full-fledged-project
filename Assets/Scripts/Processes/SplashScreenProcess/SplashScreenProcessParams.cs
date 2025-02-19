using UnityEngine;

[CreateAssetMenu(fileName = "SplashScreenProcessParams", menuName = "SplashScreenProcessParams", order = 0)]
public class SplashScreenProcessParams : ProcessParamsBase
{
    [SerializeField] private GameObject _splashScreenViewPrefab;

    public override GameObject ViewPrefab => _splashScreenViewPrefab;
}
