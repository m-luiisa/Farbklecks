using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MiniEnemy : MonoBehaviour {
   float time = 0.0f;
   float interpolationPeriod = 2f;
  // Use this for initialization
  void Start () {
		
	}

  // Update is called once per frame
  void Update()
  {
    time += Time.deltaTime;

    if (time >= interpolationPeriod)
    {
      time = time - interpolationPeriod;
      Destroy(gameObject);
    }
  }
}
