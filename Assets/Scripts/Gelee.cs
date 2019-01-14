using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gelee : MonoBehaviour {
  
  private void OnTriggerStay2D(Collider2D collision)
  {
    collision.GetComponent<Rigidbody2D>().gravityScale = 0;
    collision.GetComponent<Rigidbody2D>().AddForce(new Vector3(0, 1, 0) * 2); //pushes the entity up

  }
  private void OnTriggerExit2D(Collider2D collision)
  {
    collision.GetComponent<Rigidbody2D>().gravityScale = 3; //sets the gravity back to its default value
  }
}
