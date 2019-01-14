using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShoot : MonoBehaviour
{
  public Transform bulletspawn;
  public Transform enemy;
  public Rigidbody2D clone;

  public Rigidbody2D bullet;

  private float time = 0.0f;
  public float interpolationPeriod;

  public float speed;

  private void Start()
  {
    bulletspawn = transform;
    enemy = GameObject.Find("Shooter").transform;
  }

  void Update()
  {
    time += Time.deltaTime; //for a period of time, do something

    if (time >= interpolationPeriod)
    {
      time = time - interpolationPeriod;
      Shoot();
    }
  }

  void Shoot()
  {
    //get the bulletspawn and initate at this point a bullet with a force
    clone = Instantiate(bullet, bulletspawn.position, bulletspawn.rotation);
    clone.AddForce(transform.right * speed);
    Debug.Log("Schuss");
  }
}
