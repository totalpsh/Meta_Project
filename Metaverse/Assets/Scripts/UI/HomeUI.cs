using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class HomeUI : BaseUI
{
    public Button startButton;
    public Button exitButton;
    public TextMeshProUGUI bestScoreText;

    public override void Init(UIManager uiManager)
    {
        base.Init(uiManager);

        startButton.onClick.AddListener(OnClickStartButton);
        exitButton.onClick.AddListener(OnClickExitButton);
        SetBestScore();
    }

    protected override UIState GetUIState()
    {
        return UIState.Home;
    }

    public void OnClickStartButton()
    {
        GameManager.Instance.StartGame();

    }

    public void OnClickExitButton()
    {
        GameManager.Instance.ReturnLobby();
        Time.timeScale = 1.0f;
    }

    public void SetBestScore()
    {
        bestScoreText.text = GameManager.bestScore.ToString();
    }
}
