// Enable the selection of a ScrollView which can be dragged.
// This script only chooses the ScrollView child of the Canvas.

using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class Drag : MonoBehaviour, IBeginDragHandler
{
    private GameObject m_DraggingIcon;

    public void Start()
    {
        m_DraggingIcon = new GameObject("icon");
    }

    public void OnBeginDrag(PointerEventData data)
    {
        Debug.Log("OnBeginDrag");

        var canvas = FindInParents<Canvas>(gameObject);
        if (canvas == null)
            return;

        m_DraggingIcon.transform.SetParent(canvas.transform, false);
        m_DraggingIcon.transform.SetAsLastSibling();

        Debug.Log("Dragging started");
    }

    // locate and return the Canvas
    static public T FindInParents<T>(GameObject go) where T : Component
    {
        if (go == null) return null;
        var comp = go.GetComponent<T>();

        if (comp != null)
            return comp;

        Transform t = go.transform.parent;
        while (t != null && comp == null)
        {
            comp = t.gameObject.GetComponent<T>();
            t = t.parent;
        }
        return comp;
    }
}