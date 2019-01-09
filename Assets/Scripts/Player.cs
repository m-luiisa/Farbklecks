using System.Collections;
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
  public float invincible = 0.8f;

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
    Physics2D.IgnoreLayerCollision(0, 10, false);
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
        PlayerPrefs.SetInt("Red", PlayerPrefs.GetInt("Red") + counter);       //Testzwecke
        PlayerPrefs.SetInt("Yellow", PlayerPrefs.GetInt("Yellow") + counter); //Testzwecke
        PlayerPrefs.SetInt("Cyan", PlayerPrefs.GetInt("Cyan") + counter);     //Testzwecke
        PlayerPrefs.SetInt("Blue", PlayerPrefs.GetInt("Blue") + counter);     //Testzwecke
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

  public void Hurt(int dmg)
  {
    health -= dmg;

    Debug.Log(health);

    if (health <= 0)
    {
      SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
    else
    {
      StartCoroutine(HurtBlinker(invincible));
    }
  }


  private void OnCollisionEnter2D(Collision2D collision)
  {
    if (collision.gameObject.tag == "Enemy")
    {
      Enemy.Typ enemyTyp = collision.gameObject.GetComponent<Enemy>().typ;

      if (enemyTyp == Enemy.Typ.Default || enemyTyp == Enemy.Typ.Red)
      {
        Hurt(1);
      }

      if (collision.gameObject.GetComponent<Enemy>().typ == Enemy.Typ.Green)
      {
        Hurt(3);
      }
    }

  }


  IEnumerator HurtBlinker(float hurtTime)
  {
    Physics2D.IgnoreLayerCollision(0, 8);
    Physics2D.IgnoreLayerCollision(0, 10);
    this.GetComponent<Animator>().SetLayerWeight(1, 1);
    yield return new WaitForSeconds(hurtTime);
    this.GetComponent<Animator>().SetLayerWeight(1, 0);
    Physics2D.IgnoreLayerCollision(0, 8, false);
    Physics2D.IgnoreLayerCollision(0, 10, false);
  }
}
