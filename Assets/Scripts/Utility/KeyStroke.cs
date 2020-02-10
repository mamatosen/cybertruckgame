using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[System.Serializable]
public enum StrokeMode
{
    HOLD,
    DOWN,
    UP
}

[System.Serializable]
public class KeyStroke
{
    public string name;
    public KeyCode key;
    public StrokeMode mode;
    public UnityEvent Command;

    public void Check()
    {
        switch (mode)
        {
            case StrokeMode.UP:
                if (Input.GetKeyUp(key)) Execute();
                break;
            case StrokeMode.DOWN:
                if (Input.GetKeyDown(key)) Execute();
                break;
            case StrokeMode.HOLD:
                if (Input.GetKey(key)) Execute();
                break;
        }
    }

    private void Execute()
    {
        Command.Invoke();
    }
}
