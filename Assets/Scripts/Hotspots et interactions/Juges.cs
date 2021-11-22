using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Juges : MonoBehaviour
{
    public GameObject GameManager;

    void OnTriggerEnter(Collider other){
        if(other.tag == "Player"){
           GameManager.SendMessage("Juger", false);
            
        }
    }
}
