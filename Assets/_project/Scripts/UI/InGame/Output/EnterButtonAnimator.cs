using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnterButtonAnimator : MonoBehaviour
{
    private Animator _anim;

    public EnterButtonAnimator()
    {
        _anim = GetComponent<Animator>();
    }

    private void OnEnable()
    {
        _anim.SetTrigger("Open");
    }
}
