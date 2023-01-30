using UnityEngine;

public class DialogueTrigger : MonoBehaviour
{
    [SerializeField] Dialogue _dialogue;
    [SerializeField] bool _playOnAwake;

    private void Start()
    {
        if (_playOnAwake)
            SetDialogOnController();
    }
    public void SetDialogOnController()
    {
        _dialogue.Setup();

        DialogueController.SetDialogue(_dialogue);
    }
}
