using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hotspot_ingredient : MonoBehaviour
{
    public GameObject ingredient;
    private GameObject ingredientCarry;
    public Vector3 offset;
    public GameObject audio;

    void OnTriggerStay(Collider other) {
        if (other.tag == "Player" && !other.GetComponent<Objets>().isCarrying)
        {
            var pos = other.transform.position;
            if (other.GetComponent<Objets>().click) {
                ingredientCarry = Instantiate(ingredient, new Vector3(pos.x, pos.y, pos.z), Quaternion.identity);
                ingredientCarry.SetActive(true);
                other.GetComponent<Objets>().isCarrying = true;
                other.GetComponent<Objets>().ingredient = ingredientCarry;
                other.GetComponent<Objets>().offset = offset;
                other.GetComponent<Objets>().currentParent = this.gameObject;
                if (audio != null)
                {
                    audio.SendMessage("Jouer");
                }
            }
        }
    }

}
