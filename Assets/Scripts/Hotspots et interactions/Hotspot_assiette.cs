using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine;

public class Hotspot_assiette : MonoBehaviour
{
    [ShowOnly] public GameObject ingredient;
    [ShowOnly] public Collider player;
    public GameObject GameManager;
    public GameObject plate;
    [ShowOnly] public int nbIngredients = 0;
    private List<GameObject> ingredients = new List<GameObject>();
    private List<Vector3> originals = new List<Vector3>();
    private GameObject ingredientClone;
    private GameObject ingredientCarry;
    private GameObject carryPlate;
    public Vector3 offset;
    [ShowOnly] public bool canAdd = true;
    public GameObject audio;
    public Animator anim;

    void Awake() {
        plate = GameObject.Find("Plate");
    }

    void OnTriggerStay(Collider other) {
        
        player = other;
        // if (other.tag == "Player" && other.GetComponent<Objets>().click) {
        if (other.tag == "Player") {
            var man = GameManager.GetComponent<GameManager>();
            if (other.GetComponent<Objets>().isCarrying && canAdd) {
                other.GetComponent<Mouvement>().plateCommand = "add";
                other.GetComponent<Mouvement>().estDansZoneAssiette = true;
            } 
            else {
                other.GetComponent<Mouvement>().plateCommand = "remove";
                other.GetComponent<Mouvement>().estDansZoneAssiette = true;
            }
        }
    }

    void OnTriggerExit() {
        player.GetComponent<Mouvement>().estDansZoneAssiette = false;
    }

    public void ajouterDansAssiette() {
        if (anim != null) {
            anim.SetTrigger("lever");
        }
        ingredient = player.GetComponent<Objets>().ingredient;
        GameManager.SendMessage("ajoutIngredient", player.GetComponent<Objets>().ingredient.tag);
        ajoutIngredient(ingredient);
        player.GetComponent<Objets>().isCarrying = false;
        player.GetComponent<Objets>().SendMessage("clear");
        Destroy(ingredient);
    }

    void ajoutIngredient(GameObject ingredient) {
        var originalScale = new Vector3(ingredient.transform.localScale.x, ingredient.transform.localScale.y, ingredient.transform.localScale.z);
        ingredientClone = Instantiate(ingredient, new Vector3(0, 0, 0), Quaternion.identity, plate.transform);
        ingredientClone.transform.localPosition = new Vector3(0,0, 0.017f*(nbIngredients+1));
        var plateData = ingredient.GetComponent<ingredient>();
        ingredientClone.transform.localScale = new Vector3(plateData.scaleX,plateData.scaleY,plateData.scaleZ);
        ingredientClone.transform.localRotation = Quaternion.Euler(new Vector3(plateData.rotationX,plateData.rotationY,plateData.rotationZ));
        ingredientClone.SetActive(false);
        nbIngredients ++;
        ingredients.Add(ingredientClone);
        originals.Add(originalScale);
        if (audio != null)
        {
            audio.SendMessage("Jouer");
        }
    }

    void enleverIngredient() {
        if (anim != null) {
            anim.SetTrigger("lever");
        }
        var man = GameManager.GetComponent<GameManager>();
        if (man.repasEstTermine && canAdd) {
            GameManager.SendMessage("clearCloche");
            if (man.objectRepasChoisi != null) {
                carryPlate = Instantiate(man.objectRepasChoisi, new Vector3(0,0,0), Quaternion.identity);
            } else {
                carryPlate = Instantiate(plate, new Vector3(0,0,0), Quaternion.identity);
            }
            carryPlate.transform.localRotation = Quaternion.Euler(new Vector3(-45,-90,-45));
            carryPlate.SetActive(false);
            player.GetComponent<Objets>().isCarrying = true;
            player.GetComponent<Objets>().ingredient = carryPlate;
            player.GetComponent<Objets>().SendMessage("checkCarry");
            player.GetComponent<Objets>().offset = offset;
            player.GetComponent<Objets>().currentParent = this.gameObject;
            canAdd = false;
            if (audio != null)
            {
                audio.SendMessage("Jouer");
            }
            for (int i = 0; i < ingredients.Count; i++)
            {
                Destroy(ingredients[i]);
            }
            ingredients.Clear();
            nbIngredients = 0;
        } else if (nbIngredients > 0 && canAdd) { 
            var lastElement = ingredients.Count - 1;
            var o = originals[lastElement];
            ingredientCarry = Instantiate(ingredients[lastElement], new Vector3(0, 0, 0), Quaternion.identity);
            ingredientCarry.transform.localScale = o;
            ingredientCarry.SetActive(false);
            player.GetComponent<Objets>().isCarrying = true;
            player.GetComponent<Objets>().ingredient = ingredientCarry;
            player.GetComponent<Objets>().SendMessage("checkCarry");
            player.GetComponent<Objets>().offset = offset;
            player.GetComponent<Objets>().currentParent = this.gameObject;
            Destroy(ingredients[lastElement]);
            ingredients.RemoveAt(lastElement);
            nbIngredients--;
            GameManager.SendMessage("enleverIngredient", player.GetComponent<Objets>().ingredient.tag);
            if (audio != null)
            {
                audio.SendMessage("Jouer");
            }
        }
    }

    public void clearAssiette() {
        if (nbIngredients > 0) {
            for (int i = 0; i < ingredients.Count; i++)
            {
                Destroy(ingredients[i]);
            }
                ingredients.Clear();
            }
        
        canAdd = true;
        nbIngredients = 0;
    }
}