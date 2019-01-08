using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GreenGround : MonoBehaviour {

  void OnTriggerEnter2D(Collider2D other)
  {
    if (other.gameObject.tag == "Player")
    {
      other.gameObject.GetComponent<Player>().Hurt(1);
    }

    if(other.gameObject.tag == "Enemy")
    {
      other.gameObject.GetComponent<Enemy>().Die();
    }
    
  }
}
