using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
  [SerializeField] int score = 0;
  [SerializeField] GameObject pauseMenu;

  public bool isPaused = false;

  public int Score
  {
    set
    {
      score = value;
    }

    get
    {
      return score;
    }
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
