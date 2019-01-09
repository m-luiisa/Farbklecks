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
  public GameObject yellowGround;

  bool alreadyUsed = false;
 
  void OnCollisionEnter2D(Collision2D other)
  {
    if (!alreadyUsed)
    {
      if (other.gameObject.tag == "Green")
      {
        Destroy(other.gameObject);
        Debug.Log("Green hat auf Boden getroffen!");
        spawn = this.transform;
        clone = Instantiate(greenGround, spawn.position + new Vector3(0, 0.25f, 0), spawn.rotation);
        alreadyUsed = true;
      }

      if (other.gameObject.tag == "Red")
      {
        Destroy(other.gameObject);
        Debug.Log("Red hat auf Boden getroffen!");
        spawn = this.transform;
        clone = Instantiate(redGround, spawn.position + new Vector3(0, 0.25f, 0), spawn.rotation);
        alreadyUsed = true;
      }

      if (other.gameObject.tag == "Yellow")
      {
        Destroy(other.gameObject);
        Debug.Log("Yellow hat auf Boden getroffen!");
        spawn = this.transform;
        clone = Instantiate(yellowGround, spawn.position + new Vector3(0, 0.25f, 0), spawn.rotation);
        alreadyUsed = true;
      }

      if (other.gameObject.tag == "Cyan")
      {
        Destroy(other.gameObject);
        Debug.Log("Cyan hat auf Boden getroffen!");
        spawn = this.transform;
        clone = Instantiate(cyanGround, spawn.position + new Vector3(0, 0.25f, 0), spawn.rotation);
        GetComponent<SpriteRenderer>().color = Color.cyan;
        Destroy(gameObject.GetComponent<BoxCollider2D>());
      }

      if (other.gameObject.tag == "Blue")
      {
        Destroy(other.gameObject);
        Debug.Log("Blue hat auf Boden getroffen!");
        spawn = this.transform;
        clone = Instantiate(blueGround, spawn.position + new Vector3(0, 0.25f, 0), spawn.rotation);
      }
    }
  }
}
