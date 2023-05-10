using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class towerControl : MonoBehaviour
{
    // Init =======================================================================================================

    // variables
    string t = "";

    float raylen;
    float time;

    int gold = 200;

    int[] costs = {100, 100, 100, 100};


    // objects
    Camera cam;
    GameObject ba;
    GameObject spots;
    GameObject spot;
    List<GameObject> locals = new List<GameObject>();
    List<GameObject> towers = new List<GameObject>();

    public GameObject AAT;
    public GameObject HT;
    public GameObject MT;
    public GameObject PT;

    public TMP_Text bank;


    // start
    void Start(){
        cam = FindObjectOfType<Camera>();
        ba = GameObject.Find("r");
        spots = GameObject.Find("spots");

        foreach (Transform child in spots.transform){
            GameObject ob = child.gameObject;
            locals.Add(ob);
        }
    }


    // Update ======================================================================================================

    void FixedUpdate(){
        bank.text = "$ " + gold.ToString();
        Ray ray = cam.ScreenPointToRay(Input.mousePosition);
        Plane ground = new Plane(Vector3.up, Vector3.zero);
        if (ground.Raycast(ray, out raylen)){
            Vector3 point = ray.GetPoint(raylen);
            if (touch(point.x, point.z) && Input.GetKey(KeyCode.Mouse0)){
                spawn();
            }
            else if (Input.GetKey(KeyCode.Mouse0)){
                t = "";
            }
        }
        time += Time.deltaTime;
        if (time >= 1){
            time = 0;
            this.GetComponent<enemyControl>().spawnAssassin();
        }
    }


    // Additional methods ===========================================================================================

    // allows buttons to select tower type 
    public void tower (string i){
        t = i;
    }

    // checks mouse is pointing at a placeable tower location
    bool touch(float x, float z){
        foreach(GameObject sp in locals){
            if (sp.GetComponent<spot>().available()){
            float tx = sp.transform.position.x;
            float tz = sp.transform.position.z;
            if (x > tx - 0.5 && x < tx + 0.5 && z > tz - 0.5 && z < tz + 0.5){
                spot = sp;
                return true;
            }
            }
        }
        return false;
    }

    // spawns the selected tower
    void spawn(){
        if (t == "T1" && gold >= costs[0]){
            gold -= costs[0];
            Instantiate(AAT, new Vector3(spot.transform.position.x, 0, spot.transform.position.z), Quaternion.identity);
            spot.GetComponent<spot>().take();
        }
        if (t == "T2" && gold >= costs[1]){
            gold -= costs[0];
            Instantiate(HT, new Vector3(spot.transform.position.x, 0, spot.transform.position.z), Quaternion.identity);
            spot.GetComponent<spot>().take();
        }
        if (t == "T3" && gold >= costs[2]){
            gold -= costs[0];
            Instantiate(MT, new Vector3(spot.transform.position.x, 0, spot.transform.position.z), Quaternion.identity);
            spot.GetComponent<spot>().take();
        }
        if (t == "T4" && gold >= costs[3]){
            gold -= costs[0];
            Instantiate(PT, new Vector3(spot.transform.position.x, 0, spot.transform.position.z), Quaternion.identity);
            spot.GetComponent<spot>().take();
        }
    }
}