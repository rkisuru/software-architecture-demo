using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    [SerializeField] private Text timeText;

    [SerializeField] private float timeRemain = 20;

    [SerializeField] private GameObject pauseMenu;

    [SerializeField] private GameObject gameOverMenu;

    [SerializeField] private Text titleText;
    [SerializeField] private Text scoreTxt;
    [SerializeField] private Text economyTxt;
    [SerializeField] private Text complimentTxt;

    private bool gameOver = false;
    
    void Update()
    {
        if (timeRemain > 0)
        {
            timeRemain -= Time.deltaTime;
        }
        else
        {
            timeRemain = 0;
            gameOver = true;
        }
        int time = Mathf.FloorToInt(timeRemain % 60);
        timeText.text = time.ToString();

        State();

        GameOverActivate();

        PauseMenuActivate();

    }

    private void State()
    {
        if (Score.Instance.ReturnScore() == 100)
        {
            gameOver = true;
            gameOverMenu.SetActive(true);
            scoreTxt.text = Score.Instance.ReturnScore().ToString();
            complimentTxt.text = "You Killed Economy Perfectly!";
            economyTxt.text = Score.Instance.ReturnEconomy().ToString();
            titleText.text = "You Win!";
        }
        else if (gameOver == true && Score.Instance.ReturnScore()<90 && Score.Instance.ReturnScore() > 75)
        {
            gameOverMenu.SetActive(true);
            scoreTxt.text = Score.Instance.ReturnScore().ToString();
            complimentTxt.text = "Great! You killed Economy.";
            economyTxt.text = Score.Instance.ReturnEconomy().ToString();
            titleText.text = "You Win!";
        }
        else if (gameOver == true && Score.Instance.ReturnScore() < 75 && Score.Instance.ReturnScore() >= 50)
        {
            gameOverMenu.SetActive(true);
            scoreTxt.text = Score.Instance.ReturnScore().ToString();
            complimentTxt.text = "Good! You Killed Economy.";
            economyTxt.text = Score.Instance.ReturnEconomy().ToString();
            titleText.text = "You Win!";
        }
        else if (gameOver == true && Score.Instance.ReturnScore() < 50)
        {
            gameOverMenu.SetActive(true);
            scoreTxt.text = Score.Instance.ReturnScore().ToString();
            scoreTxt.color = Color.red;
            complimentTxt.text = "You failed to Kill Economy!";
            complimentTxt.color = Color.red;
            economyTxt.text = Score.Instance.ReturnEconomy().ToString();
            economyTxt.color = Color.red;
            titleText.text = "You Loose!";
        }

    }

    public void Pause()
    {
        pauseMenu.SetActive(true);
        Time.timeScale = 0;
    }

    public void Resume()
    {
        pauseMenu.SetActive(false);
        Time.timeScale = 1;
    }

    public void Restart()
    {
        pauseMenu.SetActive(false);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        Time.timeScale = 1;
    }

    public void QuitGame()
    {
        Application.Quit();
      
    }

    private void GameOverActivate()
    {
        if (gameOverMenu.activeSelf)
        {
            Time.timeScale = 0;
        }
        else if (!gameOverMenu.activeSelf)
        {
            Time.timeScale = 1;
        }
    }

    private void PauseMenuActivate()
    {
        if (pauseMenu.activeSelf)
        {
            Time.timeScale = 0;
        }
        else if (!pauseMenu.activeSelf && gameOverMenu.activeSelf)
        {
            Time.timeScale = 0;
        }
    }

}
