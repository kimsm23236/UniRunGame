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
}
