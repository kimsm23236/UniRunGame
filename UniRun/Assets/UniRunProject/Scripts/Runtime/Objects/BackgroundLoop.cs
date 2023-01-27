using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundLoop : GComponent
{
    private float width = default;
    public override void Awake()
    {
        base.Awake();

        BoxCollider2D bgCollider = GetComponent<BoxCollider2D>();
        width = gameObject.GetSizeDelta().x;
    }
    // Start is called before the first frame update
    public override void Start()
    {
        
    }

    // Update is called once per frame
    public override void Update()
    {
        if(transform.localPosition.x <= -width)
        {
            RePosition();
        }
    }
    private void RePosition()
    {
        Vector3 offset = new Vector3(width * 2f, 0f , 0f);
        transform.localPosition = transform.localPosition + offset;
    }   // RePosition
}
