using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.Events;

public class BeautyOutput : MonoBehaviour
{
    public static UnityEvent EndWriteText { get; private set; } = new();

    [SerializeField] TMP_Text _TMP;
    [SerializeField] GameObject _enterButton;
    [SerializeField] AudioSource _source;


    [Min(0)]
    [SerializeField] float _charSpeed = 0.1f;

    Coroutine _writeCorutine = null;

    public void SetText(string text, AudioClip clip)
    {
        _TMP.text = null;
        if(_writeCorutine != null)
            StopCoroutine(_writeCorutine);
        _writeCorutine = StartCoroutine(Write(text, clip));
    }

    private IEnumerator Write(string text, AudioClip clip)
    {
        _enterButton.SetActive(false);
        yield return new WaitForSeconds(_charSpeed);

        _source.clip = clip;

        foreach (char letter in text)
        {
            if(clip != null)
            {
                _source.Stop();
                _source.volume = Random.Range(0.8f, 1);
                _source.Play();
            }

            _TMP.text += letter;
            yield return new WaitForSeconds(_charSpeed);
        }

        EndWriteText.Invoke();
        _enterButton.SetActive(true);
    }
}
