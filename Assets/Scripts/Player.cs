using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour {

  // Use this for initialization
  public int green=0;
  public Text counterGreen;
	void Start ()
  {
	}
	
	// Update is called once per frame
	void Update ()
  {
		
	}

  private void OnCollisionStay2D(Collision2D collision)
  {
    if (collision.gameObject.tag == "MovingPlatform")
    {
      transform.parent = collision.transform;
    }
  }

  private void OnCollisionExit2D(Collision2D collision)
  {
    if (collision.gameObject.tag == "MovingPlatform")
    {
      transform.parent = null;
    }
  }

  private void OnTriggerEnter2D(Collider2D collision)
  {
    if (collision.gameObject.tag == "DropGreen")
    {
      green += 3;
      Destroy(collision.gameObject);
      counterGreen.text = green.ToString();
    }
  }
}
