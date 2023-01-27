using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.SceneManagement;

public static partial class GFunc
{
    // 게임을 종료하는 함수
    public static void QuitGame()
    {
#if UNITY_EDITOR
                UnityEditor.EditorApplication.isPlaying = false;
#else
                Application.Quit();
#endif
    }   // QuitGame()
    public static void LoadScene(string sceneName_)
    {
        SceneManager.LoadScene(sceneName_);
    }

    public static void SuminKim(this GameObject obj_)
    {
        Debug.Log("킹수민 게임오브젝트 확장 함수");
    }
    public static void SuminKing(this string str_)
    {
        Debug.Log("킹수민 스트링 확장 함수");
    }
}
