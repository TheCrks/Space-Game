using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class warning : MonoBehaviour
{
    public float spawnRate = 2f;
    private float spawnRateTime;

    bool f = true;

    void Update()
    {
        if(f){
            spawnRateTime = Time.time + spawnRate;
            f = false;
        }
        if(spawnRateTime < Time.time && !f)
            Destroy(this.gameObject);
    }
}
