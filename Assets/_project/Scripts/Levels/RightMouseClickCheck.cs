using UnityEngine;

public class RightMouseClickCheck : MonoBehaviour
{
    private void OnMouseOver()
    {
        Debug.Log("dssfd");
        if (Input.GetKeyDown(KeyCode.Mouse1))
            DialogueController.RightClickDialogue();
    }
}
