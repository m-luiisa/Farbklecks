using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class Enemy : MonoBehaviour
{
  void OnCollisionEnter2D(Collision2D other)
  {
    //if (other.gameObject.tag == "Player")
    //{
    //  Debug.Log("Stell dich doch nicht so blöd an!");
    //  //SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    //}

    if (other.gameObject.tag == "Green")
    {
      Debug.Log("Grün hat getroffen!");
      GetComponent<Renderer>().material.color = Color.green;
      //this.gameObject.tag = "Green";
      Destroy(other.gameObject);
      StartCoroutine(Die(2));
    }

    if(other.gameObject.tag == "Red")
    {
      Destroy(other.gameObject);
      Debug.Log("Rot hat getroffen");

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
  }

  IEnumerator Die(float seconds)
  {
    Debug.Log("DIE");
    yield return new WaitForSeconds(seconds);
    Destroy(gameObject);
  }
}
