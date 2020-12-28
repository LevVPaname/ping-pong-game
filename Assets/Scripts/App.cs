using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class App : MonoBehaviour
{
  public GameObject GamePrefab;
  public TextMeshProUGUI ScoreText;

  private GameObject _Game;
  private Ball _Ball;
  private int _Scores;

  void Start()
  {
    Application.targetFrameRate = 60;
    RestartGame();
    UpdateScores();
  }

  private void Update()
  {
    if (Input.GetKeyDown(KeyCode.R))
    {
      RestartGame();
    }
  }

  public void RestartGame()
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
  }

  private void ChangeScores(int value)
  {
    _Scores += value;
    if (_Scores <= 0) _Scores = 0;
    UpdateScores();
  }

  private void UpdateScores()
  {
    // ScoreText = GameObject.Find("ScoresText").GetComponent<TextMeshProUGUI>();
    ScoreText.text = _Scores.ToString();
  }
}
