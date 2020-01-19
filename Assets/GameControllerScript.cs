using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameControllerScript : MonoBehaviour
{
    public Text scoreText;
    public Text maxScoreText;
    private int score = 0;
    private int maxScore = 0;
    public GameObject startScreen;
    public Button startButton;
    private static bool isGameStarted = false;

    public GameObject finishScreen;
    public Button restartButton;

    private static bool isGameFinished = false;


    public bool getIsGameStarted()
    {
        return isGameStarted;
    }

    public void stopTheGame()
    {
        isGameStarted = false;
        isGameFinished = true;

        if (score > maxScore)
            maxScore = score;

        maxScoreText.text = "Max Score :" + maxScore;

        finishScreen.SetActive(true);
    }
    private static GameControllerScript instanse;

 
    public static GameControllerScript getInstanse()
    {
        return instanse;
    }
    public void increaseScore (int increment)
    {
        score += increment;
        scoreText.text = "Score : " + score;
    }
    // Start is called before the first frame update
    void Start()
    {
        instanse = this;
        finishScreen.SetActive(false);
       
        startButton.onClick.AddListener(delegate
        {
            scoreText.text = "Score : " + score;
            startScreen.SetActive(false);
            isGameStarted = true;
        });
    }

    // Update is called once per frame
    void Update()
    {
       if(isGameFinished)
        {
            restartButton.onClick.AddListener(delegate
            {
                finishScreen.SetActive(true);
                isGameFinished = false;
                isGameStarted = true;
            });
        }
    }
}
