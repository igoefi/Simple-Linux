using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

[System.Serializable]
public class DialoguePhrase
{
    [SerializeField] string _name;
    [SerializeField] string _text;
    [SerializeField] Past _past;
    [SerializeField] AudioClip _audio;
    [SerializeField] bool _isHideAfterShow;
    [SerializeField] Sprite _sprite;

    public enum Past
    {
        Input,
        Output
    }

    public string GetName() { return _name; }
    public string GetText() { return _text; }
    public Past GetPast() { return _past; }
    public AudioClip GetAudio() { return _audio; }
    public bool GetIsHideAfter() { return _isHideAfterShow; }
    public Sprite GetSprite() { return _sprite; }
    public void SetSprite(Sprite sprite)
    {
        if (_sprite == null)
            _sprite = sprite;
    }

}
