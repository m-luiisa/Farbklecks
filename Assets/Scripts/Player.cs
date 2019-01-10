using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
  // Use this for initialization
  public Text dropsRed, dropsGreen, dropsBlue, dropsCyan, dropsMagenta, dropsYellow;
  int counter = 2;

  static public bool green, red, blue, cyan, magenta, yellow = false;

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

    if (SceneManager.GetActiveScene().name == "World")
    {
      if (green == true)
        GameObject.Find("FlagGreen").GetComponent<Renderer>().material.color = Color.green;
      if (red == true)
        GameObject.Find("FlagRed").GetComponent<Renderer>().material.color = Color.red;
      if (blue == true)
        GameObject.Find("FlagBlue").GetComponent<Renderer>().material.color = Color.blue;
      if (cyan == true)
        GameObject.Find("FlagCyan").GetComponent<Renderer>().material.color = Color.cyan;
      if (magenta == true)
        GameObject.Find("FlagMagenta").GetComponent<Renderer>().material.color = Color.magenta;
      if (yellow == true)
        GameObject.Find("FlagYellow").GetComponent<Renderer>().material.color = Color.yellow;
    }
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

    if (Input.GetKeyDown(KeyCode.Escape))
    {
      if(SceneManager.GetActiveScene() == SceneManager.GetSceneByName("World"))
      {
        Debug.Log("Spiel wird beendet");
        Application.Quit();
      }
    }
  }

  //MovingPlatformStart 
  private void OnCollisionStay2D(Collision2D collision)
  {
    if (collision.gameObject.tag == "MovingPlatform")
    {
      transform.parent = collision.transform;
    }

    if (Input.GetKeyDown(KeyCode.UpArrow) || Input.GetKeyDown(KeyCode.W))
    {
      switch (collision.gameObject.tag)
      {
        case "DoorGreen":
          SceneManager.LoadScene("GreenLevel1");
          break;
        case "DoorRed":
          SceneManager.LoadScene("RedLevel6");
          break;
        case "DoorBlue":
          SceneManager.LoadScene("BlueLevel5");
          break;
        case "DoorCyan":
          SceneManager.LoadScene("Cyan1");
          break;
        case "DoorYellow":
          SceneManager.LoadScene("Yellow4");
          break;
        case "DoorMagenta":
          SceneManager.LoadScene("MagentaLevel2");
          break;
      }
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
    { //countingDrops
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

      //dye flags
      case "EndRed":
        red = true;
        break;
      case "EndBlue":
        blue = true;
        break;
      case "EndGreen":
        green = true;
        break;
      case "EndMagenta":
        magenta = true;
        break;
      case "EndCyan":
        cyan = true;
        break;
      case "EndYellow":
        yellow = true;
        break;
    }
  }


  private void OnTriggerStay2D(Collider2D collision)
  {
    //Going to Level
    if (Input.GetKeyDown(KeyCode.UpArrow)|| Input.GetKeyDown(KeyCode.UpArrow))
    {
      switch (collision.gameObject.tag)
      {
        case "DoorGreen":
          SceneManager.LoadScene("GreenLevel1");
          break;
        case "DoorRed":
          SceneManager.LoadScene("RedLevel6");
          break;
        case "DoorBlue":
          SceneManager.LoadScene("BlueLevel5");
          break;
        case "DoorCyan":
          SceneManager.LoadScene("Cyan1");
          break;
        case "DoorYellow":
          SceneManager.LoadScene("Yellow4");
          break;
        case "DoorMagenta":
          SceneManager.LoadScene("MagentaLevel2");
          break;
      }
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
    if (collision.gameObject.tag == "Enemy" || collision.gameObject.tag == "RedEnemy")
    {
      Enemy.Typ enemyTyp = collision.gameObject.GetComponent<Enemy>().typ;

      if (enemyTyp == Enemy.Typ.Green)
      {
        Hurt(3);
      }
      else
      {
        Hurt(1);
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
