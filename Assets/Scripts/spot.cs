using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spot : MonoBehaviour
{
    bool taken = false;


    public bool available(){
        if (taken){
            return false;
        }
        else{
            return true;
        }
    }

    public void take(){
        taken = true;
    }
}
