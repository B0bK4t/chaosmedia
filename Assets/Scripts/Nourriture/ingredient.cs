using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ingredient : MonoBehaviour
{
    [Header("Pour l'assiette")]
    public float scaleX;
    public float scaleY;
    public float scaleZ;

    public float rotationX;
    public float rotationY;
    public float rotationZ;

    [ShowOnly] public GameObject personnage;
    //Steak: scale 0.5 0.5 5.055319; rotation 0 0 0
    //Laitue: scale 0.007036 0.07761271 0.007036; rotation 90 0 0
    //Pain: scale 0.68405 0.7142314 1.68583; rotation 0 0 0
    //Fromage: scale 0.5 0.5 12; rotation 0 0 0

    public RawImage sprite;

    void Awake() {
        personnage = GameObject.Find("Dona disco");
    }

    void Update() {
        if (sprite != null) {
            if (personnage.GetComponent<Objets>().isCarrying && personnage.GetComponent<Objets>().ingredient.tag == this.tag) {
                sprite.enabled = true;
            } else {
                sprite.enabled = false;
            }
        }
    }
}
