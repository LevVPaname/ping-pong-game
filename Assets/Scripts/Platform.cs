using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
public enum PlatformType
{
  Player, Enemy
}

public class Platform : MonoBehaviour
{
  public PlatformType PlatformType;
  public Rigidbody2D Rigidbody2D;
  [Range(0, 1)]
  public float SpeedKof = 1;

  private Ball _Ball;
  private Vector3 _TargetPosition;

  void Start()
  {
    Rigidbody2D = gameObject.GetComponent<Rigidbody2D>();
    _Ball = FindObjectOfType<Ball>();
  }

  void FixedUpdate()
  {
    var targetPosition = new Vector3();
    if (PlatformType == PlatformType.Enemy) targetPosition = _Ball.transform.position;
    else targetPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);

    _TargetPosition = Vector3.Lerp(_TargetPosition, targetPosition, SpeedKof);
    Rigidbody2D.MovePosition(_TargetPosition);
  }
}
