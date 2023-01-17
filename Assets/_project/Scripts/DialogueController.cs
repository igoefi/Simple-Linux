using System.Collections.Generic;
using UnityEngine;

public class DialogueController : MonoBehaviour
{
    [SerializeField] InputText _inputText;
    [SerializeField] BeautyOutput _outputText;

    private static Dialogue _dialogue;

    [SerializeField] Vector2 _inputIndent;

    [SerializeField] bool _isCreateNewInput = false;

    private bool _start = false;

    private bool _isOutputPast;

    private void Start()
    {
        _dialogue = null;

        _inputText.EndWriteText.AddListener(NextTurn);
        InputSystem.EnterEvent.AddListener(SkipPast);

        _isOutputPast = true;
    }

    public static void SetDialogue(Dialogue dialogue)
    {
        if (dialogue != null)
            _dialogue = dialogue;
    }

    private void SkipPast()
    {
        if (_isOutputPast && _dialogue != null)
            NextTurn();
    }

    private void NextTurn()
    {
        _isOutputPast = false;

        _dialogue.GetQueues(out Queue<string> texsts, out Queue<Dialogue.Past> parts);

        if (texsts.Count == 0)
        {
            _inputText.Restart();
            return;
        }

        if (parts.Dequeue() == Dialogue.Past.Output)
        {
            if (_outputText != null)
                _outputText.SetText(texsts.Dequeue());

            _isOutputPast = true;
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

        if (texsts.Count == 0)
            _dialogue = null;
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
