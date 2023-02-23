using UnityEngine;

public class DialogueTriggerButtonAnim : MonoBehaviour
{
    private DialogueTrigger _trigger;

    [SerializeField] GameObject BG;

    private void Start()
    {
        InputSystem.EnterEvent.AddListener(PressEnterButton);
        _trigger = GetComponent<DialogueTrigger>();
    }

    public void PressEnterButton()
    {
        _trigger.SetDialogOnController();

        InputSystem.EnterEvent.RemoveListener(PressEnterButton);
        BG.SetActive(false);
    }
}
