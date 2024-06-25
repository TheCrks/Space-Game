using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class playerMovement : MonoBehaviour
{

public float[] Coordinates = new float[3];
public GameObject ammo;

public spawner sp;

public global global;
public TMP_Text score;
public int scorei ;

public float movementCD;
private float movementCDTime = 0;
public float fireRate;
private float fireRateTime = 0;
private int i;

    // Start is called before the first frame update
    void Start()
    {

        scorei = 0;

        
        Coordinates[0] = -1.83f ; 
        Coordinates[1] = -0.87f;
        Coordinates[2] = 0.14f ;


        i=1;
    }

    // Update is called once per frame
    void Update()
    {
        Movement();
        fire();
    }

    void Movement()
    {
        if(Time.time > movementCDTime){
        if(Input.GetKeyDown(KeyCode.LeftArrow)){
            {
                if(i!=0){
                    Vector3 vector = new Vector3(Coordinates[--i],transform.position.y,transform.position.z);
                    transform.position = vector;
                    movementCDTime = Time.time + movementCD;
                }
            }
        }

        if(Input.GetKeyDown(KeyCode.RightArrow)){
            {
                if(i != 2){
                    Vector3 vector = new Vector3(Coordinates[++i],transform.position.y,transform.position.z);
                    transform.position = vector;
                    movementCDTime = Time.time + movementCD;
                }
            }
        }}
        if(Input.GetKeyDown(KeyCode.Z))
            {
                scorei+=100;
                score.text = scorei.ToString();
        }
    }

    void fire(){
        if(Time.time > fireRateTime){
            if(Input.GetKeyDown(KeyCode.Space)){
                Vector3 vector = new Vector3(transform.position.x + 0.3f , transform.position.y + 1f, transform.position.z);
                GameObject a = Instantiate(ammo, vector, Quaternion.identity);
                a.GetComponent<ammoScript>().score = score;
                a.GetComponent<ammoScript>().spawner = this;
                a.GetComponent<ammoScript>().sp = sp;
                a.GetComponent<ammoScript>().global = global;
                fireRateTime = Time.time + fireRate;
            }
        }
    }

}

