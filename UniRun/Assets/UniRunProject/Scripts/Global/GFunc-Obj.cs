using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.SceneManagement;

public static partial class GFunc
{
    // 특정 오브젝트의 자식 오브젝트를 서치해서 찾아주는 함수
    public static GameObject FindChildObj(this GameObject targetObj_, string objName_)
    {
        GameObject searchResult = default;
        GameObject searchTarget = default;

        for(int i = 0 ; i < targetObj_.transform.childCount; i++)
        {
            searchTarget = targetObj_.transform.GetChild(i).gameObject;
            if(searchTarget.name.Equals(objName_))
            {
                searchResult = targetObj_.transform.GetChild(i).gameObject;
                return searchResult;
            }
            else
            {
                searchResult = FindChildObj(searchTarget, objName_);
            }
        }   // loop
        return searchResult;
    }
    // 특정 오브젝트의 자식 오브젝트를 서치해서 찾아주는 함수
    private static GameObject GetChildObj(this GameObject targetObj_, string objName_)
    {
        GameObject SearchResult = default;
        for(int i = 0; i < targetObj_.transform.childCount; i++)
        {
            if(targetObj_.transform.GetChild(i).gameObject.name.Equals(objName_))
            {
                // 찾았다!
                Debug.Log("자식 찾음");
                SearchResult = targetObj_.transform.GetChild(i).gameObject;
                return SearchResult;
            }
            else
            {
                continue;
            }
        }   // loop
        // 이름이 같은 오브젝트를 찾지 못한 경우 디폴트 리턴
        return SearchResult;
    }
    // 씬의 루트 오브젝트를 서치해서 찾아주는 함수
    public static GameObject GetRootObj(string objName_)
    {
        Scene activeScene_ = GetActiveScene();
        GameObject[] rootObj_ = activeScene_.GetRootGameObjects();
        
        GameObject targetObj = default;
        foreach(GameObject rootObj in rootObj_)
        {
            if(rootObj.name.Equals(objName_))
            {
                targetObj = rootObj;
                return targetObj;
            }
            else 
            {
                continue;
            }
        }   // loop

        return targetObj;
    }   // GetRootObj()

    // 현재 활성화 되어 있는 씬을 찾아주는 함수
    public static Scene GetActiveScene()
    {
        Scene activeScene = SceneManager.GetActiveScene();
        return activeScene;
    }   // GetActiveScene()

    //! 오브젝트의 로컬 포지션을 변경하는 함수
    public static void SetLocalPosition(this GameObject obj_, float x, float y, float z)
    {
        obj_.transform.localPosition = new Vector3(x, y, z);
    }

    //! 오브젝트의 로컬 포지션을 연산하는 함수
    public static void AddLocalPosition(this GameObject obj_, float x, float y, float z)
    {
        obj_.transform.localPosition = obj_.transform.localPosition + new Vector3(x,y,z);
    }   // AddLocalPos()

    public static void Translate(this Transform transform_, Vector2 moveVector)
    {
        transform_.Translate(moveVector.x, moveVector.y, 0f);
    }   // Translate
    // 컴포넌트 가져오는 함수
    public static T GetComponentMust<T>(this GameObject obj)
    {
        T component_ = obj.GetComponent<T>();

        GFunc.Assert(component_.IsValid<T>() != false, string.Format("{0}에서 {1}을(를) 찾을 수 없습니다.",
                                                         obj.name, component_.GetType().Name));
        //GFunc.Assert(!isComponentNull, string.Format("{0}에서 {1}을(를) 찾을 수 없습니다.",
        //                                                 obj.name, component_.GetType().Name));

        return component_;
    }

    //! RectTransform 에서 sizeDelta를 찾아서 리턴하는 함수
    public static Vector2 GetSizeDelta(this GameObject obj_)
    {
        return obj_.GetComponentMust<RectTransform>().sizeDelta;
    }
}
