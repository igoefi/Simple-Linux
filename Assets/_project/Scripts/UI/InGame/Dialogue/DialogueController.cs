using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class DialogueController : MonoBehaviour
{
    public static UnityEvent EndDialogue { get; private set; } = new();
    public static UnityEvent StartDialogue { get; private set; } = new();

    [SerializeField] InputText _inputText;
    [SerializeField] BeautyOutput _outputText;
    [SerializeField] Image _sprite;
    [SerializeField] TMPro.TMP_Text _outputName;

    [SerializeField] bool _isCreateNewInput = false;
    [SerializeField] Vector2 _inputIndent;

    public bool IsInDialogue { get; private set; } = false;

    private static Dialogue _dialogue;

    private GameObject _needToPressButton;

    private bool _start = false;

    private bool _isOutputPast;

    private void Start()
    {
        _dialogue = null;

        if(_inputText != null)
            _inputText.EndWriteText.AddListener(NextTurn);

        InputSystem.EnterEvent.AddListener(SkipPast);

        _isOutputPast = true;
        StartDialogue.AddListener(NextTurn);
    }

    public static void SetDialogue(Dialogue dialogue)
    {
        if (dialogue == null) return;
        _dialogue = dialogue;
    }

    public void NextTurn()
    {
        Debug.Log("Next");
        if (_dialogue == null) return;
        var phrases = _dialogue.GetPhraseQueue();

        IsInDialogue = true;

        PhraseWork(phrases.Dequeue());

        if (phrases.Count == 0)
        {
            if(_inputText != null)
                _inputText.Restart();

            _dialogue = null;
            IsInDialogue = false;
            EndDialogue.Invoke();
        }
    }

    public void ButtonInputCountinue(GameObject button)
    {
        if (_dialogue == null || _needToPressButton != button) return;
        NextTurn();
    }

    public void SkipPast()
    {
        if (_isOutputPast && _dialogue != null)
            NextTurn();
    }

    private void CreateNewInput()
    {
        InputText input = Instantiate(_inputText, _inputText.transform);
        input.transform.position = _inputText.transform.position;
        input.transform.localScale = _inputText.transform.localScale;

        _inputText.transform.position += (Vector3)_inputIndent;

        Destroy(_inputText.GetComponent<InputSystem>());
        _inputText = input;
    }

    private void PhraseWork(DialoguePhrase phrase)
    {
        _isOutputPast = false;
        _needToPressButton = null;
        BeautyOutput.EndWriteText.RemoveListener(NextTurn);
        switch (phrase.GetPast())
        {
            case DialoguePhrase.Past.Output:
                if (_outputText != null)
                    _outputText.SetText(phrase.GetText(), phrase.GetAudio());

                if (_outputName != null)
                    _outputName.SetText(phrase.GetName());

                if (_sprite != null)
                    _sprite.sprite = phrase.GetSprite();

                if(phrase.GetIsHideAfter())
                    BeautyOutput.EndWriteText.AddListener(NextTurn);

                _isOutputPast = true;
                break;


            case DialoguePhrase.Past.InputText:
                if (_start)
                {
                    if (_isCreateNewInput)
                        CreateNewInput();
                    _inputText.Start(phrase.GetText());
                }
                else
                {
                    _inputText.Start(phrase.GetText());
                    _start = true;
                }
                break;


            case DialoguePhrase.Past.InputButton:
                _needToPressButton = phrase.GetButton();
                break;
        }

        SetActiveObjects(phrase.GetAwakeObjects());
    }

    private void SetActiveObjects(GameObject[] objects)
    {
        foreach (var obj in objects)
            obj.SetActive(!obj.activeSelf);
    }
}
