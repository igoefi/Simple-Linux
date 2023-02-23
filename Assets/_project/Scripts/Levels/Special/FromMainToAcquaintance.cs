using UnityEngine;
using UnityEngine.SceneManagement;

public class FromMainToAcquaintance : MonoBehaviour
{
    private void Start()
    {
        int first = PlayerPrefs.GetInt("First", 0);
        if (first == 0)
            SceneManager.LoadScene("Acquaintance");
    }
}
