using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Dialogue
{
    [SerializeField] string[] _texts;
    [SerializeField] Past[] _pasts;

    [SerializeField] int _numCharsToDelete;

    private readonly Queue<string> _textsQueue = new();
    private readonly Queue<Past> _pastsQueue = new();

    public enum Past
    {
        Input,
        Output
    }

    public void GetQueues(out Queue<string> texts, out Queue<Past> pasts)
    {
        texts = _textsQueue;
        pasts = _pastsQueue;
    }

    public void Setup()
    {
        for (int i = 0; i < _texts.Length; i++)
        {
            _texts[i] = _texts[i].Substring(_numCharsToDelete);
        }

        for (int i = 0; i < _texts.Length; i++)
        {
            _textsQueue.Enqueue(_texts[i]);
            _pastsQueue.Enqueue(_pasts[i]);
        }
    }
}
