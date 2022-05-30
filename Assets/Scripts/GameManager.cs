using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
  [SerializeField] int score = 0;

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
  }
}
