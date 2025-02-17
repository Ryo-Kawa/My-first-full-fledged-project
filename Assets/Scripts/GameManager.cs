using Cysharp.Threading.Tasks;
using System.Threading;
using UnityEngine;
using UnityEngine.UI;
using VContainer;
using VContainer.Unity;

public class GameManager : IAsyncStartable, ITickable
{
    private Level? m_level = null;

    private readonly Components<GameObject> _game_objects;
    private readonly Components<Button> _buttons;

    private readonly Camera _camera;

    [Inject]
    public GameManager(Components<GameObject> game_objects,Components<Button> buttons, Camera camera)
    {
        _game_objects = game_objects;
        _buttons = buttons;
        _camera = camera;

        InitButtons();
    }

    private void InitButtons()
    {
        _buttons.Get("start_battle_button").onClick.AddListener(() => StartBattle());
    }

    public async UniTask StartAsync(CancellationToken cancellation)
    {

    }

    public void Tick()
    {
        
    }

    private void StartBattle()
    {
        m_level = new Level(_game_objects, _camera, 10, 10);
        m_level.Init();
    }

    private void QuitBattle()
    {
        m_level = null;

        _game_objects.Get("in_battle").SetActive(false);
        _game_objects.Get("out_battle").SetActive(true);
    }
}