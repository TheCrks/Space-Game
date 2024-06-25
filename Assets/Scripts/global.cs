using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class global : MonoBehaviour
{
    public GameObject[] hearts = new GameObject[3];

    public int nextHeart = 2;
    public Boolean bossFight;
    public GameObject boss;
    public GameObject minion;
    public GameObject player;
    public GameObject warning;
    public GameObject tentacle;

    public bool bossDead = false;

    public GameObject spawner;
    public bool leveling = false;

    public GameObject game;

    public void startBoss(){
        GameObject b = Instantiate(boss, new Vector3(-0.81f,1.53f,0f), Quaternion.identity);
        b.gameObject.GetComponent<boss>().global = this;
        b.gameObject.GetComponent<boss>().minion = minion;
        b.gameObject.GetComponent<boss>().player = player;
         b.gameObject.GetComponent<boss>().warning = warning;
          b.gameObject.GetComponent<boss>().tentacle = tentacle;
            }

    public void endBoss(){
         leveling = true;
         bossFight = false;
         bossDead = true;
         spawner.GetComponent<spawner>().level = 2;
         player.GetComponent<playerMovement>().fireRate = 0.5f;
    }        

    public void levelup(){
        if (game.transform.position.y < 7.67f)
        {
           Vector3 vector =  new Vector3(0,  0.005f,0);
           game.transform.position += vector;
        }if (game.transform.position.y < 4.63f)
        {
           Vector3 vector =  new Vector3(0.005f, 0,0);
           game.transform.position += vector;
        }if(game.transform.position.y >= 7.67f &&  game.transform.position.y >= 4.63f ){
          spawner x = spawner.GetComponent<spawner>();
          playerMovement p = player.GetComponent<playerMovement>();
            x.Coordinates[0] += 7.63f;   x.Coordinates[1] += 7.63f;   x.Coordinates[2] += 7.63f;
            p.Coordinates[0] += 7.63f;   p.Coordinates[1] += 7.63f;   p.Coordinates[2] += 7.63f;
            x.y += 11.67f;
            leveling = false;
        }
        
    }

    void Update()
    {
        if(leveling)
            levelup();
    }
}
