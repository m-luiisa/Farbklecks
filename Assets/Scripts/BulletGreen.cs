using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletGreen : MonoBehaviour {

  public Transform spawn;
  public GameObject clone;
  public GameObject greenGround;

 
  void OnCollisionEnter2D(Collision2D other)
  {
    if (other.gameObject.tag == "Green")
    {
      Destroy(other.gameObject);
      Debug.Log("Grün hat auf Boden getroffen!");
      //GetComponent<Renderer>().material.color = Color.green;
      spawn = this.transform;
      clone = Instantiate(greenGround, spawn.position, spawn.rotation);
    }

  }
}
