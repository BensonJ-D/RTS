using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;
using System.Linq;
using UnityEngine.EventSystems;

public class SelectionBox : MonoBehaviour
{
    private Vector3 mouseDownPoint;
    private Vector3 mouseDragEnd;

    [SerializeField]
    private RectTransform selectionRect;
    [SerializeField]
    private RectTransform selectFill;

    private void Start() {
        selectBox.gameObject.SetActive(false);
        selectFill.gameObject.SetActive(false);
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            mouseDownPoint = Input.mousePosition;
        }

        if (Input.GetMouseButton(0))
        {
            mouseDragEnd = Input.mousePosition;
            if (!selectBox.gameObject.activeInHierarchy)
            {
                selectBox.gameObject.SetActive(true);
                selectFill.gameObject.SetActive(true);
            }

            float dx = Mathf.Abs(mouseDownPoint.x - mouseDragEnd.x);
            float dy = Mathf.Abs(mouseDownPoint.y - mouseDragEnd.y);

            selectBox.sizeDelta = new Vector2(dx, dy);
            selectFill.sizeDelta = new Vector2(dx, dy);

            Vector3 centre = (mouseDownPoint + mouseDragEnd) / 2f;
            centre.z = 0f;
            selectBox.position = centre;
            selectFill.position = centre;
        }

        if (Input.GetMouseButtonUp(0))
        {
            selectBox.gameObject.SetActive(false);
            selectFill.gameObject.SetActive(false);
        }
    }
}