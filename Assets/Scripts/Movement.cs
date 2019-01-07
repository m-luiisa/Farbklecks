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

    Debug.Log(myTrans.position.x);
    Debug.Log(end);


    float difLeft = end - myTrans.position.x;
    float difRight = myTrans.position.x - start;

    if (myTrans.position.x < end || myTrans.position.x > start)
    {
      Vector3 currRot = myTrans.eulerAngles;
      currRot.y += 180;
      myTrans.eulerAngles = currRot;
      Debug.Log("CHANGED");

    }

    Vector2 myVel = myBody.velocity;
    myVel.x = -myTrans.right.x * speed;
    myBody.velocity = myVel;

  }
}
