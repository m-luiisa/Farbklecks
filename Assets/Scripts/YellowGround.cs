using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets._2D;

public class YellowGround : MonoBehaviour {
  float speedEnemy;


  private void OnTriggerEnter2D(Collider2D collision)
  {
    if(collision.tag == "Player")
    {
      collision.GetComponent<PlatformerCharacter2D>().m_MaxSpeed = 2;
    }
    if(collision.tag == "Enemy")
    {
      speedEnemy = collision.GetComponent<Movement>().speed;
      collision.GetComponent<Movement>().speed = 0.5f;
    }
  }

  private void OnTriggerExit2D(Collider2D collision)
  {
    if (collision.tag == "Player")
    {
      Debug.Log("Speed wieder normal");
      collision.GetComponent<PlatformerCharacter2D>().m_MaxSpeed = 10;
    }
    if (collision.tag == "Enemy")
    {
      collision.GetComponent<Movement>().speed = speedEnemy;
    }
  }
}
