using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DiabloMoving : MonoBehaviour
{
  private Vector3 startPos;
  private Vector3 newPos;
  public float speed =1f;
  // Use this for initialization
  void Start ()
  {
    startPos = transform.position;
	}
	
	// Update is called once per frame
	void Update ()
  {
    newPos = startPos;
    newPos.x += Mathf.PingPong(Time.time * speed, 0.6F);
    transform.position = newPos;
  }
}
