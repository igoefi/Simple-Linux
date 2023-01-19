using System.Collections;
using UnityEngine;

public class DialogueTriggerButtonAnim : MonoBehaviour
{
    private DialogueTrigger _trigger;
    
    [SerializeField] GameObject BG;
    [SerializeField] float _timeToWait;

    private void Start()
    {
        InputSystem.EnterEvent.AddListener(PressEnterButton);
        _trigger = GetComponent<DialogueTrigger>();
    }

    public void PressEnterButton()
    {
        _trigger.SetDialogOnController();
        StartCoroutine(Wait());
    }

    private IEnumerator Wait()
    {
        yield return new WaitForSeconds(_timeToWait);
        InputSystem.EnterEvent.RemoveListener(PressEnterButton);
        InputSystem.EnterEvent.Invoke();
        BG.SetActive(false);
    }
}
