﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformMoving : MonoBehaviour {

  private Vector3 startPos;
  private Vector3 newPos;
  public float speed = 1.5f;
  public float max = 3.0f;

	// Use this for initialization
	void Start ()
  {
    startPos = transform.position;
	}
	
	// Update is called once per frame
	void Update ()
  {
    newPos = startPos;
    newPos.x = newPos.x + Mathf.PingPong(Time.time * speed, max);
    transform.position = newPos;
	}
}
