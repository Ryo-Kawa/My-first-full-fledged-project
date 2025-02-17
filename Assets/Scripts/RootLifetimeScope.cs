using Cysharp.Threading.Tasks;
using System.Threading;
using UnityEngine;
using UnityEngine.UI;
using VContainer;
using VContainer.Unity; 

public class GameLifetimeScope : LifetimeScope
{
    [SerializeField]
    private GameObject magician_prefab;
    [SerializeField]
    private GameObject magician_card_prefab;
    [SerializeField]
    private GameObject tile_prefab;
    [SerializeField]
    private GameObject in_battle;
    [SerializeField]
    private GameObject out_battle;

    [SerializeField]
    private Button start_battle_button;
    [SerializeField]
    private Button end_turn_button;

    protected override void Configure(IContainerBuilder builder)
    {
        Components<GameObject> game_objects = CreateGameObjects();
        Components<Button> buttons = CreateButtons();

        builder.RegisterInstance(game_objects);
        builder.RegisterInstance(buttons);
        builder.RegisterComponent(GetComponent<Camera>());

        builder.RegisterEntryPoint<MouseInputManager>(Lifetime.Scoped).AsSelf();
        builder.RegisterEntryPoint<GameManager>(Lifetime.Scoped);
    }

    private Components<GameObject> CreateGameObjects()
    {
        Components<GameObject> game_objects = new();

        game_objects.Add("magician_prefab", magician_prefab);
        game_objects.Add("magician_card_prefab", magician_card_prefab);
        game_objects.Add("tile_prefab", tile_prefab);
        game_objects.Add("in_battle", in_battle);
        game_objects.Add("out_battle", out_battle);

        return game_objects;
    }

    private Components<Button> CreateButtons()
    {
        Components<Button> buttons = new();

        buttons.Add("start_battle_button", start_battle_button);
        buttons.Add("end_turn_button", end_turn_button);

        return buttons;
    }
}
