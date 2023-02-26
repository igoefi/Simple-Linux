using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonLikeEnterAPI : MonoBehaviour
{
    public void PressButtom() => InputSystem.EnterEvent.Invoke();
}
