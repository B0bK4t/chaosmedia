using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
public class Hotspot_station : MonoBehaviour
{
    [ShowOnly] public GameObject ingredient;
    [ShowOnly] public Collider player;

    public string ingredientNeeded;
    public GameObject ingredientOutput;
    private GameObject ingredientCarry;
    public Vector3 offset;

    private bool partie1viande;

    private float boutonJeuxGauche;

    private bool partie2viande; 

    private float boutonJeuxGaucheOui;

    private float nombreDefoisButtonGauche;

    private bool waitForOutput = false;
    public bool miniJeuReussi = true; //Résultat du mini-jeu, false par défaut mais true pour tester
        
    void OnTriggerStay(Collider other) {
        if (other.tag == "Player" && other.GetComponent<Objets>().isCarrying) {
            player = other;
            ingredient = other.GetComponent<Objets>().ingredient;
            
            if (ingredient.tag == ingredientNeeded) {
                if (other.GetComponent<Objets>().click) {
                    other.GetComponent<Objets>().isCarrying = false;
                    Destroy(ingredient);
                    MiniJeux();
                    output();
                }
            }
        }
    }  

    void output() {
        waitForOutput = true;
    }

    void Update() {
        check();
        Debug.Log(nombreDefoisButtonGauche);
        boutonJeuxGauche = player.GetComponent<Mouvement>().playerInput.actions["interactionJeuxGauche"].ReadValue<float>();
        
 
        Debug.Log(boutonJeuxGauche);
        
        if (waitForOutput) {
            if (miniJeuReussi) {
                Debug.Log("Réussi!");
                waitForOutput = false;
                player.GetComponent<Mouvement>().peutBouger = true;
                ingredientCuit();
            } else {
                waitForOutput = true;
                player.GetComponent<Mouvement>().peutBouger = false;
                Debug.Log("En attente");
            }
        }
    }

    void ingredientCuit() {
        var pos = player.transform.position;
        ingredientCarry = Instantiate(ingredientOutput, new Vector3(pos.x, pos.y, pos.z), Quaternion.identity);
        ingredientCarry.SetActive(true);
        player.GetComponent<Objets>().isCarrying = true;
        player.GetComponent<Objets>().ingredient = ingredientCarry;
        player.GetComponent<Objets>().offset = offset;
        player.GetComponent<Objets>().currentParent = this.gameObject;
    }

    void check(){
        if( partie1viande == true && partie2viande == true){
            miniJeuReussi = true;
        }
    }
    
    void MiniJeux(){
        miniJeuReussi = false;
    }

    public void interactionJeuxBas(InputAction.CallbackContext context)
    {   

        if (context.performed)
        {
            partie1viande = true;
            Debug.Log("1");
        }   
        
    }

    public void interactionJeuxHaut(InputAction.CallbackContext context)
    {   
        if(partie1viande == true){
            if (context.performed)
            {
                partie2viande = true;
                Debug.Log("2");
            }
        }
    }

    public void interactionJeuxGauche(InputAction.CallbackContext context)
    {   
            
            if (context.performed)
            {
               nombreDefoisButtonGauche = nombreDefoisButtonGauche + 1f;
                
            }
        
    }
}



