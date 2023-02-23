using TMPro;
using UnityEngine;

public class CopyTextFromPlayerPrefs : MonoBehaviour
{
    [SerializeField] string PlayerPrefsNameKey;

    private void OnEnable() =>
        GetComponent<TMP_Text>().text = PlayerPrefs.GetString(PlayerPrefsNameKey);
}
