﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pathmaker : MonoBehaviour {
    //used across pathmakers
    public static int tileCount = 0;
    public int tileCountReset;

    int counter = 0;
    public Transform floorPrefab1;
    public Transform floorPrefab2;
    public Transform floorPrefab3;
    public Transform pathmakerSpherePrefab;

    int tileAllowance;
    
    void Awake()
    {
        //allows user to press R without Unity thinking tileCount is maxed out
        tileCount = tileCountReset;
    }

    void Start()
    {
        tileAllowance = Random.Range(30, 80);
    }

	void Update () {
        //pathmakers die after placing 50; max of 500 tiles
        if (counter < tileAllowance && tileCount < 500)
        {
            float rand = Random.Range(0.0f, 1.0f);
            //low chance of turning
            if (rand < 0.1f)
            {
                transform.Rotate(0f, 90f, 0f);
            } else if (rand < 0.2f)
            {
                transform.Rotate(0f, -90f, 0f);
            //somewhat rare to create another pathmaker
            } else if (rand > 0.955f)
            {
                Instantiate(pathmakerSpherePrefab, transform.position, Quaternion.identity);
            }
            //rare chance of twister
            if (rand < 0.15f)
            {
                Instantiate(floorPrefab1, transform.position, Quaternion.identity);
            } else if (rand < .7f) //highest chance of computer
            {
                Instantiate(floorPrefab2, transform.position, Quaternion.identity);
            } else // medium chance face
            {
                Instantiate(floorPrefab3, transform.position, Quaternion.identity);
            }
            transform.Translate(0f, 0f, 5f);
            counter++;
            tileCount++;
            tileCountReset = tileCount;
        }
        else {
            Destroy(this.gameObject);
        }
        Debug.Log(tileCount);

    }
}
