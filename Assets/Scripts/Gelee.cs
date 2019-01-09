using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gelee : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

  private void OnTriggerEnter2D(Collider2D collision)
  {
    collision.GetComponent<Rigidbody2D>().mass = 0;
    collision.GetComponent<Rigidbody2D>().gravityScale = -1;
  }
  private void OnTriggerExit2D(Collider2D collision)
  {
    collision.GetComponent<Rigidbody2D>().mass = 1;
    collision.GetComponent<Rigidbody2D>().gravityScale = 3;
  }

}
