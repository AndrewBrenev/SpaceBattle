using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameControllerScript : MonoBehaviour
{
    public Text scoreText;
    public Text statisticsLabel;
    private int score = 0;
    private int maxScore = 0;

    private int enemiesKilled = 0;
    private int asteroidsKilled = 0;
    private int torpedosKilled = 0;
    private float gameTime = 0;


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

        deletePreviusGameObjects();
        updateGameStatistic();
        showGameStatistic();

        finishScreen.SetActive(true);
    }
    private void deletePreviusGameObjects()
    {
        deleteAllGameObjectsWithTag("Asteroid");
        deleteAllGameObjectsWithTag("PlayerShot");
        deleteAllGameObjectsWithTag("Torpedo");
        deleteAllGameObjectsWithTag("Enemy");
        deleteAllGameObjectsWithTag("EnemyShot");
    }
    private void deleteAllGameObjectsWithTag(string tag)
    {
        var lastGameObjects = GameObject.FindGameObjectsWithTag(tag);
        for (int i = 0; i < lastGameObjects.Length; i++)
        {
            Destroy(lastGameObjects[i]);
        }
    }
    private void showGameStatistic()
    {
        statisticsLabel.text =
        "Max Score :" + maxScore  +
        "\nAsteroid Destroid:" + asteroidsKilled  +
        "\nTorpedos Exploided : :" + torpedosKilled +
        "\nEnemies killed :" + enemiesKilled +
        "\nGame time :" + gameTime + " sec";
    }
   
    private void updateGameStatistic()
    {
        setMaxScore();
        calculateGameTime();
    }
    private void calculateGameTime()
    {
        if (isGameFinished)
        {
            gameTime = Time.time - gameTime;
        }
    }
    private void setMaxScore()
    {
        if (score > maxScore)
            maxScore = score;
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
    public void increaseEnemiesKilledCount()
    {
        enemiesKilled +=1;
    }
    public void increaseAsteroidExplosionCount()
    {
       asteroidsKilled += 1;
    }
    public void increaseTorpedosExplosionCount()
    {
        torpedosKilled += 1;
    }

    private void restartGame()
    {
        finishScreen.SetActive(false);
       
        gameTime = Time.time;
        score = 0;
        enemiesKilled = 0;
        asteroidsKilled = 0;
        torpedosKilled = 0;

        PlayerScript.getInstanse().setStartPosition();

        increaseScore(0);
        isGameFinished = false;
        isGameStarted = true;
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
            gameTime = Time.time;
        });
    }

    // Update is called once per frame
    void Update()
    {
       if(isGameFinished)
        {
            restartButton.onClick.AddListener(delegate
            {
                restartGame();
            });
        }
    }
}
