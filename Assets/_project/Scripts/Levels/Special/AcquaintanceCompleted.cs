using UnityEngine;

public class AcquaintanceCompleted : MonoBehaviour
{
    private void OnEnable() =>
        SetAcquaintanceCompleted();

    private void SetAcquaintanceCompleted() =>
        PlayerPrefs.SetInt("First", 1);
}