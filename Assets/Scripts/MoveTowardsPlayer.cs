using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveTowardsPlayer : MonoBehaviour {

  Transform target;
  Transform enemyTransform;
  public float speed = 3f;
  public float rotationSpeed = 3f;
  
  void Start()
  {
    //obtain the game object Transform
    enemyTransform = this.GetComponent<Transform>();
  }

  void Update()
  {

    target = GameObject.FindWithTag("Player").transform;
    Vector3 targetHeading = target.position - transform.position;
    Vector3 targetDirection = targetHeading.normalized;
    
    if (GameObject.FindWithTag("Player").transform.position.x < enemyTransform.position.x)
    {
      enemyTransform.eulerAngles = new Vector3(0, 0, 0);
    }
    else
    {
      enemyTransform.eulerAngles = new Vector3(0, 180, 0);
    }
    
    //move towards the player
    //enemyTransform.position += enemyTransform.forward * speed * Time.deltaTime;

    transform.position += -transform.right * speed * Time.deltaTime;

  }
}
