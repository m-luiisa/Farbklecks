using System.Collections;
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
    UpdateMovement();
    //Debug.Log(myTrans.position.x);
    //Debug.Log(end);
    
    if (myTrans.position.x < end || myTrans.position.x > start)
    {
      Vector3 currRot = myTrans.eulerAngles;
      currRot.y += rotation;
      myTrans.eulerAngles = currRot;
      //Debug.Log("CHANGED");
    }

    Vector2 myVel = myBody.velocity;
    myVel.x = -myTrans.right.x * speed;
    myBody.velocity = myVel;

  }

  void UpdateMovement()
  {
    end = start - length;
  }


}
