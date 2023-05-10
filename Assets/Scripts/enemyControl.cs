using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyControl : MonoBehaviour
{
    public GameObject assassin;
    public GameObject bard;
    public GameObject caster;
    public GameObject roomba;
    public GameObject whelping;

    GameObject spawn;
    float x;
    float z;


    void Start(){
        spawn = GameObject.Find("spawn");
        x = spawn.transform.position.x;
        z = spawn.transform.position.z;
    }

    void FixedUpdate(){
        
    }

    // spawn functions
    public void spawnAssassin(){
        GameObject thing = Instantiate(assassin, new Vector3(x, 0.56f, z), Quaternion.identity);
        thing.AddComponent<enemy>();
    }
    
    public void spawnBard(){
        GameObject thing = Instantiate(bard, new Vector3(x, 0, z), Quaternion.identity);
        thing.AddComponent<enemy>();
    }

    public void spawnCaster(){
        GameObject thing = Instantiate(caster, new Vector3(x, 0, z), Quaternion.identity);
        thing.AddComponent<enemy>();
    }

    public void spawnRoomba(){
        GameObject thing = Instantiate(roomba, new Vector3(x, 0, z), Quaternion.identity);
        thing.AddComponent<enemy>();
    }

    public void spawnWhelping(){
        GameObject thing = Instantiate(whelping, new Vector3(x, 0, z), Quaternion.identity);
        thing.AddComponent<enemy>();
    }
}