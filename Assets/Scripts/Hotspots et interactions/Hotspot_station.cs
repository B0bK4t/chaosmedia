using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
public class Hotspot_station : MonoBehaviour
{
    [ShowOnly] public GameObject ingredient;
    [ShowOnly] public GameObject player;

    public string ingredientNeeded;
    public GameObject ingredientOutput;
    private GameObject ingredientCarry;
    public Vector3 offset;
    public Animator anim;

    private bool partie1viande;

    

    private float boutonJeuxGauche;

    private GameObject flecheHaut;
    private GameObject flecheBas;
    private GameObject flecheGauche;
    private GameObject flecheDroit;
    private GameObject flecheIdle;

    private bool partie2viande; 

    private bool jeuLaitue = false;
    private bool jeuViande = false;
    private bool jeuPain = false;
    private bool jeuFromage = false;
    private bool jeuTomate = false;
    private bool jeuJus = false;

    private bool partie1jus; 
    private bool partie2jus;
    private bool partie1pain; 
    private bool partie2pain; 

    private bool partie1tomate; 
    private bool partie2tomate;
    private bool partie3tomate; 
    private bool partie4tomate;

    private bool partie1fromage;

    private bool partie2fromage;
    private float boutonJeuxGaucheOui;

    private float nombreDefoisButtonGauche;

    private bool waitForOutput = false;
    public bool miniJeuReussi = true; //Résultat du mini-jeu, false par défaut mais true pour tester
    public GameObject audio;
    
    void Awake() { 
        flecheHaut = GameObject.Find("croixHaut");
        flecheBas = GameObject.Find("croixBas");
        flecheGauche = GameObject.Find("croixGauche");
        flecheDroit = GameObject.Find("croixDroit");
        flecheIdle = GameObject.Find("croixIdle");
           
        player = GameObject.Find("Dona disco");
        if (anim == GameObject.Find("Toaster").GetComponent<Animator>()) {
            anim.SetBool("cuire", true);
            anim.SetBool("griller", false);
            anim.SetBool("toaster", false);
        }
    }    

    void Start() {
        
        flecheHaut.SetActive(false);
        flecheDroit.SetActive(false);
        flecheBas.SetActive(false);
        flecheGauche.SetActive(false);
    }
    

    void OnTriggerStay(Collider other) {
        if (other.tag == "Player" && other.GetComponent<Objets>().isCarrying) {
            
            ingredient = other.GetComponent<Objets>().ingredient;
            
            if (ingredient.tag == ingredientNeeded) {
                if (other.GetComponent<Objets>().click) {
                    other.GetComponent<Objets>().isCarrying = false;
            player.GetComponent<Objets>().SendMessage("checkCarry");
                    if (anim == GameObject.Find("Toaster").GetComponent<Animator>()) {
                        anim.SetBool("cuire", false);
                        anim.SetBool("griller", true);
                        anim.SetBool("toaster", false);
                    }
                    Destroy(ingredient);
                    if (audio != null)
                    {
                        audio.SendMessage("Jouer");
                    }
                    
                    MiniJeux();
                    output();
                    if(this.gameObject.tag == "Hotspot grillepain"){
                        flecheHaut.SetActive(true);
                        flecheIdle.SetActive(false);
                        
                    }
                    else if(this.gameObject.tag == "Hotpost essaurage"){
                        flecheIdle.SetActive(false);
                        flecheGauche.SetActive(true);
                    }
                    else if(this.gameObject.tag == "HotspotPoele"){
                        flecheIdle.SetActive(false);
                        flecheBas.SetActive(true);
                    } else if(this.gameObject.tag == "Hotspot fromage"){
                        flecheIdle.SetActive(false);
                        flecheDroit.SetActive(true);
                    } 
                    else if(this.gameObject.tag == "Hotspot planche"){
                        flecheIdle.SetActive(false);
                        flecheHaut.SetActive(true);
                    }
                    else if(this.gameObject.tag == "Hotspot frigo"){
                        flecheIdle.SetActive(false);
                        flecheGauche.SetActive(true);
                    }
                }
            }
        }
    }  

    void output() {
        waitForOutput = true;
    }

    void Update() {
        check();
        
        boutonJeuxGauche = player.GetComponent<Mouvement>().playerInput.actions["interactionJeuxGauche"].ReadValue<float>();

        
 
        
        if(nombreDefoisButtonGauche == 5){
                miniJeuReussi = true;
                nombreDefoisButtonGauche = 0;
                
                    if (audio != null)
                    {
                        audio.SendMessage("Pause");
                    }
        }
        
        
        if (waitForOutput) {
            if (miniJeuReussi) {
                // Debug.Log("Réussi!");
                waitForOutput = false;
                player.GetComponent<Mouvement>().peutBouger = true;
                ingredientCuit();
                if(this.gameObject.tag == "HotspotPoele"){
                        
                        jeuViande = false;
                } else if(this.gameObject.tag == "Hotpost essaurage"){
                    flecheIdle.SetActive(true);
                    flecheGauche.SetActive(false);
                    jeuLaitue = false;
                } else if(this.gameObject.tag == "Hotspot grillepain"){
                    
                    jeuPain = false;
                 }
                 else if(this.gameObject.tag == "Hotspot fromage"){
                    jeuFromage = false;
                 }
                  else if(this.gameObject.tag == "Hotspot planche"){
                    jeuTomate = false;
                 }
                    if (audio != null)
                    {
                        audio.SendMessage("Pause");
                    }
                if (anim == GameObject.Find("Toaster").GetComponent<Animator>()) {
                    anim.SetBool("cuire", false);
                    anim.SetBool("griller", false);
                    anim.SetBool("toaster", true);
                }
            } else {
                waitForOutput = true;
                player.GetComponent<Mouvement>().peutBouger = false;
                // Debug.Log("En attente");
                
                if(this.gameObject.tag == "HotspotPoele"){
                        jeuViande = true;

                }
                else if(this.gameObject.tag == "Hotpost essaurage"){
                        jeuLaitue = true;
                }
                else if(this.gameObject.tag == "Hotspot grillepain"){
                        jeuPain = true;
                }
                else if(this.gameObject.tag == "Hotspot fromage"){
                        jeuFromage = true;
                }
                else if(this.gameObject.tag == "Hotspot planche"){
                        jeuTomate = true;
                }
                else if(this.gameObject.tag == "Hotspot frigo"){
                        jeuJus = true;
                }
            }
        }
    }

