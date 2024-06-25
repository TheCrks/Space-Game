using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawner : MonoBehaviour
{
    public global global;
    public GameObject enemy;
    public float[] Coordinates = new float[3];

    public float y = 1.05f;

    public float spawnRate;
    private float spawnRateTime = 0;

    public int level = 0;

    public playerMovement p;

    

    void Start()
    {
        

        Coordinates[0] = -1.83f ; 
        Coordinates[1] = -0.87f;
        Coordinates[2] = 0.14f ;
        
    }

    void Update()
    {
        if(!global.bossFight && !global.leveling){
        switch (level)
        {
            case 0:
            spawnRate = 2;
            break;

            case 2:
            if(spawnRate > 0.15f){
            spawnRate = 1 - 2*((p.scorei - 400f) / 1000);
            Debug.Log(spawnRate);}
            p.movementCD = 0.1f- (p.scorei - 500f)/20000;
            p.fireRate = 0.5f -  (p.scorei - 500f)/4000;
            break;
            case 1:
            spawnRate = 1;
            break;
            default:
            break;
        }
        if(spawnRateTime < Time.time && !global.bossFight && !global.leveling){
            int position = Random.Range(0,3);
             Vector3 vector = new Vector3(Coordinates[position] ,y , 1);
                GameObject a = Instantiate(enemy, vector, Quaternion.identity);
                a.GetComponent<enemyMovement>().global = global;
                spawnRateTime = Time.time + spawnRate;
        }
        }
    }
}
