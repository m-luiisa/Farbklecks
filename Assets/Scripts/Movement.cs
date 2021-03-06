﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{

  Rigidbody2D myBody;
  Transform myTrans;
  public float speed;
  public float length;
  float start;
  float end;
  public int rotation = 180;
  bool towardsPlayer;
  Transform target;
  
  // Use this for initialization
  void Start()
  {
    myTrans = this.transform;
    myBody = this.GetComponent<Rigidbody2D>();
    start = myTrans.position.x;
    end = myTrans.position.x - length;

  }

  // Update is called once per frame
  void FixedUpdate()
  {
    if(gameObject.GetComponent<Enemy>().typ == Enemy.Typ.Default || gameObject.GetComponent<Enemy>().typ == Enemy.Typ.Green) //sets the setting for normal walking of enemies
    {
      UpdateMovement();

      if (myTrans.position.x < end ^ myTrans.position.x > start) //turn around when at the end of walking
      {
        Vector3 currRot = myTrans.eulerAngles;
        currRot.y += rotation;
        myTrans.eulerAngles = currRot;
      }

      Vector2 myVel = myBody.velocity;
      myVel.x = -myTrans.right.x * speed;
      myBody.velocity = myVel;
    }
    else if(gameObject.GetComponent<Enemy>().typ == Enemy.Typ.Red) //sets the settings so enemy starts running towards player
    {
      target = GameObject.FindWithTag("Player").transform;
      Vector3 targetHeading = target.position - transform.position;
      Vector3 targetDirection = targetHeading.normalized;
      speed = 5;

      if (GameObject.FindWithTag("Player").transform.position.x < transform.position.x)
      {
        transform.eulerAngles = new Vector3(0, 0, 0);
      }
      else
      {
        transform.eulerAngles = new Vector3(0, 180, 0);
      }

      transform.position += -transform.right * speed * Time.deltaTime;
    }
    else if(gameObject.GetComponent<Enemy>().typ == Enemy.Typ.Cyan)
    {
      StartCoroutine(Sleep(4));
    }
    
  }

  //stops the motin of blue enemies
  IEnumerator Sleep(float seconds)
  {
    yield return new WaitForSeconds(seconds);
    gameObject.GetComponent<Enemy>().typ = Enemy.Typ.Default;
    GetComponent<Renderer>().material.color = Color.white;
  }

  void UpdateMovement() //Updated the movement values
  {
    end = start - length;
  }


}
