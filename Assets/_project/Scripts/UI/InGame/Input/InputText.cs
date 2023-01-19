using TMPro;
using UnityEngine;
using UnityEngine.Events;

public class InputText : MonoBehaviour
{
    public UnityEvent EndWriteText { get; private set; } = new();

    [SerializeField] TMP_Text _TMP;

    private string _needText;
    private bool _isFinish = true;

    private void Start()
    {
        InputSystem.DeleteEvent.AddListener(Delete);
        InputSystem.EnterEvent.AddListener(CheckResult);
        InputSystem.KeyEvent.AddListener(AddText);
    }

    public void Restart()
    {
        _TMP.text = null;
    }

    public void Start(string newText)
    {
        _TMP.text = null;
        _isFinish = false;
        _needText = newText;
    }

    private void Delete()
    {
        if (_TMP.text.Length == 0) return;
        _TMP.text = _TMP.text.Remove(_TMP.text.Length - 1);
    }

    private void CheckResult()
    {
        if (_TMP.text != _needText || _TMP.text == null) return;

        _isFinish = true;
        EndWriteText.Invoke();
    }

    private void AddText(string text)
    {
        if (_isFinish) return;

        _TMP.text += text;
    }
}
