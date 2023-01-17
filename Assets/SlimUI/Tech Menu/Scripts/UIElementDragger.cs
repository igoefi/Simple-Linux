using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
// Fromt Unity Drag and Drop Tutorial - How TO Drag and Drop UI Elements in Unity

public class UIElementDragger : MonoBehaviour
{

    public const string DRAGGABLE_TAG = "UIDrag";
    private bool dragging = false;
    private Vector2 originalPosition;
    private Transform objectToDrag;
    private Image objecttoDragImage;
    readonly List<RaycastResult> hitObjects = new();

    #region Monobehavior API

    void Update()
    {
        if (Input.GetButtonDown("Fire"))
        {
            objectToDrag = GetDraggableTransformUnderMouse();

            if (objectToDrag != null)
            {
                dragging = true;

                originalPosition = objectToDrag.position;
                objecttoDragImage = objectToDrag.GetComponent<Image>();
                objecttoDragImage.raycastTarget = false;
            }
        }

        if (dragging)
        {
            objectToDrag.position = Input.mousePosition;
        }

        if (Input.GetButtonUp("Fire") && dragging)
        {
            dragging = false;
            objecttoDragImage.raycastTarget = true;
        }
    }

    #endregion

    private GameObject GetObjectUnderMouse()
    {
        PointerEventData pointer = new(EventSystem.current);

        pointer.position = Input.mousePosition;
        EventSystem.current.RaycastAll(pointer, hitObjects);

        if (hitObjects.Count <= 0) return null;

        return hitObjects.First().gameObject;
    }

    private Transform GetDraggableTransformUnderMouse()
    {
        GameObject clickedObject = GetObjectUnderMouse();

        if (clickedObject != null && clickedObject.tag == DRAGGABLE_TAG)
        {
            return clickedObject.transform;
        }

        return null;
    }
}
