using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class Ball : MonoBehaviour
{
  [SerializeField] private int _Speed = 5;
  private Vector2 _StartSpeed;

  public Rigidbody2D Rigidbody2D;
  public event Action OnTouchBottom;
  public event Action OnTouchUpper;

  void Start()
  {
    Restart();
  }

  private void FixedUpdate()
  {
    var currentVelocity = Rigidbody2D.velocity;
    currentVelocity = currentVelocity.normalized * _StartSpeed.magnitude;
    Rigidbody2D.velocity = currentVelocity;
  }

  private void Restart()
  {
    var x = Random.value > 0.5f ? _Speed : -_Speed;
    var y = Random.value > 0.5f ? _Speed : -_Speed;

    _StartSpeed = new Vector2(x, y);
    Rigidbody2D.velocity = _StartSpeed;
    Rigidbody2D.position = Vector3.zero;
  }

  private void OnCollisionEnter2D(Collision2D other)
  {
    if (other.gameObject.name == "Bottom")
    {
      // if (OnTouchBottom != null) OnTouchBottom();
      OnTouchBottom?.Invoke();
      Restart();
    }
    if (other.gameObject.name == "Upper")
    {
      // if (OnTouchUpper != null) OnTouchBottom();
      OnTouchUpper?.Invoke();
      Restart();
    }
  }
}
