using UnityEngine;

public class DialogueTrigger : MonoBehaviour
{
    [SerializeField] Dialogue _dialogue;

    public void SetDialogOnController()
    {
        _dialogue.Setup();

        DialogueController.SetDialogue(_dialogue);
        gameObject.SetActive(false);
    }
}
