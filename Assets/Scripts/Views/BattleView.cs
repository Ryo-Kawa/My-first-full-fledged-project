using ObservableCollections;
using UnityEngine.UI;

public class GameView : ViewBase
{
    private readonly ObservableList<Button> _magicianCardButtons = new();

    public Button endTurnButton;

    private void Start()
    {
        _magicianCardButtons.ObserveAdd()
    }
}
