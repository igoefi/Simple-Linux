using UnityEngine;

public class LobbyUIAPI : MonoBehaviour
{
    [SerializeField] GameObject BGImage;

    private void Start() =>
        LavitoAPI.BuySomething.Invoke();

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
