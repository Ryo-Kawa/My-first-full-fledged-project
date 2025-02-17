using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using VContainer;
using VContainer.Unity;

public class MouseInputManager : ITickable
{
    private readonly List<MouseInput> m_mouse_inputs = new();

    public void AddMouseInput(MouseInput input)
    {
        m_mouse_inputs.Add(input);
    }

    public void AddMouseInput(MouseInputType type, Action action)
    {
        AddMouseInput(new MouseInput(type, action));
    }

    public void Tick()
    {
        foreach(MouseInput mouse_input in m_mouse_inputs)
        {
            if(mouse_input.IsConditionTrue()) mouse_input.Action.Invoke(); 
        }
    }
}

public class MouseInput
{
    public readonly MouseInputType Type; 
    public readonly Action Action;

    public MouseInput(MouseInputType type, Action action)
    {
        Type = type;
        Action = action;
    }

    public bool IsConditionTrue()
    {
        switch (Type)
        {
            case MouseInputType.Clicked: return Input.GetMouseButtonDown(0);
            default: return false;
        }
    }
}

public enum MouseInputType
{
    Clicked
}