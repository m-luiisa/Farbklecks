using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class Enemy : MonoBehaviour
{
  public enum Typ {Default, Green, Red, Yellow, Magenta, Cyan, Blue};
  public Typ typ;

  private void Start()
  {
    typ = Typ.Default;
  }

  void OnCollisionEnter2D(Collision2D other)
  {
    if (other.gameObject.tag == "Green")
    {
      Debug.Log("Grün hat getroffen!");
      GetComponent<Renderer>().material.color = Color.green;
      typ = Typ.Green;
      Destroy(other.gameObject);
    }

    if(other.gameObject.tag == "Red")
    {
      typ = Typ.Red;
      Destroy(other.gameObject);
      Debug.Log("Rot hat getroffen");
      gameObject.layer = 0;

      if(GameObject.FindWithTag("Player").transform.position.x < transform.position.x && transform.eulerAngles.y == 180)
      {
        Vector3 currRot = transform.eulerAngles;
        currRot.y += 180;
        transform.eulerAngles = currRot;
      }

      if (GameObject.FindWithTag("Player").transform.position.x > transform.position.x && transform.eulerAngles.y != 180)
      {
        Debug.Log("Turn around");
        Vector3 currRot = transform.eulerAngles;
        currRot.y += 180;
        transform.eulerAngles = currRot;
      }
      
      GetComponent<Movement>().rotation = 0;
      tag = "RedEnemy";
      GetComponent<Renderer>().material.color = Color.red;
    }

    if (other.gameObject.tag == "Magenta")
    {
      Debug.Log("Magenta hat getroffen!");
      Destroy(other.gameObject);
      transform.localScale = new Vector3(1.5f, 1.5f, 1);
    }

    if (other.gameObject.tag == "Cyan")
    {
      Debug.Log("Cyan hat getroffen!");
      Destroy(other.gameObject);
      GetComponent<Renderer>().material.color = Color.cyan;
      typ = Typ.Cyan;
    }

    if (other.gameObject.tag == "RedEnemy")
    {
      Destroy(gameObject);
    }

  }

  public void Die()
  {
    Destroy(this.gameObject);
  }
  
}
