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

    private bool partie1jus; 
    private bool partie2jus;
    private bool partie1pain; 
    private bool partie2pain; 

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
        // flecheGauche =  
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
                }
            }
        }
    }  

    void output() {
        waitForOutput = true;
    }

    void Update() {
        check();
        Debug.Log(partie2viande);
        boutonJeuxGauche = player.GetComponent<Mouvement>().playerInput.actions["interactionJeuxGauche"].ReadValue<float>();

        if(partie1viande == true && waitForOutput){
            flecheBas.SetActive(false);
            flecheHaut.SetActive(true);
        }
 
        
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
                    
                        flecheIdle.SetActive(true);
                        flecheBas.SetActive(false);
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
                        flecheIdle.SetActive(false);
                        flecheBas.SetActive(true);
                }
                else if(this.gameObject.tag == "Hotspot essaurage"){
                        jeuLaitue = true;
                }
                else if(this.gameObject.tag == "Hotspot grillepain"){
                        jeuPain = true;
                }
                else if(this.gameObject.tag == "Hotspot fromage"){
                        jeuFromage = true;
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
            
            }
        } 
        else if (partie1pain == true){
            partie2pain = true;
        }
    }

    public void interactionJeuxHaut(InputAction.CallbackContext context)
    {   
        if(partie1viande == true){
            if (context.performed)
            {
                partie2viande = true;
                flecheIdle.SetActive(true);
                flecheHaut.SetActive(false);
            }
        }
        else if(jeuPain == true){
            if (context.performed)
            {
                partie1pain = true;
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
            else if(jeuFromage == true){
                if(context.performed){
                partie1fromage = true;
            }
            }
            
            
            
    }

    public void interactionJeuxDroite(InputAction.CallbackContext context)
    {   
            if(partie1fromage == true){
                if (context.performed)
                {
                
                    partie2fromage = true;
            
                }
            }
            
            
            
        
    }
}


