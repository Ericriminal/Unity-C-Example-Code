using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.EventSystems;
using UnityEngine.UI;

public class Draggable : EventTrigger
{
    private bool startDragging;
    private RectTransform rectParent;
    private RectTransform rect;
    private Answer answer;

    // Start is called before the first frame update
    void Start()
    {
        answer = GetComponent<Answer>();
        rect = GetComponent<RectTransform>();
        rectParent = transform.parent.gameObject.GetComponent<RectTransform>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 localPoint;
        if (startDragging)
        {
            RectTransformUtility.ScreenPointToLocalPointInRectangle(rectParent, Input.mousePosition,
                Camera.main, out localPoint);
            if (localPoint.x < -80f)
                localPoint.x = -80f;
            else if (localPoint.x > 80f)
                localPoint.x = 80;
            if (localPoint.y > 110f)
                localPoint.y = 100f;
            else if (localPoint.y < -235f)
                localPoint.y = -235f;
            rect.anchoredPosition3D = localPoint;
        }
    }

    public override void OnPointerDown(PointerEventData eventData)
    {
        if (eventData.button == PointerEventData.InputButton.Middle) {
            startDragging = true;
        } else if (eventData.button == PointerEventData.InputButton.Right) {
            answer.destroySelf();
        }
    }
    public override void OnPointerUp(PointerEventData eventData)
    {
        startDragging = false;
    }
}
