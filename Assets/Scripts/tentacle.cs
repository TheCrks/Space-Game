using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class tentacle : MonoBehaviour
{
    public float spawnRate = 1f;
    private float spawnRateTime = 0;
    public global global;

    bool f = false;

    bool up;

    // Start is called before the first frame update
    void Start()
    {
        up = true;
        spawnRateTime = Time.time + 20f;
    }

    // Update is called once per frame
    void Update()
    {
        if(transform.position.y > -3f && up){
            Vector3 vector = new Vector3 (0,0.05f,0);
            transform.position -= vector;
        }else{
            up = false;
            f = true;
        }

        if(f){
            spawnRateTime = Time.time + spawnRate - 20f;
            f = false;}

        if(spawnRateTime < Time.time){
            Vector3 vector = new Vector3 (0,0.05f,0);
            transform.position += vector;
        }

        if(transform.position.y >=20)
            Destroy(this.gameObject);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.tag == "Player"){
             Destroy(global.hearts[global.nextHeart]);
            global.nextHeart -= 1;
            if(global.nextHeart <= -1){
                SceneManager.LoadScene(2);}
    }
    }
}
