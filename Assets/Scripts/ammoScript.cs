using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ammoScript : MonoBehaviour
{

    public float speed = 10;

    

    public playerMovement spawner;
    public spawner sp;
    public TMP_Text score;
    public global global;
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 vector = new Vector3(transform.position.x, transform.position.y + speed, transform.position.z);
        transform.position = vector;


        if(transform.position.y > 20){
            Destroy(this.gameObject);
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.tag == "Enemy"){
            Destroy(other.gameObject);
            spawner.scorei += 10;
            score.text = spawner.scorei.ToString();
            if(spawner.scorei >= 100){
                sp.level = 1;
            }
            if(spawner.scorei == 410){
                global.bossFight = true;
                global.startBoss();
            }
            Destroy(this.gameObject);
        }
        if(other.gameObject.tag == "boss"){

            if(other.gameObject.GetComponent<boss>().invincible == false){
            other.gameObject.GetComponent<boss>().hp -= 10;

            if( other.gameObject.GetComponent<boss>().hp <= 0){
                global.endBoss();
                Destroy(other.gameObject);
                }

            }
            Destroy(this.gameObject);

        }
    }
}
