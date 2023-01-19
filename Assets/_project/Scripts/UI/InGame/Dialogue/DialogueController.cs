using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogueController : MonoBehaviour
{
    [SerializeField] InputText _inputText;
    [SerializeField] BeautyOutput _outputText;
    [SerializeField] Image _sprite;
    [SerializeField] TMPro.TMP_Text _outputName;

    [SerializeField] bool _isCreateNewInput = false;
    [SerializeField] Vector2 _inputIndent;

    public bool IsInDialogue { get; private set; } = false;

    private static Dialogue _dialogue;

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

    public void NextTurn()
    {
        if (_dialogue == null) return;
        var phrases = _dialogue.GetPhraseQueue();

        IsInDialogue = true;

        var phrase = phrases.Dequeue();

        if (phrase.GetPast() == DialoguePhrase.Past.Output)
        {
            if (_outputText != null)
                _outputText.SetText(phrase.GetText(), phrase.GetAudio());
            if(_outputName != null)
                _outputName.SetText(phrase.GetName());
            if(_sprite != null)
                _sprite.sprite = phrase.GetSprite();
        }
        else
        {
            if (!_start)
            {
                _inputText.Start(phrase.GetText());
                _start = true;
            }
            else
            {
                if (_isCreateNewInput)
                    CreateNewInput();
                _inputText.Start(phrase.GetText());
            }
        }

        _isOutputPast = phrase.GetPast() == DialoguePhrase.Past.Output;

        if (phrases.Count == 0)
        {
            _inputText.Restart();
            _dialogue = null;
            IsInDialogue = false;
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
