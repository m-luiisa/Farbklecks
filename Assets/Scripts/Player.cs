using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{

  // Use this for initialization

  public Text dropsRed, dropsGreen, dropsBlue, dropsCyan, dropsMagenta, dropsYellow;

  public int counter = 3;

  void Start()
  {
      //load Score:
      dropsRed.text = PlayerPrefs.GetInt("Red").ToString();
      dropsGreen.text = PlayerPrefs.GetInt("Green").ToString();
      dropsBlue.text = PlayerPrefs.GetInt("Blue").ToString();
      dropsCyan.text = PlayerPrefs.GetInt("Cyan").ToString();
      dropsMagenta.text = PlayerPrefs.GetInt("Magenta").ToString();
      dropsYellow.text = PlayerPrefs.GetInt("Yellow").ToString();
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
}
