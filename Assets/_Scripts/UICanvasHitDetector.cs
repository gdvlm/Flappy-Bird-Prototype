using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class UICanvasHitDetector : MonoBehaviour
{
    private GraphicRaycaster _graphicRaycaster;

    void Awake()
    {
        _graphicRaycaster = GetComponent<GraphicRaycaster>();
    }

    // Use this method to check if the current mouse if over UI.
    // Taken from: https://stackoverflow.com/a/73217597 and tweaked the return condition
    public bool IsPointerOverUI()
    {
        // Obtain the current mouse position.
        var mousePosition = Mouse.current.position.ReadValue();

        // Create a pointer event data structure with the current mouse position.
        var pointerEventData = new PointerEventData(EventSystem.current);
        pointerEventData.position = mousePosition;

        // Use the GraphicRaycaster instance to determine how many UI items
        // the pointer event hits.  If this value is greater-than zero, skip
        // further processing.
        var results = new List<RaycastResult>();
        _graphicRaycaster.Raycast(pointerEventData, results);
        
        return results.Any(r => r.gameObject.name.EndsWith("Button"));        
    }
}
