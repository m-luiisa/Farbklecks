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


  public int shootSpeed = 500;

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
    if (Player.green == 0)
    {
      Debug.Log("Keine grüne Farbe mehr :/");
    }
    else
    {
      Debug.Log("Player bullets: " + Player.green);
      clone = Instantiate(bulletGreen, bulletspawn.position, bulletspawn.rotation);
      ExecuteShoot();
      Player.green -= 1;
      PlayerPrefs.SetInt("Green", Player.green);
      Debug.Log("Player bullets: " + Player.green);
    }
  }
  void ShootRed()
  {
    if (Player.red == 0)
    {
      Debug.Log("You do not have any red color left :/");
    }
    else
    {
      Debug.Log("Player bullets: " + Player.red);
      clone = Instantiate(bulletRed, bulletspawn.position, bulletspawn.rotation);
      ExecuteShoot();
      Player.red -= 1;
      PlayerPrefs.SetInt("Red", Player.red);
      Debug.Log("Player bullets: " + Player.red);
    }
  }
  void ShootCyan()
  {
    if (Player.cyan == 0)
    {
      Debug.Log("You do not have any cyan color left :/");
    }
    else
    {
      Debug.Log("Player bullets: " + Player.cyan);
      clone = Instantiate(bulletCyan, bulletspawn.position, bulletspawn.rotation);
      ExecuteShoot();
      Player.cyan -= 1;
      PlayerPrefs.SetInt("Cyan", Player.cyan);
      Debug.Log("Player bullets: " + Player.cyan);
    }
  }
  void ShootBlue()
  {
    if (Player.blue == 0)
    {
      Debug.Log("You do not have any blue color left :/");
    }
    else
    {
      Debug.Log("Player bullets: " + Player.blue);
      clone = Instantiate(bulletBlue, bulletspawn.position, bulletspawn.rotation);
      ExecuteShoot();
      Player.blue -= 1;
      PlayerPrefs.SetInt("Blue", Player.blue);
      Debug.Log("Player bullets: " + Player.blue);
    }
  }
  void ShootMagenta()
  {
    if (Player.magenta == 0)
    {
      Debug.Log("You do not have any magenta color left :/");
    }
    else
    {
      Debug.Log("Player bullets: " + Player.magenta);
      clone = Instantiate(bulletMagenta, bulletspawn.position, bulletspawn.rotation);
      ExecuteShoot();
      Player.magenta -= 1;
      PlayerPrefs.SetInt("Magenta", Player.magenta);
      Debug.Log("Player bullets: " + Player.magenta);
    }
  }
  void ShootYellow()
  {
    if (Player.yellow == 0)
    {
      Debug.Log("You do not have any yellow color left :/");
    }
    else
    {
      Debug.Log("Player bullets: " + Player.yellow);
      clone = Instantiate(bulletYellow, bulletspawn.position, bulletspawn.rotation);
      ExecuteShoot();
      Player.yellow -= 1;
      PlayerPrefs.SetInt("Yellow", Player.yellow);
      Debug.Log("Player bullets: " + Player.yellow);
    }
  }

  void ExecuteShoot()
  {
    if (player.position.x < bulletspawn.position.x)
    {
      clone.AddForce(bulletspawn.transform.right * shootSpeed);
    }

    if (player.position.x > bulletspawn.position.x)
    {
      clone.AddForce(bulletspawn.transform.right * -shootSpeed);
    }
  }
}
