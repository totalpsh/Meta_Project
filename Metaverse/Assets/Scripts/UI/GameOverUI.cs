using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class GameOverUI : BaseUI
{
    public Button startButton;
    public Button exitButton;
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI bestScoreText;

    public override void Init(UIManager uiManager)
    {
        this.uiManager = uiManager;

        startButton.onClick.AddListener(OnClickStartButton);
        exitButton.onClick.AddListener(OnClickExitButton);
    }

    protected override UIState GetUIState()
    {
        return UIState.GameOver;
    }

    public void OnClickStartButton()
    {
        GameManager.Instance.RestartGame();
    }

    public void OnClickExitButton()
    {
        GameManager.Instance.ReturnLobby();
    }

    public void GameScore(int bestScore, int score)
    {
        scoreText.text = score.ToString();
        bestScoreText.text = bestScore.ToString();
    }
}
