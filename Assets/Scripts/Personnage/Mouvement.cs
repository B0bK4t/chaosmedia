using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class Mouvement : MonoBehaviour
{

    //Scene
    [Header("Général")]
    public Scene scene;
    string gameScene = "scene_beta"; 
    
    public GameManager GameManager;
    public GameObject plate;
    [ShowOnly] public bool estDansZoneAssiette = false;
    [ShowOnly] public string plateCommand = "";
    private CharacterController controller;
    public PlayerInput playerInput;
    private Vector3 playerVelocity;
    private bool groundedPlayer;
    private float playerSpeed = 3f;
    [ShowOnly] public bool peutBouger = false;

    private bool peutCommencer = true;
    
    private float gravityValue = -9.81f;
    private float controllerHeight = 0f;
    private float controllerCenter = 0.66f;

    public Vector2 input;

    public Vector3 move;

    [ShowOnly] public bool click;

    [ShowOnly] public Rigidbody rb_perso;

    Vector2 currentMovement;
    bool movementPressed;
    
    [Header("Animations")]
    // public Animator animPorte;
    private Animator animatorPerso;

    [ShowOnly] public bool canClick = true;
    
    //Limites de jeu
    private float limiteXPos = 5.8f;
    private float limiteXNeg = -9f;
    private float limiteZPos = 4.8f;
    private float limiteZNeg = -4.8f;

    public GameObject recettesMenuCanvas;
    public GameObject canvasMenuCommandes;
    public GameObject audio;

    void Start()
    {
        scene = SceneManager.GetActiveScene();
        playerInput = GetComponent<PlayerInput>();
        controller = gameObject.AddComponent<CharacterController>();
        rb_perso = GetComponent<Rigidbody>();
        animatorPerso = GetComponent<Animator>();
        controller.height = controllerHeight;
        controller.center = new Vector3(0, controllerCenter, 0);
    }

    void FixedUpdate()
    {
          if (scene.name == gameScene) {
            groundedPlayer = controller.isGrounded;
            if (groundedPlayer && playerVelocity.y < 0)
            {
                playerVelocity.y = 0f;
            }
            
            input = playerInput.actions["Move"].ReadValue<Vector2>();
            move = new Vector3(input.x, 0, input.y);

           if( peutBouger){
            controller.Move(move * Time.deltaTime * playerSpeed);
            rb_perso.freezeRotation = true;
            } 
            if (move != Vector3.zero)
            {
                gameObject.transform.forward = move;
            }

            playerVelocity.y += gravityValue * Time.deltaTime;
            controller.Move(playerVelocity * Time.deltaTime);

            // Calculer limites de jeu
            if (controller.transform.position.x >= limiteXPos) {
                controller.transform.position = new Vector3(limiteXPos, controller.transform.position.y, controller.transform.position.z);
            } 
            else if (controller.transform.position.x <= limiteXNeg) {
                controller.transform.position = new Vector3(limiteXNeg, controller.transform.position.y, controller.transform.position.z);
            }
        
            if (controller.transform.position.z >= limiteZPos) {
                controller.transform.position = new Vector3(controller.transform.position.x, controller.transform.position.y, limiteZPos);
            } 
            else if (controller.transform.position.z <= limiteZNeg) {
                controller.transform.position = new Vector3(controller.transform.position.x, controller.transform.position.y, limiteZNeg);
            }

            if (input.x != 0 || input.y != 0) {
                animatorPerso.SetBool("marcher", true);
                if (audio != null)
                {
                    audio.SendMessage("Jouer");
                }
            } else {
                animatorPerso.SetBool("marcher", false);
                if (audio != null)
                {
                    audio.SendMessage("Pause");
                }
            }
          }
    }

    public void Ouvrir(InputAction.CallbackContext context)
    {  
        click = context.performed;
        if (scene.name == gameScene) {
            this.GetComponent<Objets>().click = click;
        }

        if (context.performed) {
            if (estDansZoneAssiette){
                if (plateCommand == "add") {
                    plate.GetComponent<Hotspot_assiette>().SendMessage("ajouterDansAssiette");
                } else if (plateCommand == "remove") {
                    plate.GetComponent<Hotspot_assiette>().SendMessage("enleverIngredient");
                }
            }
            if (scene.name == "Accueil" && peutCommencer) {
                GameManager.SendMessage("accueilIntro");
            }
            else if (scene.name == "Post_credit") {
                GameManager.SendMessage("retourHome", 2f);
            }
        } else if (scene.name == gameScene) {
            this.GetComponent<Objets>().click = false;
        }
    }

    public void menuInput(InputAction.CallbackContext context)
    {  
        if (scene.name == gameScene && context.performed) {
           if (canvasMenuCommandes.activeSelf) {
               canvasMenuCommandes.SetActive(false);
               GameManager.GetComponent<GameManager>().enPause = false;
               peutBouger = true;
           } else {
               canvasMenuCommandes.SetActive(true);
               GameManager.GetComponent<GameManager>().enPause = true;
               peutBouger = false;
           }
        } else if (scene.name == "Accueil" && context.performed) {
           if (canvasMenuCommandes.activeSelf) {
               canvasMenuCommandes.SetActive(false);
               peutCommencer = true;
           } else {
               canvasMenuCommandes.SetActive(true);
               peutCommencer = false;
           }
        }
    }

    public void boutonB(InputAction.CallbackContext context)
    {  
        if (context.performed) {
            if (scene.name == gameScene) {
               if (recettesMenuCanvas.activeSelf) {
                   recettesMenuCanvas.SetActive(false);
                   GameManager.GetComponent<GameManager>().enPause = false;
                   peutBouger = true;
               } else {
                   recettesMenuCanvas.SetActive(true);     
                   GameManager.GetComponent<GameManager>().enPause = true;  
                   peutBouger = false;   
               }
            }
            
            else if (scene.name == "Intro") {
                GameManager.GetComponent<GameManager>().SendMessage("debutCuisine");
            }
            
            else if (scene.name == "Credit") {
                GameManager.GetComponent<GameManager>().SendMessage("endCredit", 0.5f);
            }
        }
    }

    public void boutonHome(InputAction.CallbackContext context) {
        if (scene.name == gameScene && context.performed && GameManager.GetComponent<GameManager>().enPause) {
            GameManager.GetComponent<GameManager>().SendMessage("retourHome", 0.01f);
        }
    }
}
