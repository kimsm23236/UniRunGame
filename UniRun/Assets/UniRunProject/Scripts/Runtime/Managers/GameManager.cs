using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance = default;

    public bool isGameOver = false;
    private const string UI_OBJS = "UIObjs";
    private const string SCORE_TEXT_OBJ = "Score Text";
    private const string GAME_OVER_UI = "GameOver Text";
    private GameObject scoreTxtObj = default;
    private GameObject gameoverUi = default;
    private int score = default;

    void Awake()
    {
        if(instance == null)
        {
            instance = this;
            // init
            isGameOver = false;
            GameObject uiobjs = GFunc.GetRootObj(UI_OBJS);
            scoreTxtObj = uiobjs.FindChildObj(SCORE_TEXT_OBJ);
            gameoverUi = uiobjs.FindChildObj(GAME_OVER_UI);

            score = 0;
        }
        else
        {
            GFunc.LogWarning("[System] GameManager : Duplicated warning");
            Destroy(gameObject);
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(isGameOver && Input.GetMouseButtonDown(0))
        {
            GFunc.LoadScene(GFunc.GetActiveScene().name);
        }
    }

    public void AddScore(int newScore)
    {
        if(isGameOver)
            return;
        
        score += newScore;
        scoreTxtObj.SetTextMeshPro($"Score : {score}");
    }   // AddScore()

    // ! 사망시 게임오버를 출력하는 메서드
    public void OnPlayerDead()
    {
        isGameOver = true;
        gameoverUi.SetActive(true);
    }   // OnPlayerDead()
}
