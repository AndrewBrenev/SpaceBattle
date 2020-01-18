using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameControllerScript : MonoBehaviour
{
    public Text scoreText;
    private int score = 0;
    public GameObject screen;

    private static bool isGameStarted = false;
    public bool getIsGameStarted()
    {
        return isGameStarted;
    }

    public void stopTheGame()
    {
        isGameStarted = true;
    }
    private static GameControllerScript instanse;

    public Button startButton;
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
        startButton.onClick.AddListener(delegate
        {
            screen.SetActive(false);
            isGameStarted = true;
        });
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
