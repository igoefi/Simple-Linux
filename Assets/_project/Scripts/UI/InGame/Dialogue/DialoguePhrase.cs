using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

[System.Serializable]
public class DialoguePhrase
{
    [Header("Main")]
    [SerializeField] string _name;
    [TextArea]
    [SerializeField] string _text;
    [SerializeField] AudioClip _audio;
    [SerializeField] bool _isHideAfterShow;
    [SerializeField] Sprite _sprite;
    [SerializeField] Past _past;
    [SerializeField] GameObject[] _setAwakeObjects;

    [Header("If ButtonPast")]
    [SerializeField] GameObject _usedButton;
    public enum Past
    {
        InputText,
        InputButton,
        Output
    }

    public string GetName() { return _name; }
    public string GetText() { return _text; }
    public Past GetPast() { return _past; }
    public AudioClip GetAudio() { return _audio; }
    public bool GetIsHideAfter() { return _isHideAfterShow; }
    public Sprite GetSprite() { return _sprite; }
    public GameObject GetButton() { return _usedButton; }
    public void SetSprite(Sprite sprite){ if (_sprite == null) _sprite = sprite;}
    public GameObject[] GetAwakeObjects() { return _setAwakeObjects; }
}
