using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class GameManager : MonoBehaviour
{
  [SerializeField] int score = 0;
  [SerializeField] GameObject pauseMenu;
  [SerializeField] TextMeshProUGUI scoreText;

  public bool isPaused = false;

  public int Score
  {
    set
    {
      score = value;
      Debug.Log(Score);
    }

    get
    {
      return score;
    }
  }

  void Awake()
  {
    scoreText.text = Score.ToString();
  }

  void Update()
  {
    scoreText.text = Score.ToString();
  }

  public void PauseGame()
  {
    isPaused = true;
    Time.timeScale = 0f;
    pauseMenu.SetActive(true);
  }

  public void RestartGame()
  {
    Time.timeScale = 1f;
    isPaused = false;
    SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
  }

  public void QuitGame()
  {
    SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
  }
}
