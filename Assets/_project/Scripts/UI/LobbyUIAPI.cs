using UnityEngine;
using UnityEngine.SceneManagement;

public class LobbyUIAPI : MonoBehaviour
{
    [SerializeField] GameObject _BGImage;
    [SerializeField] FileManager _manager;
    [SerializeField] VolumeSetter _setter;
    private void Start()
    {
        LavitoAPI.BuySomething.Invoke();
        if (_setter != null)
            _setter.gameObject.SetActive(true);
    }
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

    public void OnlyCloseWindow(GameObject window) =>
        window.SetActive(false);

    public void CloseGame() =>
        Application.Quit();

    public void ResetSaves()
    {
        _manager.ResetSaves();
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
