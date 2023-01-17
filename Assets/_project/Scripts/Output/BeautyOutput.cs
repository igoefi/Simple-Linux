using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.Events;

public class BeautyOutput : MonoBehaviour
{
    public UnityEvent EndWriteText { get; private set; } = new();

    [SerializeField] TMP_Text _TMP;

    [Min(0)]
    [SerializeField] float _charSpeed = 0.1f;

    public void SetText(string text)
    {
        _TMP.text = null;
        StartCoroutine(Write(text));
    }

    private IEnumerator Write(string text)
    {
        yield return new WaitForSeconds(1);

        foreach (char letter in text)
        {
            _TMP.text += letter;
            yield return new WaitForSeconds(_charSpeed);
        }

        EndWriteText.Invoke();
    }
}
