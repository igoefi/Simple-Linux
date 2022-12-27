using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class InputSystem : MonoBehaviour
{
    public static UnityEvent<string> KeyEvent { get; private set; } = new();
    public static UnityEvent DeleteEvent { get; private set; } = new();
    public static UnityEvent EnterEvent { get; private set; } = new();

    void Update()
    {
        if (!Input.anyKeyDown) return;

        if (Input.GetKeyDown(KeyCode.Backspace))
            DeleteEvent.Invoke();
        else if (Input.GetKeyDown(KeyCode.KeypadEnter) || Input.GetKeyDown(KeyCode.Return))
            EnterEvent.Invoke();
        else
            KeyEvent.Invoke(Input.inputString);
    }
}
