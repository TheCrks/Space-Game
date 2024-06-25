using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class enemyMovement : MonoBehaviour
{
    public global global;
    public bool isBossMinion = false;
    public float speed = 0.01f;


    void Update()
    {
        Vector3 vector = new Vector3(transform.position.x, transform.position.y - speed, transform.position.z);
        transform.position = vector;


        if(transform.position.y < -7f){
            Destroy(global.hearts[global.nextHeart]);
            global.nextHeart -= 1;
            if(global.nextHeart <= -1){
                SceneManager.LoadScene(2);
            }
            Destroy(this.gameObject);
        }


        if(global.bossFight && !isBossMinion){
            Destroy(this.gameObject);
        }
        if(isBossMinion && global.bossDead)
            Destroy(this.gameObject);


    }
}
