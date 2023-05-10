using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class enemy : MonoBehaviour
{
    GameObject p;
    GameObject targ;
    List<GameObject> points = new List<GameObject>();

    int point = 0;

    void Start(){
        p = GameObject.Find("points");
        foreach (Transform child in p.transform){
            GameObject ob = child.gameObject;
            points.Add(ob);
        }
    }

    //=========================================================//

    void Update(){
        targ = points[point];
        transform.LookAt(new Vector3(targ.transform.position.x, transform.position.y, targ.transform.position.z));

        transform.position += transform.forward * 0.03f;
        transform.Rotate(-90.0f, 180, 0, Space.Self);


        foreach (GameObject pt in points){
            float x = transform.position.x;
            float z = transform.position.z;
            float tx = pt.transform.position.x;
            float tz = pt.transform.position.z;
            if (x < tx + 0.5 && x > tx - 0.5 && z < tz + 0.5 && z > tz - 0.5){
                if (pt == points.LastOrDefault()){
                    Destroy(this.gameObject);
                }
                else if (pt == points[point]){
                    point++;
                }
            }

        }
    }
}
