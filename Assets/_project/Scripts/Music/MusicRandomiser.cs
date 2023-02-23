using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicRandomiser : MonoBehaviour
{
    [SerializeField] AudioClip[] _clips;

    private AudioSource _source;
    private void Start() =>
        _source = GetComponent<AudioSource>();

    private void Update()
    {
        if(!_source.isPlaying)
        {
            _source.clip = _clips[Random.Range(0, _clips.Length)];
            _source.Play();
        }    
    }
}
