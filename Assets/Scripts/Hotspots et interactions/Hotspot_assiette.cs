using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hotspot_assiette : MonoBehaviour
{
    [ShowOnly] public GameObject ingredient;
    [ShowOnly] public Collider player;
    public GameObject GameManager;
    public GameObject plate;
    private bool canInteract = true;
    private int nbIngredients = 0;
    private List<GameObject> ingredients = new List<GameObject>();
    private List<Vector3> originals = new List<Vector3>();
    private GameObject ingredientClone;
    private GameObject ingredientCarry;
    public Vector3 offset;

    void Awake() {
        plate = GameObject.Find("Plate");
    }

    void OnTriggerStay(Collider other) {
        player = other;
        if (other.tag == "Player" && other.GetComponent<Objets>().click && canInteract) {
            canInteract = false;
            if (other.GetComponent<Objets>().isCarrying) {
                ingredient = other.GetComponent<Objets>().ingredient;
                ajoutIngredient(ingredient);
                other.GetComponent<Objets>().isCarrying = false;
                Destroy(ingredient);
            } else {
                enleverIngredient();
            }
        }
    }

    void OnTriggerExit(Collider other) {
        canInteract = true;
    }

    void ajoutIngredient(GameObject ingredient) {
        GameManager.SendMessage("ajoutIngredient", player.GetComponent<Objets>().ingredient.tag);
        var originalScale = new Vector3(ingredient.transform.localScale.x, ingredient.transform.localScale.y, ingredient.transform.localScale.z);
        ingredientClone = Instantiate(ingredient, new Vector3(0, 0, 0), Quaternion.identity, plate.transform);
        ingredientClone.transform.localPosition = new Vector3(0,0, 0.017f*(nbIngredients+1));
        var plateData = ingredient.GetComponent<ingredient>();
        // ingredientClone.transform.localScale = new Vector3(0.5f,0.5f,2);
        // ingredientClone.transform.localRotation = Quaternion.Euler(new Vector3(0, 0, 0));
        ingredientClone.transform.localScale = new Vector3(plateData.scaleX,plateData.scaleY,plateData.scaleZ);
        ingredientClone.transform.localRotation = Quaternion.Euler(new Vector3(plateData.rotationX,plateData.rotationY,plateData.rotationZ));
        nbIngredients ++;
        ingredients.Add(ingredientClone);
        originals.Add(originalScale);
    }

    void enleverIngredient() {
        if (nbIngredients > 0) {
            var lastElement = ingredients.Count - 1;
            var o = originals[lastElement];
            ingredientCarry = Instantiate(ingredients[lastElement], new Vector3(0, 0, 0), Quaternion.identity);
            ingredientCarry.transform.localScale = o;
            player.GetComponent<Objets>().isCarrying = true;
            player.GetComponent<Objets>().ingredient = ingredientCarry;
            player.GetComponent<Objets>().offset = offset;
            player.GetComponent<Objets>().currentParent = this.gameObject;
            Destroy(ingredients[lastElement]);
            ingredients.RemoveAt(lastElement);
            nbIngredients--;
            GameManager.SendMessage("enleverIngredient");
        }
    }
}
