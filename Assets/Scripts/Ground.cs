using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityStandardAssets._2D;

public class Ground : MonoBehaviour {

  float speedEnemy;

  //TRIGGER_ENTER
  void OnTriggerEnter2D(Collider2D other)
  {
    //Green Ground Interaction
    //------------------------
    if(tag == "GreenGround" || tag == "RedGround")
    {
      if (other.gameObject.tag == "Player")
      {
        other.gameObject.GetComponent<Player>().Hurt(1);
      }

      if (other.gameObject.tag == "Enemy")
      {
        other.gameObject.GetComponent<Enemy>().Die();
      }
    }

    //Yellow Ground Interaction
    //-------------------------
    if(tag == "YellowGround")
    {
      if (other.tag == "Player")
      {
        other.GetComponent<PlatformerCharacter2D>().m_MaxSpeed = 2;
      }
      if (other.tag == "Enemy")
      {
        speedEnemy = other.GetComponent<Movement>().speed;
        other.GetComponent<Movement>().speed = 0.5f;
      }
    }
    
    if(tag == "BlueGround")
    {
      other.GetComponent<PlatformerCharacter2D>().m_JumpForce = 1000;
    }
  }

  //TRIGGER_EXIT
  private void OnTriggerExit2D(Collider2D collision)
  {
    if(tag == "YellowGround")
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

    if(tag == "BlueGround")
    {
      collision.GetComponent<PlatformerCharacter2D>().m_JumpForce = 400;
    }
  }
}
