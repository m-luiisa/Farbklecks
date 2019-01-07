﻿using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Player : MonoBehaviour
{

  // Use this for initialization

  public Text dropsRed, dropsGreen, dropsBlue, dropsCyan, dropsMagenta, dropsYellow;
  public int counter = 3;

  //Health
  public int health;
  public float invincible = 2;

  void Start()
  {
    //load Score:
    dropsRed.text = PlayerPrefs.GetInt("Red").ToString();
    dropsGreen.text = PlayerPrefs.GetInt("Green").ToString();
    dropsBlue.text = PlayerPrefs.GetInt("Blue").ToString();
    dropsCyan.text = PlayerPrefs.GetInt("Cyan").ToString();
    dropsMagenta.text = PlayerPrefs.GetInt("Magenta").ToString();
    dropsYellow.text = PlayerPrefs.GetInt("Yellow").ToString();
    health = 3;
    Physics2D.IgnoreLayerCollision(0, 8, false);
  }

  // Update is called once per frame
  void Update()
  {
    dropsRed.text = PlayerPrefs.GetInt("Red").ToString();
    dropsGreen.text = PlayerPrefs.GetInt("Green").ToString();
    dropsBlue.text = PlayerPrefs.GetInt("Blue").ToString();
    dropsCyan.text = PlayerPrefs.GetInt("Cyan").ToString();
    dropsMagenta.text = PlayerPrefs.GetInt("Magenta").ToString();
    dropsYellow.text = PlayerPrefs.GetInt("Yellow").ToString();
  }

  //MovingPlatformStart 
  private void OnCollisionStay2D(Collision2D collision)
  {
    if (collision.gameObject.tag == "MovingPlatform")
    {
      transform.parent = collision.transform;
    }
  }

  //MovingPlatformEnd
  private void OnCollisionExit2D(Collision2D collision)
  {
    if (collision.gameObject.tag == "MovingPlatform")
    {
      transform.parent = null;
    }
  }

  //count Drops
  private void OnTriggerEnter2D(Collider2D collision)
  {
    switch (collision.gameObject.tag)
    {
      case "DropRed":
        PlayerPrefs.SetInt("Red", PlayerPrefs.GetInt("Red") + counter);
        Destroy(collision.gameObject);
        break;
      case "DropGreen":
        PlayerPrefs.SetInt("Green", PlayerPrefs.GetInt("Green") + counter);
        Destroy(collision.gameObject);
        break;
      case "DropBlue":
        PlayerPrefs.SetInt("Blue", PlayerPrefs.GetInt("Blue") + counter);
        Destroy(collision.gameObject);
        break;
      case "DropCyan":
        PlayerPrefs.SetInt("Cyan", PlayerPrefs.GetInt("Cyan") + counter);
        Destroy(collision.gameObject);
        break;
      case "DropMagenta":
        PlayerPrefs.SetInt("Magenta", PlayerPrefs.GetInt("Magenta") + counter);
        Destroy(collision.gameObject);
        break;
      case "DropYellow":
        PlayerPrefs.SetInt("Yellow", PlayerPrefs.GetInt("Yellow") + counter);
        Destroy(collision.gameObject);
        break;
    }

  }

  void Hurt(Collision2D other)
  {
    Debug.Log(health);
    health--;

    if (health <= 0)
    {
      SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
    else
    {
      StartCoroutine(HurtBlinker(invincible, other));
    }
  }

  private void OnCollisionEnter2D(Collision2D collision)
  {
    if (collision.gameObject.tag == "Green" || collision.gameObject.tag == "Enemy")
    {
      Hurt(collision);
      Debug.Log("Getroffen");
    }
  }

  IEnumerator HurtBlinker(float hurtTime, Collision2D other)
  {
    Physics2D.IgnoreLayerCollision(0, 8);
    this.GetComponent<Animator>().SetLayerWeight(1, 1);
    yield return new WaitForSeconds(hurtTime);
    this.GetComponent<Animator>().SetLayerWeight(1, 0);
    Physics2D.IgnoreLayerCollision(0, 8, false);
  }
}
