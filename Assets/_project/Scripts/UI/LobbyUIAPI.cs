using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LobbyUIAPI : MonoBehaviour
{
    [SerializeField] GameObject BGImage;

    public void OpenWindow(GameObject window)
    {
        window.SetActive(true);
        BGImage?.SetActive(true);
    }

    public void CloseWindow(GameObject window)
    {
        window.SetActive(false);
        BGImage?.SetActive(false);
    }
}
