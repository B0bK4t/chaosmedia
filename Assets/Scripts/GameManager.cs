using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class GameManager : MonoBehaviour
{
    //Scene
    [Header("Général")]
    public Scene scene;
    string gameScene = "scene_beta"; 

    public GameObject player;
    public GameObject hotspotAssiette;
    
    //pain, viande, fromage, tomate, laitue, jus
    //ingrédients dispo beta: viande, laitue, pain, fromage => plat de viande, croque monsieur
    List<string> ingredientsChoisis = new List<string>();
    Dictionary<string, string[]> repasArray = new Dictionary<string, string[]>();
    Dictionary<string, float> timersArray = new Dictionary<string, float>();
    Dictionary<string, GameObject> objectsArray = new Dictionary<string, GameObject>();

    
    private string[] burgerIngredients = new string[] {"fromage", "pain", "viande", "laitue", "tomate"};
    private float burgerTimer = 30f;
    [Header("Game Objects des repas")]
    public GameObject burgerObject;

    private string[] platViandeIngredients = new string[] {"viande","laitue"};
    private float platViandeTimer = 30f;
    public GameObject platViandeObject;

    private string[] brochetteIngredients = new string[] {"viande", "laitue", "tomate"};
    private float brochetteTimer = 30f;
    public GameObject brochetteObject;

    private string[] sandwichIngredients = new string[] {"pain", "viande", "tomate", "laitue"};
    private float sandwichTimer = 30f;
    public GameObject sandwichObject;

    private string[] saladeIngredients = new string[] {"laitue", "tomate", "fromage"};
    private float saladeTimer = 30f;
    public GameObject saladeObject;

    private string[] croqueMonsieurIngredients = new string[] {"fromage", "pain", "viande"};
    private float croqueMonsieurTimer = 30f;
    public GameObject croqueMonsieurObject;

    private string[] jelloIngredients = new string[] {"jus"};
    private float jelloTimer = 30f;
    public GameObject jelloObject;

    //Recette courante
    [Header("Utilitaires pour les autres scripts")]
    [ShowOnly] public GameObject objectRepasChoisi;
    private int repasChoisi;
    private float timerRecette;
    private float recetteTimerTotal;
    private float scoreRepas;
    private bool tempsRecetteEnCours = false;
    [ShowOnly] public bool repasEstTermine = false;
    [ShowOnly] public string repas;
    private float discoMultiplicateur = 1f;

    //Score global
    private float scoreTotal = 0f;
    private float timerGlobal = 300f;
    private float debutDisco = 60f;
    private bool tempsGlobalEnCours = false;
    [Header("Score et timer")]
    public Text timerText;

    void Start() {
        //Scenes
        scene = SceneManager.GetActiveScene();

        if (scene.name == gameScene) {
            //Ajout repas
            repasArray.Add("burger", burgerIngredients);
            timersArray.Add("burger", burgerTimer);
            objectsArray.Add("burger", burgerObject);

            repasArray.Add("platViande", platViandeIngredients);
            timersArray.Add("platViande", platViandeTimer);
            objectsArray.Add("platViande", platViandeObject);

            repasArray.Add("brochette", brochetteIngredients);
            timersArray.Add("brochette", brochetteTimer);
            objectsArray.Add("brochette", brochetteObject);

            repasArray.Add("sandwich", sandwichIngredients);
            timersArray.Add("sandwich", sandwichTimer);
            objectsArray.Add("sandwich", sandwichObject);

            repasArray.Add("salade", saladeIngredients);
            timersArray.Add("salade", saladeTimer);
            objectsArray.Add("salade", saladeObject);

            repasArray.Add("croqueMonsieur", croqueMonsieurIngredients);
            timersArray.Add("croqueMonsieur", croqueMonsieurTimer);
            objectsArray.Add("croqueMonsieur", croqueMonsieurObject);

            repasArray.Add("jello", jelloIngredients);
            timersArray.Add("jello", jelloTimer);
            objectsArray.Add("jello", jelloObject);

            //Timer partie
            tempsGlobalEnCours = true;

            genererAssiette();
            choisirRepas();
        }
    }

    void choisirRepas() {
        //Choix du repas
        // repasChoisi = Random.Range(1, repasArray.Count);
        randomBeta();
        scoreRepas = timersArray.ElementAt(repasChoisi).Value;
        timerRecette = timersArray.ElementAt(repasChoisi).Value;
        recetteTimerTotal = timerRecette;
        tempsRecetteEnCours = true;
        Debug.Log(repasArray.ElementAt(repasChoisi).Key);
        ingredientsChoisis.Clear();
    }

    void randomBeta() {
        var nb = Random.Range(1, 3);
        if (nb == 1)
        {
            repasChoisi = 1;
        } else if (nb == 2) 
        {
            repasChoisi = 5;
        }
    }

    void genererAssiette() {
        int type = Random.Range(1, 6);
        if (type == 5) {
            // Debug.Log("vinyle");
        } else {
            // Debug.Log("regulière");
        }
    }

    void ajoutIngredient(string ingredient) {
        ingredientsChoisis.Add(ingredient);
        verifierRepas();
    }

    void enleverIngredient() {
        ingredientsChoisis.RemoveAt(ingredientsChoisis.Count - 1);
        verifierRepas();
    }

    void verifierRepas()
    {
      
    //    for (int i = 0; i < repasArray.Count; i++)
    //    {
            repas = repasArray.ElementAt(repasChoisi).Key;
            string[] ingredientsNeeded = repasArray.ElementAt(repasChoisi).Value;
            List<string> allNeeded = new List<string>();
            string done = "false";

            foreach (var ingredient in ingredientsNeeded)
            {
                allNeeded.Add(ingredient);
            }   
            
            if (ingredientsChoisis.Count() > 0) {
                foreach (var ingredient in ingredientsChoisis)
                    {
                    if (!ingredientsNeeded.Contains(ingredient)) {
                            done = "false";
                            break;
                        } else {
                            done = "pasComplete";
                            allNeeded.Remove(ingredient);
                            if (allNeeded.Count == 0) {
                                done = "true";
                                objectRepasChoisi = objectsArray.ElementAt(repasChoisi).Value;
                            }
                        }
                    }
            } else {
            done = "pasComplete";
            }

        if (done == "false")
            {
                Debug.Log(repas + " ne peut pas être fait"); //Changer pour output
                repasEstTermine = false;
            } else if (done == "pasComplete") {
                
                Debug.Log(repas + " n'est pas terminé, il manque:");
                foreach (var item in allNeeded)
                {
                    Debug.Log(item); //Changer pour output
                    repasEstTermine = false;
                }
            } else if (done == "true") {
                Debug.Log(repas + "est terminé"); //Changer pour output
                repasEstTermine = true;
            }
        // }

    }

    void Juger() {
        float tempsCourant = timerRecette/recetteTimerTotal;

        if (repasEstTermine) {
            if (tempsCourant > 0.5) {
                tempsRecetteEnCours = false;
                scoreTotal += scoreRepas*110*discoMultiplicateur;
                repasEstTermine = false;
                Debug.Log(scoreTotal);
            } 
            else if (tempsCourant > 0) {
                tempsRecetteEnCours = false;
                scoreTotal += scoreRepas*50*discoMultiplicateur;
                repasEstTermine = false;
                Debug.Log(scoreTotal);
            } 
            else {
                tempsRecetteEnCours = false;
                scoreTotal -= scoreRepas*110*discoMultiplicateur;
                repasEstTermine = false;
                Debug.Log(scoreTotal);
            }

            player.GetComponent<Objets>().SendMessage("clearHand");
            hotspotAssiette.GetComponent<Hotspot_assiette>().SendMessage("clearAssiette");
            prochainRepas();
        }

    }

    void prochainRepas() {
        if (tempsGlobalEnCours) {
            choisirRepas();
        }
    }

    void Update()
    {
        // genererAssiette();

        //Timer global
        if (tempsGlobalEnCours) {
            if (timerGlobal <= debutDisco) {
                discoMultiplicateur = 3f;
            }
            if (timerGlobal> 0)
            {
                timerGlobal-= Time.deltaTime;
            }
            else {
                timerGlobal = 0;
                tempsGlobalEnCours = false;
                Debug.Log("fin de la partie");
            }

            if (timerGlobal > 0) {
                DisplayTime(timerGlobal);
            }
        }

        //Timer recette
        if (tempsRecetteEnCours)
        {
            if (timerRecette> 0)
            {
                timerRecette -= Time.deltaTime;
            }
            else {
                timerRecette = 0;
                tempsRecetteEnCours = false;
                Juger();
            }
        }
    }

    
    void DisplayTime(float timeToDisplay)
    {
        timeToDisplay += 1;
        float minutes = Mathf.FloorToInt(timeToDisplay / 60);
        float seconds = Mathf.FloorToInt(timeToDisplay % 60);

        timerText.text = string.Format("{0:00}:{1:00}", minutes, seconds);
    }

    //Scene change
    public void accueilInscription()
    {
        SceneManager.LoadScene("Inscription");
    }

    public void debutCuisine()
    {
        SceneManager.LoadScene(gameScene);
    }

}
