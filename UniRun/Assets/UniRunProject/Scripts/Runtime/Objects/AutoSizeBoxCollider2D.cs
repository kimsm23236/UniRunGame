using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AutoSizeBoxCollider2D : MonoBehaviour
{
    public bool isUseParentSize = false;
    // Start is called before the first frame update
    void Start()
    {
        Vector2 objSize_ = default;
        BoxCollider2D boxCol = gameObject.GetComponentMust<BoxCollider2D>();
        RectTransform parentRectTransform = transform.parent.gameObject.GetComponentMust<RectTransform>();
        RectTransform rectTransform = gameObject.GetComponentMust<RectTransform>();

        if(isUseParentSize)
        {
            objSize_.x = parentRectTransform.sizeDelta.x;
            objSize_.y = rectTransform.sizeDelta.y;
        }
        else
        {
            objSize_.x = rectTransform.sizeDelta.x;
            objSize_.y = rectTransform.sizeDelta.y;
        }
        
        boxCol.size = objSize_;

        GFunc.Log($"Rect Size : {rectTransform.sizeDelta.x}, {rectTransform.sizeDelta.y}");   
    }
}
