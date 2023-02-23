using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ExpressGoToMainMenu : MonoBehaviour
{

    const string _lobbyName = "MainScene";
    const int _timeToExit = 2;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
            StartCoroutine(ExitCorutine());
        if (Input.GetKeyUp(KeyCode.Escape))
            StopAllCoroutines();
    }

    private IEnumerator ExitCorutine()
    {
        yield return new WaitForSeconds(_timeToExit);
        SceneManager.LoadScene(_lobbyName);
    }
}
