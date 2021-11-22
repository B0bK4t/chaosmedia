using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hotspot_poubelle : MonoBehaviour
{
    [ShowOnly] public GameObject ingredient;
    [ShowOnly] public Collider player;
    public GameObject audio;

    void OnTriggerStay(Collider other) {
        if (other.tag == "Player" && other.GetComponent<Objets>().isCarrying) {
            if (other.GetComponent<Objets>().click) {
                other.GetComponent<Objets>().isCarrying = false;
                ingredient = other.GetComponent<Objets>().ingredient;
                Destroy(ingredient);
                if (audio != null)
                {
                    audio.SendMessage("Jouer");
                }
            }
        }
    }  
}
