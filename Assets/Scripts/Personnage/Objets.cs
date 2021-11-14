using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Objets : MonoBehaviour
{
    [ShowOnly] public bool isCarrying = false;
    [ShowOnly] public GameObject ingredient;
    [ShowOnly] public GameObject currentParent;

    public GameObject main;
    public Vector3 offset;

    public bool click = false;

    void Update() {
        if (isCarrying) {
            ingredient.transform.position = main.transform.position + offset;
        }
    }

    public void clearHand() {
        Destroy(ingredient);
        isCarrying = false;
    }
}
