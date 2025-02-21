using ObservableCollections;
using R3;
using System;
using UnityEngine;
using UnityEngine.UI;

public class BattleView : ViewBase
{
    public Button endTurnButton;

    [NonSerialized] public readonly ObservableList<Button> magicianCardButtons = new();

    public void Init(Action<Button> magicCardButtonOnClick, Action endTurnOnClick)
    {
        magicianCardButtons.ObserveAdd(destroyCancellationToken).Subscribe(e =>
        {
            e.Value.OnClickAsObservable().Subscribe(_ =>
            {
                magicCardButtonOnClick(e.Value);
            });
        });

        magicianCardButtons.ObserveRemove(destroyCancellationToken).Subscribe(e =>
        {
            Destroy(e.Value.GetComponentInParent<Canvas>().gameObject);
        });

        endTurnButton.OnClickAsObservable().Subscribe(_ =>
        {
            endTurnOnClick();
        });
    }
}
