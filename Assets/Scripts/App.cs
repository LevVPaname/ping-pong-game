using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class App : MonoBehaviour
{
  public GameObject GamePrefab;

  private GameObject _Game;
  private Ball _Ball;
  void Start()
  {
    Application.targetFrameRate = 60;
    RestartGame();
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
    if (_Game != null)
    {
      Destroy(_Game);
    }

    _Game = Instantiate(GamePrefab, Vector3.zero, Quaternion.identity);
    _Ball = FindObjectOfType<Ball>();

    _Ball.OnTouchBottom += RestartGame;
  }
}
