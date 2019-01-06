using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shoot : MonoBehaviour
{

  public Transform bulletspawn;
  public Transform player;

  public Rigidbody2D bulletGreen;
  public Rigidbody2D bulletRed;
  public Rigidbody2D bulletBlue;
  public Rigidbody2D bulletCyan;
  public Rigidbody2D bulletMagenta;
  public Rigidbody2D bulletYellow;

  public Rigidbody2D clone;

  public int ActualColor = 0; //Red = 0 | Green = 1 | blue = 2 | Cyan = 3 | Magenta = 4 | Yellow = 5
  public string[] colorList = { "Red", "Green", "Blue", "Cyan", "Magenta", "Yellow" };

  public int indicator = 0;

  public int shootSpeed = 100;

  // Use this for initialization
  void Start()
  {
    bulletspawn = GameObject.Find("ShootSpawn").transform;
    player = GameObject.Find("CharacterRobotBoy").transform;
  }

  // Update is called once per frame
  void Update()
  {
    if (Input.GetKeyDown(KeyCode.Tab))
    {
      ActualColor = (ActualColor + 1) % 6;
      Debug.Log("Color changed to " + colorList[ActualColor]);
      indicator++;

      if (indicator != 6)
      {
        GameObject.Find("Arrow").transform.Translate(new Vector3(55, 0, 0));
        Debug.Log("Wurde verschoben");
      }
      else
      {
        indicator = 0;
        GameObject.Find("Arrow").transform.Translate(new Vector3(-275, 0, 0));
        Debug.Log("Wurde verschoben");
      }
    }

    if (Input.GetButtonDown("Fire1"))
    {
      switch (ActualColor)
      {
        case 0:
          ShootRed();
          break;
        case 1:
          ShootGreen();
          break;
        case 2:
          ShootBlue();
          break;
        case 3:
          ShootCyan();
          break;
        case 4:
          ShootMagenta();
          break;
        case 5:
          ShootYellow();
          break;
      }
    }
  }
  
  void ShootGreen()
  {
    if (PlayerPrefs.GetInt("Green") == 0)
    {
      Debug.Log("Keine grüne Farbe mehr :/");
    }
    else
    {
      Debug.Log("Player bullets: " + PlayerPrefs.GetInt("Green"));
      clone = Instantiate(bulletGreen, bulletspawn.position, bulletspawn.rotation);
      ExecuteShoot();
      PlayerPrefs.SetInt("Green", PlayerPrefs.GetInt("Green")-1);
      Debug.Log("Player bullets: " + PlayerPrefs.GetInt("Green"));
    }
  }

  void ShootRed()
  {
    if (PlayerPrefs.GetInt("Red") == 0)
    {
      Debug.Log("Keine rote Farbe mehr :/");
    }
    else
    {
      Debug.Log("Player bullets: " + PlayerPrefs.GetInt("Red"));
      clone = Instantiate(bulletRed, bulletspawn.position, bulletspawn.rotation);
      ExecuteShoot();
      PlayerPrefs.SetInt("Red", PlayerPrefs.GetInt("Red") - 1);
      Debug.Log("Player bullets: " + PlayerPrefs.GetInt("Red"));
    }
  }
  void ShootCyan()
  {
    if (PlayerPrefs.GetInt("Cyan") == 0)
    {
      Debug.Log("You do not have any cyan color left :/");
    }
    else
    {
      Debug.Log("Player bullets: " + PlayerPrefs.GetInt("Cyan"));
      clone = Instantiate(bulletCyan, bulletspawn.position, bulletspawn.rotation);
      ExecuteShoot();
      PlayerPrefs.SetInt("Cyan", PlayerPrefs.GetInt("Cyan") - 1);
      Debug.Log("Player bullets: " + PlayerPrefs.GetInt("Cyan"));
    }
  }
  void ShootBlue()
  {
    if (PlayerPrefs.GetInt("Blue") == 0)
    {
      Debug.Log("You do not have any Blue color left :/");
    }
    else
    {
      Debug.Log("Player bullets: " + PlayerPrefs.GetInt("Blue"));
      clone = Instantiate(bulletBlue, bulletspawn.position, bulletspawn.rotation);
      ExecuteShoot();
      PlayerPrefs.SetInt("Blue", PlayerPrefs.GetInt("Blue") - 1);
      Debug.Log("Player bullets: " + PlayerPrefs.GetInt("Blue"));
    }
  }
  void ShootMagenta()
  {
    if (PlayerPrefs.GetInt("Magenta") == 0)
    {
      Debug.Log("You do not have any Magenta color left :/");
    }
    else
    {
      Debug.Log("Player bullets: " + PlayerPrefs.GetInt("Magenta"));
      clone = Instantiate(bulletMagenta, bulletspawn.position, bulletspawn.rotation);
      ExecuteShoot();
      PlayerPrefs.SetInt("Magenta", PlayerPrefs.GetInt("Magenta") - 1);
      Debug.Log("Player bullets: " + PlayerPrefs.GetInt("Magenta"));
    }
  }
  void ShootYellow()
  {
    if (PlayerPrefs.GetInt("Yellow") == 0)
    {
      Debug.Log("You do not have any Yellow color left :/");
    }
    else
    {
      Debug.Log("Player bullets: " + PlayerPrefs.GetInt("Yellow"));
      clone = Instantiate(bulletYellow, bulletspawn.position, bulletspawn.rotation);
      ExecuteShoot();
      PlayerPrefs.SetInt("Yellow", PlayerPrefs.GetInt("Yellow") - 1);
      Debug.Log("Player bullets: " + PlayerPrefs.GetInt("Yellow"));
    }
  }

  void ExecuteShoot()
  {
    var mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
    Vector3 direction = mousePosition - bulletspawn.transform.position;
    var length = Mathf.Sqrt(direction.x * direction.x + direction.y * direction.y + direction.z * direction.z);
    direction /= length;
    clone.AddForce(direction * shootSpeed);
    
  }
}
