using UnityEngine;

public class EnterButtonAnimator : MonoBehaviour
{
    private readonly Animator _anim;

    public EnterButtonAnimator()
    {
        _anim = GetComponent<Animator>();
    }

    private void OnEnable()
    {
        _anim.SetTrigger("Open");
    }
}
