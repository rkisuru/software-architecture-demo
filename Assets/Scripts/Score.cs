using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    [SerializeField] private Text scoreText;
    [SerializeField] private Text economyText;

    private int score;
    private int economy = 1000;

    public static Score Instance { get; private set; }

    private void Awake()
    {
        Instance = this;
    }

    public void AddScore()
    {
        score += 1;
        economy -= 10;

        scoreText.text = score.ToString();
        economyText.text = economy.ToString();
    }

    public int ReturnScore()
    {
        return score;
    }
    public int ReturnEconomy()
    {
        return economy;
    }
}
