using UnityEngine;
using UnityEngine.SceneManagement;

public class TaskTreeAPI : MonoBehaviour
{
    public void LoadScene(string sceneName) =>
        SceneManager.LoadScene(sceneName);
}
