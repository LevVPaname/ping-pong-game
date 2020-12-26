using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
  public Rigidbody2D Rigidbody2D;
  [SerializeField] private int _Speed = 5;

  private Vector2 _StartSpeed;

  public event Action OnTouchBottom;

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

  private void OnCollisionEnter2D(Collision2D other)
  {
    if (other.gameObject.name == "Bottom")
    {
      // if (OnTouchBottom != null) OnTouchBottom();
      OnTouchBottom?.Invoke();
    }
  }
}
