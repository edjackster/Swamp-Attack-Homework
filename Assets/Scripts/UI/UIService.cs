using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using System.Collections.Generic;

[RequireComponent(typeof(GraphicRaycaster))]
public class UIService : MonoBehaviour
{
    [SerializeField]private EventSystem _eventSystem;
    
    private GraphicRaycaster _graphicRaycaster;

    private void Awake()
    {
        _graphicRaycaster = GetComponent<GraphicRaycaster>();
        _eventSystem = EventSystem.current;
    }

    public bool IsPointerOverUI()
    {
        var pointerData = new PointerEventData(_eventSystem)
        {
            position = Input.mousePosition
        };
        var results = new List<RaycastResult>();
        _graphicRaycaster.Raycast(pointerData, results);
        return results.Count > 0;
    }
}
