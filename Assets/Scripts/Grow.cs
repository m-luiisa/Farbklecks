using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grow : MonoBehaviour {
  
  // Update is called once per frame
  private void OnCollisionEnter2D(Collision2D collision)
  {
    if(collision.gameObject.tag == "Magenta")
    {
      Destroy(collision.gameObject);
      this.transform.localScale = new Vector3(1.5f, 1.5f, 1); //increase size
      GetComponent<SpriteRenderer>().color = Color.magenta;
    }
  }

}
