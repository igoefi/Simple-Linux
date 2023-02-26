using UnityEngine;

public class DialogueTriggerButtonAnim : MonoBehaviour
{
    private DialogueTrigger _trigger;

    [SerializeField] GameObject BG;

    private void Start()
    {
        InputSystem.EnterEvent.AddListener(PressEnter);
        _trigger = GetComponent<DialogueTrigger>();
    }

    public void PressButton() => InputSystem.EnterEvent.Invoke();

    public void PressEnter()
    {
        _trigger.SetDialogOnController();

        InputSystem.EnterEvent.RemoveListener(PressEnter);
        BG.SetActive(false);
    }
}
