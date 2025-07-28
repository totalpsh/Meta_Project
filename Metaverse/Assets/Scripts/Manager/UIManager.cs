using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEditor.Timeline;
using UnityEngine;


public enum UIState
{
    Home,
    Game,
    GameOver
}

public class UIManager : MonoBehaviour
{
    HomeUI homeUI;
    GameUI gameUI;
    GameOverUI gameOverUI;
    private UIState currentState;

    private void Awake()
    {
        homeUI = GetComponentInChildren<HomeUI>(true);
        homeUI.Init(this);
        gameUI = GetComponentInChildren<GameUI>(true);
        gameUI.Init(this);
        gameOverUI = GetComponentInChildren<GameOverUI>(true);
        gameOverUI.Init(this);

        if (homeUI == null) Debug.Log("HomeUI null");
        if (gameUI == null) Debug.Log("GameUI null");
        if (gameOverUI == null) Debug.Log("GameOverUI null");

        ChangeState(UIState.Home);
        
    }

    public void SetPlayGame()
    {
        ChangeState(UIState.Game);
        Time.timeScale = 1.0f;
    }

    public void SetRestart()
    {
        ChangeState(UIState.GameOver);
        GameManager.Instance.SetResult();
    }

    public void ChangeState(UIState state)
    {
        currentState = state;

        if(currentState == UIState.Home) Time.timeScale = 0.0f;

        homeUI.SetActive(currentState);
        gameUI.SetActive(currentState);
        gameOverUI.SetActive(currentState);
    }

    public void UpdateScore(int score, int bestScore)
    {
        gameUI.UpdateScore(score);
        //homeUI.SetBestScore(bestScore);
    }

    public void GameOverResult(int bestScore, int score)
    {
        gameOverUI.GameScore(bestScore, score);
    }
}
