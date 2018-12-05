﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shoot : MonoBehaviour {

    public Transform bulletspawn;

    public Rigidbody2D bulletPrefab;
    public Rigidbody2D clone;

    public int shootSpeed = 500;

	// Use this for initialization
	void Start () {
        bulletspawn = GameObject.Find ("ShootSpawn").transform;
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetButtonDown("Fire1"))
        {
            //Shoot
            Debug.Log("PENG PENG");
            Attack();
        }
	}

    void Attack()
    {
        clone = Instantiate(bulletPrefab, bulletspawn.position, bulletspawn.rotation);
        clone.AddForce(bulletspawn.transform.right * shootSpeed);
    }
}