using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pathmaker : MonoBehaviour {

    public static int tileCount = 0;
    public int tileCountReset;

    int counter = 0;
    public Transform floorPrefab;
    public Transform pathmakerSpherePrefab;

    float speed;
    
    void Awake()
    {
        tileCount = tileCountReset;
    }

    void Start()
    {
        speed = Random.Range(3f, 7f); 
    }

	void Update () {
        
        if (counter < 50 && tileCount < 500)
        {
            float rand = Random.Range(0.0f, 1.0f);
            if (rand < 0.1f)
            {
                transform.Rotate(0f, 90f, 0f);
            } else if (rand < 0.2f)
            {
                transform.Rotate(0f, -90f, 0f);
            } else if (rand > 0.955f)
            {
                Instantiate(pathmakerSpherePrefab, transform.position, Quaternion.identity);
            }
            Instantiate(floorPrefab, transform.position, Quaternion.identity);
            transform.Translate(0f, 0f, speed);
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
