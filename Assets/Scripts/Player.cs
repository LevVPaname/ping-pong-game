using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
  public Rigidbody2D Rigidbody2D;
  [SerializeField] private int m_JumpPower = 10;
  void Start()
  {
    //   Rigidbody2D.gravityScale = -1;

  }

  // Update is called once per frame
  void Update()
  {
    if (Input.GetKeyDown(KeyCode.Space))
    {
      Debug.Log("Jump");
      Rigidbody2D.velocity = new Vector2(0, m_JumpPower);
    }
  }
}
