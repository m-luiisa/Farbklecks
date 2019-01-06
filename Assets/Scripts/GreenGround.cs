using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GreenGround : MonoBehaviour {

  void OnTriggerEnter2D(Collider2D other)
  {
    if (other.gameObject.tag == "Player")
    {
      Debug.Log("Stell dich doch nicht so blöd an!");
      SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
    
  }
}
