﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
  public Rigidbody2D Rigidbody2D;
  [SerializeField] private int _JumpPower = 10;

  private Vector2 _StartSpeed;
  void Start()
  {
    _StartSpeed = new Vector2(_JumpPower, _JumpPower);
    Rigidbody2D.velocity = _StartSpeed;

  }

  // Update is called once per frame
  void Update()
  {
    if (Input.GetKeyDown(KeyCode.Space))
    {
      Debug.Log("Jump");
      Rigidbody2D.velocity = new Vector2(0, _JumpPower);
    }
  }

  private void FixedUpdate()
  {
    var currentVelocity = Rigidbody2D.velocity;
    currentVelocity = currentVelocity.normalized * _StartSpeed.magnitude;
    Rigidbody2D.velocity = currentVelocity;
  }
}
