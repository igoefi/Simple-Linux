using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FromMainToAcquaintance : MonoBehaviour
{
    private void Start()
    {
        var first = PlayerPrefs.GetInt("First", 0);
        if (first == 0)
            SceneManager.LoadScene("Acquaintance");
        Debug.Log(first);
    }
}
