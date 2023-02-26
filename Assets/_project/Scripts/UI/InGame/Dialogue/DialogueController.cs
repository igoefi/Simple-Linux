using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class DialogueController : MonoBehaviour
{
    public static UnityEvent EndDialogueEvent { get; private set; } = new();
    public static UnityEvent StartDialogueEvent { get; private set; } = new();

    private static readonly UnityEvent _rightClickEvent = new();

    [SerializeField] InputText _inputText;
    [SerializeField] BeautyOutput _outputText;
    [SerializeField] Image _sprite;
    [SerializeField] TMPro.TMP_Text _outputName;

    public bool IsInDialogue { get; private set; } = false;

    private static Dialogue _dialogue;

    private GameObject _needToPressButton;

    private bool _isOutputPast;

    private bool _isRightMousePast;

    private void Start()
    {
        _dialogue = null;

        if (_inputText != null) 
            _inputText.EndWriteText.AddListener(NextTurn);

        InputSystem.EnterEvent.AddListener(SkipPast);

        _isOutputPast = true;
        StartDialogueEvent.AddListener(NextTurn);

        _isRightMousePast = false;
        _rightClickEvent.AddListener(RightMouseNextDialogue);
    }

    public static void SetDialogue(Dialogue dialogue)
    {
        if (dialogue == null) return;
        _dialogue = dialogue;
        StartDialogueEvent.Invoke();
    }

    public static void RightClickDialogue() => _rightClickEvent.Invoke();

    public void NextTurn()
    {
        if (_dialogue == null) return;

        Queue<DialoguePhrase> phrases = _dialogue.GetPhraseQueue();

        IsInDialogue = true;

        PhraseWork(phrases.Dequeue());

        if (phrases.Count == 0)
        {
            if (_inputText != null)
                _inputText.Restart();

            _dialogue = null;
            IsInDialogue = false;
            EndDialogueEvent.Invoke();
        }
    }

    public void ButtonInputCountinue(GameObject button)
    {
        if (_dialogue == null || _needToPressButton != button) return;
        NextTurn();
    }

    public void SkipPast()
    {
        if (!_isOutputPast || _dialogue == null) return;
            _isOutputPast = false;
            NextTurn();

    }

    public void RightMouseNextDialogue()
    {
        if (_isRightMousePast)
        {
            _isRightMousePast = false;
            NextTurn();
        }
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

                if (phrase.GetIsHideAfter())
                    BeautyOutput.EndWriteText.AddListener(NextTurn);

                _isOutputPast = true;
                break;


            case DialoguePhrase.Past.InputText:

                if (phrase.GetText().Count() == 0)
                    _inputText.Start(phrase.GetName(), true);
                else
                    _inputText.Start(phrase.GetText(), false);

                break;


            case DialoguePhrase.Past.InputButton:
                _needToPressButton = phrase.GetButton();
                break;

            case DialoguePhrase.Past.RightMouseButton:
                _isRightMousePast = true;
                break;
        }

        SetActiveObjects(phrase.GetAwakeObjects());
    }

    private void SetActiveObjects(GameObject[] objects)
    {
        foreach (GameObject obj in objects)
            obj.SetActive(!obj.activeSelf);
    }
}
