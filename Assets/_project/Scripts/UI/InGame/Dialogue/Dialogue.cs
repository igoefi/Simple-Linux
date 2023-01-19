using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Dialogue
{
    [SerializeField] DialoguePhrase[] _phrases;
    [SerializeField] LavitoPositionsFile _avataresFile;


    private readonly Queue<DialoguePhrase> _phraseQueue = new();

    public Queue<DialoguePhrase> GetQueuePhrases() { return _phraseQueue; }

    public void Setup()
    {
        List<Sprite> avataresArray = new();

        foreach (var avatar in _avataresFile.GetAvatars())
            if (avatar.IsBuy)
                avataresArray.Add(avatar.GetSprite());

        if (avataresArray.Count != 0)
        {
            System.Random rand = new();
            foreach (var phrase in _phrases)
                phrase.SetSprite(avataresArray[rand.Next(0, avataresArray.Count)]);
        }
        else
        {
            //на случай бедности
            foreach (var phrase in _phrases)
                if (phrase.GetSprite() == null)
                    phrase.SetSprite(_avataresFile.GetAvatars()[0].GetSprite());
        }

        for (int i = 0; i < _phrases.Length; i++)
            _phraseQueue.Enqueue(_phrases[i]);
    }

    public Queue<DialoguePhrase> GetPhraseQueue() { return _phraseQueue; }
}
