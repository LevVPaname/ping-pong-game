using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
  public Rigidbody2D Rigidbody2D;
  [SerializeField] private int _Speed = 5;

  private Vector2 _StartSpeed;
  void Start()
  {
    _StartSpeed = new Vector2(_Speed, _Speed);
    Rigidbody2D.velocity = _StartSpeed;

  }

  private void FixedUpdate()
  {
    var currentVelocity = Rigidbody2D.velocity;
    currentVelocity = currentVelocity.normalized * _StartSpeed.magnitude;
    Rigidbody2D.velocity = currentVelocity;
  }
}
