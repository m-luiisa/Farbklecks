using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{

  // Use this for initialization
  public static int red, green, blue, cyan, magenta, yellow;

  public Text dropsRed, dropsGreen, dropsBlue, dropsCyan, dropsMagenta, dropsYellow;

  public int counter = 3;

  void Start()
  {
    if (red !=0 || green !=0 || blue != 0 || cyan != 0 || magenta != 0 || yellow != 0)
    { //load Score:
      dropsRed.text = PlayerPrefs.GetInt("Red").ToString();
      dropsGreen.text = PlayerPrefs.GetInt("Green").ToString();
      dropsBlue.text = PlayerPrefs.GetInt("Blue").ToString();
      dropsCyan.text = PlayerPrefs.GetInt("Cyan").ToString();
      dropsMagenta.text = PlayerPrefs.GetInt("Magenta").ToString();
      dropsYellow.text = PlayerPrefs.GetInt("Yellow").ToString();
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
  }

  private void OnCollisionStay2D(Collision2D collision)
  {
    if (collision.gameObject.tag == "MovingPlatform")
    {
      transform.parent = collision.transform;
    }
  } //MovingPlatformStart


  private void OnCollisionExit2D(Collision2D collision)
  {
    if (collision.gameObject.tag == "MovingPlatform")
    {
      transform.parent = null;
    }
  } //MovingPlatformEnd

  
  private void OnTriggerEnter2D(Collider2D collision) //count Drops
  {
    switch (collision.gameObject.tag)
    {
      case "DropRed":
        red += counter;
        dropsRed.text=red.ToString();
        PlayerPrefs.SetInt("Red", red);
        Destroy(collision.gameObject);
        break;
      case "DropGreen":
        green += counter;
        dropsGreen.text = green.ToString();
        PlayerPrefs.SetInt("Green", green);
        Destroy(collision.gameObject);
        break;
      case "DropBlue":
        blue += counter;
        dropsBlue.text = blue.ToString();
        PlayerPrefs.SetInt("Blue", blue);
        Destroy(collision.gameObject);
        break;
      case "DropCyan":
        cyan += counter;
        dropsCyan.text = cyan.ToString();
        PlayerPrefs.SetInt("Cyan", cyan);
        Destroy(collision.gameObject);
        break;
      case "DropMagenta":
        magenta += counter;
        dropsMagenta.text = magenta.ToString();
        PlayerPrefs.SetInt("Magenta", magenta);
        Destroy(collision.gameObject);
        break;
      case "DropYellow":
        yellow += counter;
        dropsYellow.text = yellow.ToString();
        PlayerPrefs.SetInt("Yellow", yellow);
        Destroy(collision.gameObject);
        break;
    }

  }
}
