using ObservableCollections;
using UnityEngine;
using UnityEngine.UI;

public class GameView : ViewBase
{
    public Button endTurnButton;

    public readonly ObservableList<Button> magicianCardButtons = new();

    private void Start()
    {
        magicianCardButtons.ObserveAdd(button => Debug.Log("Added!"));
        magicianCardButtons.ObserveRemove(button => Debug.Log("Removed!"));
    }
}
