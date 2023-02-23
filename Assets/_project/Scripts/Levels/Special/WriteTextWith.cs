using System.Linq;
using TMPro;
using UnityEngine;

public class WriteTextWith : MonoBehaviour
{
    [SerializeField] TMP_Text _text;

    private TMP_Text _mainText;

    private void Start()
    {
        Debug.Log("DDDD");
        _mainText = GetComponent<TMP_Text>();
    }

    private void Update()
    {
        _mainText.text = _text.text;

        if (_text.text == null) return;

        if (_text.text.Count() > 20)
            _text.text = _mainText.text;
    }
}
