using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class boss : MonoBehaviour
{
    public float spawnRate = 0.8f;
    private float spawnRateTime = 0;

    private float second = 0;

    public float attackRate = 5f;
    private float attackRateTime = 0;

    public float warningRate = 2f;
    private float warningRateTime = 0;
    public global global;

    public GameObject player;
    public GameObject tentacle;
    public GameObject warning;

    public bool attack = false;

    private float[] Coordinates = new float[3];
    public int hp = 100;
    public bool invincible = false;
    GameObject w;
    int x = -1;
     int p = -1;

    public GameObject minion;
    // Start is called before the first frame update
    void Start()
    {
        invincible = true;
        Coordinates[0] = -1.83f ; 
        Coordinates[1] = -0.87f;
        Coordinates[2] = 0.14f ;
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.y > -0.16f)
        {
           Vector3 vector =  new Vector3(0,-0.0005f,0);
           transform.position += vector;
        }else{
            invincible = false;
            player.GetComponent<playerMovement>().fireRate = 0.35f;
        }
        

        if(spawnRateTime < Time.time && !invincible){
            int position = Random.Range(0,3);
        Vector3 vector = new Vector3(Coordinates[position] ,0 , 1);
                GameObject a = Instantiate(minion, vector, Quaternion.identity);
                a.GetComponent<enemyMovement>().isBossMinion = true;
                a.GetComponent<enemyMovement>().global = global;
                spawnRateTime = Time.time + spawnRate;
                
        }
        
        if(second < Time.time && !invincible){
            x = Random.Range(0,5);
            second = Time.time + 1f;
        }
       
        
        if(x == 3){
            
            if(attackRateTime < Time.time && !invincible){
                p = randPos();
                w = attackMove(p);
                attackRateTime = Time.time + attackRate;
            }
        }

    
        if(attack && !invincible ){
            startAttack(w,new Vector3(Coordinates[p],4.6f,1));
        }

    }


    GameObject attackMove(int position){
        Vector3 vector = new Vector3(Coordinates[position],-3f,1);
        GameObject w = Instantiate(warning,vector,Quaternion.identity);
        warningRateTime = Time.time + warningRate;
        attack = true;
        return w;
    }

    int randPos(){
        return Random.Range(0,3);
    }

    void startAttack(GameObject w, Vector3 vector){
        if(warningRateTime < Time.time){
        attack = false;
        Destroy(w);    
        GameObject t = Instantiate(tentacle,vector,Quaternion.identity);
         t.GetComponent<tentacle>().global = global;
        attackRateTime += attackRate;}
    }
}
