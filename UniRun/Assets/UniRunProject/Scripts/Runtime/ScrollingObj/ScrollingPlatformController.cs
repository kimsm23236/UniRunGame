using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScrollingPlatformController : ScrollingObjController
{
    // Start is called before the first frame update
    private bool isStart = true;
    public override void Start()
    {
        base.Start();
    }

    // Update is called once per frame
    public override void Update()
    {
        base.Update();
    }

    protected override void InitObjsPosition()
    {
        base.InitObjsPosition();

        Vector2 posOffset = Vector2.zero;
        
        float xPos = objPrefabSize.x * (scrollingObjCount - 1) * (-1) * 0.5f;
        float yPos = prefabYPos;

        for(int i = 0; i < scrollingObjCount; i++)
        {
            
            scrollingPool[i].SetLocalPosition(xPos, yPos, 0f);
            GFunc.Log($"xPos : {xPos}, yPos : {yPos}");
            // 랜덤 오프셋 설정
            posOffset = GetRandomPosOffset();
            if(isStart == true && i == 1)
            {
                xPos = xPos + objPrefabSize.x;
                isStart = false;
            }
            else
            {
                xPos = xPos + objPrefabSize.x + posOffset.x;
            }
            
            yPos = prefabYPos + posOffset.y;
        }   // 생성한 오브젝트를 가로로 왼쪽부터 차례대로 정렬하는 루프

        

    }

    protected override void RepositionFirstObj()
    {
        base.RepositionFirstObj();

        float firstScrollObjXPos = scrollingPool[0].transform.localPosition.x;

        float prefabYPos = objPrefab.transform.localPosition.y;

        // float lastScrollObjXPos = scrollingPool[scrollingObjCount - 1].transform.localPosition.x;
        // if(lastScrollObjXPos <= objPrefabSize.x * 0.5f)
        float lastScrollObjXPos = scrollingPool[scrollingObjCount - 1].transform.localPosition.x;
        
        if(lastScrollObjXPos <= objPrefabSize.x * 0.5f)
        {
            Vector2 offset = GetRandomPosOffset();
            Vector2 lastPlatformPos = Vector2.zero;
            lastPlatformPos.x = Mathf.Floor(scrollingObjCount * 0.5f) * objPrefabSize.x + (objPrefabSize.x * 0.5f);
            // scrollingPool[scrollingObjCount-1].transform.position;

            Vector3 newPosition = Vector3.zero;
            newPosition.x = lastPlatformPos.x + offset.x;
            newPosition.y = prefabYPos + offset.y;

            scrollingPool[0].SetLocalPosition(newPosition.x, newPosition.y, newPosition.z);

            scrollingPool.Add(scrollingPool[0]);
            scrollingPool.RemoveAt(0);
        }   // if : 스크롤링 오브젝트의 마지막 오브젝트가 화면 상의 절반정도 Draw 되는 때
    }

    // ! 랜덤한 포지션 오프셋을 리턴하는 함수
    private Vector2 GetRandomPosOffset()
    {
        Vector2 offset = Vector2.zero;
        offset.x = Random.Range(50f, 500f);
        offset.y = Random.Range(-20, 100f);

        return offset;
    }
}
