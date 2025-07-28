using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameUI : BaseUI
{
    public TextMeshProUGUI scoreText;

    public override void Init(UIManager uiManager)
    {
        this.uiManager = uiManager;
    }

    protected override UIState GetUIState()
    {
        return UIState.Game;
    }

    public void UpdateScore(int score)
    {
        scoreText.text = score.ToString();
    }
}
