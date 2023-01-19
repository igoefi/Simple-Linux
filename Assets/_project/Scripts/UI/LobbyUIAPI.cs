using UnityEngine;
using UnityEngine.SceneManagement;

public class LobbyUIAPI : MonoBehaviour
{
    [SerializeField] GameObject _BGImage;
    [SerializeField] FileManager _manager;

    private void Start() =>
        LavitoAPI.BuySomething.Invoke();

    public void OpenWindow(GameObject window)
    {
        window.SetActive(true);
        _BGImage.SetActive(true);
    }

    public void CloseWindow(GameObject window)
    {
        window.SetActive(false);
        _BGImage.SetActive(false);
    }

    public void CloseGame() =>
        Application.Quit();

    public void ResetSaves()
    {
        Debug.Log("Dekete in API");
        _manager.ResetSaves();
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