    void ingredientCuit() {
        var pos = player.transform.position;
        ingredientCarry = Instantiate(ingredientOutput, new Vector3(pos.x, pos.y, pos.z), Quaternion.identity);
        ingredientCarry.SetActive(false);
        player.GetComponent<Objets>().isCarrying = true;
        player.GetComponent<Objets>().ingredient = ingredientCarry;
        player.GetComponent<Objets>().SendMessage("checkCarry");
        player.GetComponent<Objets>().offset = offset;
        player.GetComponent<Objets>().currentParent = this.gameObject;
    }

    void check(){
        if( partie1viande == true && partie2viande == true){
            miniJeuReussi = true;
            partie1viande = false;
            partie2viande = false;
        }
        else if( partie1pain == true && partie2pain == true){
            miniJeuReussi = true;
            partie1pain = false;
            partie2pain = false;
        }
        else if( partie1fromage == true && partie2fromage == true){
            miniJeuReussi = true;
            partie1fromage = false;
            partie2fromage = false;
        }
        else if( partie1jus == true && partie2jus == true ){
            miniJeuReussi = true;
            partie1jus = false;
            partie2jus = false;
        }
        else if( partie1tomate == true && partie2tomate == true && partie3tomate == true && partie4tomate == true){
            miniJeuReussi = true;
            partie1tomate = false;
            partie2tomate = false;
            partie3tomate = false;
            partie4tomate = false;
        }
    }
    
    void MiniJeux(){
        miniJeuReussi = false;
    }

    public void interactionJeuxBas(InputAction.CallbackContext context)
    {   
        
        if(jeuViande == true) {

            if (context.performed)

            {
                partie1viande = true;
                flecheBas.SetActive(false);
                flecheHaut.SetActive(true);
            }
        } 
        else if (partie1pain == true){
            partie2pain = true;
            flecheBas.SetActive(false);
            flecheIdle.SetActive(true);
        }else if (partie1tomate == true && partie2tomate == false){
            partie2tomate = true;
            flecheBas.SetActive(false);
            flecheHaut.SetActive(true);
            
        }else if(partie3tomate == true){
            if(context.performed){
               partie4tomate = true;
               flecheBas.SetActive(false);
               flecheIdle.SetActive(true); 
            }
        }
    }

    public void interactionJeuxHaut(InputAction.CallbackContext context)
    {   
        if(partie1viande == true){
            if (context.performed)
            {   
                flecheHaut.SetActive(false);
                partie2viande = true;
                flecheIdle.SetActive(true);
                
            }
        }
        else if(jeuPain == true){
            if (context.performed)
            {   
                flecheBas.SetActive(true);
                partie1pain = true;
                flecheHaut.SetActive(false);
                
            } 
        }
        else if(jeuTomate == true && partie1tomate == false){
            if(context.performed){
               partie1tomate = true;
               flecheBas.SetActive(true);
               flecheHaut.SetActive(false);
               
            }
        }  else if(partie2tomate == true){
            if(context.performed){
               partie3tomate = true;
               flecheBas.SetActive(true);
               flecheHaut.SetActive(false); 
               
            }
        }
    }
    

    public void interactionJeuxGauche(InputAction.CallbackContext context)
    {   
            if( jeuLaitue == true){
                if (context.performed)
                {
                
                    nombreDefoisButtonGauche++;
                
                
                }
            }
            else if(partie1fromage == true){
                if (context.performed)
                {
                    partie2fromage = true;
                    flecheGauche.SetActive(false);
                    flecheIdle.SetActive(true);
                }
            }
            
            else if(jeuJus == true){
                if (context.performed)
                {
                    partie1jus = true;
                    flecheGauche.SetActive(false);
                    flecheDroit.SetActive(true);
                }
            }
            
    }

    public void interactionJeuxDroite(InputAction.CallbackContext context)
    {   
            
            if(jeuFromage == true){
                if(context.performed){

                partie1fromage = true;
                flecheDroit.SetActive(false);
                flecheGauche.SetActive(true);
                }
            }else if(partie1jus == true){
                partie2jus = true;
                flecheDroit.SetActive(false);
                flecheIdle.SetActive(true);
            }
            
            
        
    }
}


