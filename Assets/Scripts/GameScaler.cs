using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameScaler : MonoBehaviour
{
  public float GameHeight { get { return Camera.main.orthographicSize * 2; } }
  public float GameWidth { get { return GameHeight * Camera.main.aspect; } }

  [SerializeField] private GameObject _LeftWall;
  [SerializeField] private GameObject _RightWall;

  void Start()
  {
    _LeftWall.transform.position = new Vector3(-GameWidth / 2, _LeftWall.transform.position.y, _LeftWall.transform.position.z);
    _RightWall.transform.position = new Vector3(GameWidth / 2, _RightWall.transform.position.y, _RightWall.transform.position.z);
  }
}
