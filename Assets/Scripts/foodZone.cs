using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class foodZone : MonoBehaviour
{
    public bool randomPositionOnGameStart = true;
    public float foodAmount = 500f;

    // Start is called before the first frame update
    void Start()
    {
        if(randomPositionOnGameStart) {
            transform.position = new Vector3(Random.Range(-14,14), Random.Range(-6,6), 0);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(foodAmount <= 0) {
            transform.position = new Vector3(Random.Range(-14,14), Random.Range(-6,6), 0);
            foodAmount = 500f;
        }
        
    }
}
