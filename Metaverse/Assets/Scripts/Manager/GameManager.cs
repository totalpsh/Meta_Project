using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    private int currentScore = 0;

    static public int bestScore = 0;

    public PlayerFlappyController player;

    private UIManager uiManager;

    public UIManager UImanager { get { return uiManager; } }

    private void Awake()
    {
        Instance = this;
        player = FindObjectOfType<PlayerFlappyController>();
        uiManager = FindObjectOfType<UIManager>();
    }

    private void Start()
    {
        uiManager = FindObjectOfType<UIManager>();
        if (uiManager == null)
        {
            Debug.Log("UIManager null");
        }
    }

    public void GameOver()
    {
        uiManager.SetRestart();
    }

    public void StartGame()
    {
        uiManager.SetPlayGame();

    }
    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void EnterGame(int roomType)
    {
        switch(roomType)
        {
            case 0:
            SceneManager.LoadScene("GameScene");
                break;
            case 1:
                SceneManager.LoadScene("ShootingScene");
                break;
        }
    }

    public void ReturnLobby()
    {
        SceneManager.LoadScene("LobbyScene");
    }

    public void AddScore(int score)
    {
        currentScore += score;
        if(currentScore > bestScore) bestScore = currentScore; 
        uiManager.UpdateScore(currentScore, bestScore);
    }

    public void SetResult()
    {
        uiManager.GameOverResult(bestScore, currentScore);
        //uiManager.HomeBestScore(bestScore, currentScore);
    }

    public void SetHomeBest()
    {
        //Debug.Log("GameManager: SetHomeBest");
        //uiManager.SetBestScore(bestScore);
    }

}
