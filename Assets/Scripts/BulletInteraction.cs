using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletInteraction : MonoBehaviour {

  public Transform spawn;
  public GameObject clone;
  public GameObject greenGround;
  public GameObject redGround;
  public GameObject blueGround;
  public GameObject cyanGround;
  public GameObject magentaGround;
 
  void OnCollisionEnter2D(Collision2D other)
  {
    if (other.gameObject.tag == "Green")
    {
      Destroy(other.gameObject);
      Debug.Log("Grün hat auf Boden getroffen!");
      //GetComponent<Renderer>().material.color = Color.green;
      spawn = this.transform;
      clone = Instantiate(greenGround, spawn.position + new Vector3(0,0.25f,0), spawn.rotation);
    }

    if (other.gameObject.tag == "Red")
    {
      Destroy(other.gameObject);
      Debug.Log("Red hat auf Boden getroffen!");
      //GetComponent<Renderer>().material.color = Color.green;
      spawn = this.transform;
      clone = Instantiate(redGround, spawn.position, spawn.rotation);
    }

  }
}
