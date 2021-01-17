using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class App : MonoBehaviour
{
  public enum ScreenName
  {
    Menu,
    Game,
    Lose,
    Win
  }

  [Serializable]
  public class UIScreen
  {
    public ScreenName Name;
    public GameObject Screen;

  }

  public GameObject GamePrefab;
  public TextMeshProUGUI[] ScoreTexts;
  public TextMeshProUGUI TotalScoresText;


  [Space]
  public int ScoresToWin = 10;
  public UIScreen[] Screens;

  private GameObject _Game;
  private Ball _Ball;
  private int _Scores;

  public int TotalScores
  {
    get
    {
      return PlayerPrefs.GetInt("TotalScores", 0);
    }
    private set
    {
      PlayerPrefs.SetInt("TotalScores", value);
    }
  }

  private void Start()
  {
    Application.targetFrameRate = 60;
    // StartGame();
    // UpdateScores();
    SwithUI(ScreenName.Menu);
  }

  private void Update()
  {
    if (Input.GetKeyDown(KeyCode.R))
    {
      StartGame();
    }
  }

  public void StartGame()
  {
    _Scores = 0;
    UpdateScores();
    if (_Game != null)
    {
      Destroy(_Game);
    }

    _Game = Instantiate(GamePrefab, Vector3.zero, Quaternion.identity);
    _Ball = FindObjectOfType<Ball>();


    _Ball.OnTouchUpper += () => ChangeScores(1);
    _Ball.OnTouchBottom += () => ChangeScores(-1);

    SwithUI(ScreenName.Game);
    AudioManager.Instance.PlaySoundByName("Click");
  }

  public void GoToMenu()
  {
    if (_Game != null) Destroy(_Game);
    SwithUI(ScreenName.Menu);
    AudioManager.Instance.PlaySoundByName("Click");
    TotalScoresText.text = "total scores : " + TotalScores.ToString();
  }

  public void GameLose()
  {
    if (_Game != null) Destroy(_Game);
    SwithUI(ScreenName.Lose);
    AudioManager.Instance.PlaySoundByName("Click");
  }

  public void GameWin()
  {
    if (_Game != null) Destroy(_Game);
    SwithUI(ScreenName.Win);
    AudioManager.Instance.PlaySoundByName("Click");

  }

  #region Private

  private void SwithUI(ScreenName screenName)
  {
    for (int i = 0; i < Screens.Length; i++)
    {
      var item = Screens[i];

      item.Screen.SetActive(item.Name == screenName);
    }
  }

  private void ChangeScores(int value)
  {
    if (value > 0)
    {
      TotalScores += value;
    }
    _Scores += value;
    if (_Scores <= 0)
    {
      _Scores = 0;
      GameLose();
    }
    if (_Scores >= ScoresToWin)
    {
      GameWin();
    }
    UpdateScores();
  }

  private void UpdateScores()
  {
    foreach (var item in ScoreTexts)
    {
      item.text = _Scores.ToString();
    }
  }

  #endregion
}
