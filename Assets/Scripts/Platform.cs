﻿using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Platform : MonoBehaviour
{
  public Rigidbody2D Rigidbody2D;
  public TextMeshProUGUI TextMeshProUGUI;

  public int Scores = 0;
  void Start()
  {
    Rigidbody2D = gameObject.GetComponent<Rigidbody2D>();
    TextMeshProUGUI.text = Scores.ToString();
  }

  void FixedUpdate()
  {
    var worldMousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
    Rigidbody2D.MovePosition(worldMousePosition);
  }
  private void OnCollisionEnter2D(Collision2D other)
  {
    if (other.gameObject.GetComponent<Ball>() != null)
    {
      Scores++;
      TextMeshProUGUI.text = Scores.ToString();
    }
  }
}
