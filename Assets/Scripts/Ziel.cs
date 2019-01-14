using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Ziel : MonoBehaviour {
  
  private void OnTriggerEnter2D(Collider2D collision)
  {
    if(collision.gameObject.tag == "Player")
    {
      if (SceneManager.GetActiveScene().name == "GreenLevel1")
        SceneManager.LoadScene("GreenLevel2");
      if (SceneManager.GetActiveScene().name == "GreenLevel2")
        SceneManager.LoadScene("GreenLevel6");
      else
      {
      SceneManager.LoadScene("MenuEnd");
      }     
    }
  }
}
