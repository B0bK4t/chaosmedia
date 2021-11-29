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

    public GameObject GameManager;
    public GameObject plate;
    [ShowOnly] public string repas;

    private float boutonJeuxGauche;

    private GameObject flecheHaut;
    private GameObject flecheBas;
    private GameObject flecheGauche;
    private GameObject flecheDroit;
    private GameObject flecheIdle;
    private GameObject cercle1;
    private GameObject cercle2;
    private GameObject cercle3;
    private GameObject cercle4;
    private GameObject cercle5;
    private GameObject cercle1Fini;
    private GameObject cercle2Fini;
    private GameObject cercle3Fini;
    private GameObject cercle4Fini;
    private GameObject cercle5Fini;

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

        cercle1 = GameObject.Find("circle01");
        cercle2 = GameObject.Find("circle02");
        cercle3 = GameObject.Find("circle03");
        cercle4 = GameObject.Find("circle04");
        cercle5 = GameObject.Find("circle05");

        cercle1Fini = GameObject.Find("circle01Fini");
        cercle2Fini = GameObject.Find("circle02Fini");
        cercle3Fini = GameObject.Find("circle03Fini");
        cercle4Fini = GameObject.Find("circle04Fini");
        cercle5Fini = GameObject.Find("circle05Fini");

        player = GameObject.Find("Dona disco");
        if (anim == GameObject.Find("Toaster").GetComponent<Animator>()) {
            anim.SetBool("cuire", true);
            anim.SetBool("griller", false);
            anim.SetBool("toaster", false);
        } else if (anim == GameObject.Find("Essoreuse_salade").GetComponent<Animator>()) {
            anim.SetBool("essore", false);
        } else if (anim == GameObject.Find("PlancheDecouper").GetComponent<Animator>()) {
            anim.SetBool("mini-jeu_couper", false);
            anim.SetBool("tranche", false);
        }
    }    

    void Start() {
        
        flecheHaut.SetActive(false);
        flecheDroit.SetActive(false);
        flecheBas.SetActive(false);
        flecheGauche.SetActive(false);


        cercle1Fini.SetActive(false);
        cercle2Fini.SetActive(false);
        cercle3Fini.SetActive(false);
        cercle4Fini.SetActive(false);
        cercle5Fini.SetActive(false);

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
                    } else if (anim == GameObject.Find("Essoreuse_salade").GetComponent<Animator>()) {
                        anim.SetBool("essore", true);
                    } else if (anim == GameObject.Find("PlancheDecouper").GetComponent<Animator>()) {
                        anim.SetBool("mini-jeu_couper", true);
                    } else if (anim == GameObject.Find("fridge").GetComponent<Animator>()) {
                        anim.SetTrigger("Play");
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
                 else if(this.gameObject.tag == "Hotspot frigo"){
                    jeuJus = false;
                    cercle1Fini.SetActive(false);
                    cercle2Fini.SetActive(false);
                    cercle3Fini.SetActive(false);
                    cercle4Fini.SetActive(false);
                    cercle5Fini.SetActive(false);
                    if (repas == "Jello") {
                        GameManager.GetComponent<GameManager>().repasEstTermine = true;
                        GameManager.GetComponent<affichageRecettes>().SendMessage("checkIngredient","jus");
                        plate.GetComponent<Hotspot_assiette>().canAdd = false;
                    }
                 }
                    if (audio != null)
                    {
                        audio.SendMessage("Pause");
                    }
                if (anim == GameObject.Find("Toaster").GetComponent<Animator>()) {
                    anim.SetBool("cuire", false);
                    anim.SetBool("griller", false);
                    anim.SetBool("toaster", true);
                } else if (anim == GameObject.Find("Essoreuse_salade").GetComponent<Animator>()) {
                    anim.SetBool("false", true);
                } else if (anim == GameObject.Find("fridge").GetComponent<Animator>()) {
                        anim.SetTrigger("Play");
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
        if( partie1viande && partie2viande){
            miniJeuReussi = true;
            partie1viande = false;
            partie2viande = false;
        }
        else if( partie1pain && partie2pain){
            miniJeuReussi = true;
            partie1pain = false;
            partie2pain = false;
        }
        else if( partie1fromage && partie2fromage){
            miniJeuReussi = true;
            partie1fromage = false;
            partie2fromage = false;
        }
        else if( partie1jus && partie2jus ){
            Invoke("Premier", 1);
            Invoke("Deuxieme", 2);
            Invoke("Troisieme", 3);
            Invoke("Qatrieme", 4);
            Invoke("Cinquieme", 5);
            
        }
        else if( partie1tomate && partie2tomate && partie3tomate && partie4tomate){
            miniJeuReussi = true;
            partie1tomate = false;
            partie2tomate = false;
            partie3tomate = false;
            partie4tomate = false;
            if (anim == GameObject.Find("PlancheDecouper").GetComponent<Animator>()) {
                anim.SetBool("tranche", true);
                anim.SetBool("mini-jeu_couper", false);
            }
        }
    }
    
    void MiniJeux(){
        miniJeuReussi = false;
    }

    void Premier(){
        cercle1Fini.SetActive(true);
    }
    void Deuxieme(){
       cercle2Fini.SetActive(true);
    }
    void Troisieme(){
       cercle3Fini.SetActive(true);
    }
    void Qatrieme(){
        cercle4Fini.SetActive(true);
    }
    void Cinquieme(){
        cercle5Fini.SetActive(true);
        miniJeuReussi = true;
        partie1jus = false;
        partie2jus = false;
    }

    public void interactionJeuxBas(InputAction.CallbackContext context)
    {   
        if(jeuViande) {
            if (context.performed)
            {
                partie1viande = true;
                flecheBas.SetActive(false);
                flecheHaut.SetActive(true);
            }
        } else if (partie1pain){
            partie2pain = true;
            flecheBas.SetActive(false);
            flecheIdle.SetActive(true);
        } else if (partie1tomate && partie2tomate == false){
            partie2tomate = true;
            flecheBas.SetActive(false);
            flecheHaut.SetActive(true);
            if (anim == GameObject.Find("PlancheDecouper").GetComponent<Animator>()) {
                    anim.SetTrigger("trancheClick");
                }
        }else if(partie3tomate){
            if(context.performed){
               partie4tomate = true;
               flecheBas.SetActive(false);
               flecheIdle.SetActive(true); 
               if (anim == GameObject.Find("PlancheDecouper").GetComponent<Animator>()) {
                    anim.SetTrigger("trancheClick");
                }
            }
        }
    }

    public void interactionJeuxHaut(InputAction.CallbackContext context)
    {   
        if(partie1viande){
            if (context.performed)
            {   
                flecheHaut.SetActive(false);
                partie2viande = true;
                flecheIdle.SetActive(true);
                
            }
        }
        else if(jeuPain){
            if (context.performed)
            {   
                flecheBas.SetActive(true);
                partie1pain = true;
                flecheHaut.SetActive(false);
                
            } 
        }
        else if(jeuTomate && partie1tomate == false){
            if(context.performed){
               partie1tomate = true;
               flecheBas.SetActive(true);
               flecheHaut.SetActive(false);
               if (anim == GameObject.Find("PlancheDecouper").GetComponent<Animator>()) {
                    anim.SetTrigger("trancheClick");
                }
            }
        }  else if(partie2tomate){
            if(context.performed){
               partie3tomate = true;
               flecheBas.SetActive(true);
               flecheHaut.SetActive(false); 
               if (anim == GameObject.Find("PlancheDecouper").GetComponent<Animator>()) {
                    anim.SetTrigger("trancheClick");
                }
            }
        }
    }  

    public void interactionJeuxGauche(InputAction.CallbackContext context)
    {   
            if( jeuLaitue){
                if (context.performed)
                {
                
                    nombreDefoisButtonGauche++;
                
                
                }
            }
            else if(partie1fromage){
                if (context.performed)
                {
                    partie2fromage = true;
                    flecheGauche.SetActive(false);
                    flecheIdle.SetActive(true);
                }
            }
            
            else if(jeuJus){
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
            
            if(jeuFromage){
                if(context.performed){

                partie1fromage = true;
                flecheDroit.SetActive(false);
                flecheGauche.SetActive(true);
                }
            }else if(partie1jus){
                partie2jus = true;
                flecheDroit.SetActive(false);
                flecheIdle.SetActive(true);
            }
            
            
        
    }
}


