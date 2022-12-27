using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PastTextsController : MonoBehaviour
{
    [SerializeField] InputText _inputText;
    [SerializeField] BeautyOutput _outputText;

    [SerializeField] Dialogue2 _dialogue;

    [SerializeField] Vector2 _inputIndent;

    [SerializeField] bool _isCreateNewInput = false;

    private bool _start = false;

    private void Start()
    {
        _inputText.EndWriteText.AddListener(SetTurn);
        _outputText.EndWriteText.AddListener(SetTurn);

        _dialogue.Setup();

        SetTurn();
    }

    private void SetTurn()
    {
        _dialogue.GetQueues(out Queue<string> texsts, out Queue<Dialogue2.Past> parts);

        if (texsts.Count == 0)
        {
            _inputText.Restart();
            return;
        }

        if (parts.Dequeue() == Dialogue2.Past.Output)
        {
            if(_outputText != null)
                _outputText.SetText(texsts.Dequeue());
        }
        else
        {
            if (!_start)
            {
                _inputText.Start(texsts.Dequeue());
                _start = true;
            }
            else
            {
                if (_isCreateNewInput)
                    CreateNewInput();
                _inputText.Start(texsts.Dequeue());
            }
        }
    }
    private void CreateNewInput()
    {
        InputText input = Instantiate(_inputText, transform);
        input.transform.position = _inputText.transform.position;
        input.transform.localScale = _inputText.transform.localScale;

        _inputText.transform.position += (Vector3)_inputIndent;

        Destroy(_inputText.GetComponent<InputSystem>());
        _inputText = input;
    }
}
