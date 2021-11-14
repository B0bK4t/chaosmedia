using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.SceneManagement;


public class GameManager : MonoBehaviour
{
    //Scene
    public Scene scene;
    string gameScene = "scene_beta"; 
    
    //pain, viande, fromage, tomate, laitue, jus
    //ingrédients dispo beta: viande, laitue, pain, fromage => plat de viande, croque monsieur
    List<string> ingredientsChoisis = new List<string>();
    Dictionary<string, string[]> repasArray = new Dictionary<string, string[]>();
    Dictionary<string, float> timersArray = new Dictionary<string, float>();

    [Header("Ingrédients des repas")]
    [ShowOnly] public string[] burgerIngredients = new string[] {"fromage", "pain", "viande", "laitue", "tomate"};
    private float burgerTimer = 30f;

    [ShowOnly] public string[] platViandeIngredients = new string[] {"viande","laitue"};
    private float platViandeTimer = 30f;

    [ShowOnly] public string[] brochetteIngredients = new string[] {"viande", "laitue", "tomate"};
    private float brochetteTimer = 30f;

    [ShowOnly] public string[] sandwichIngredients = new string[] {"pain", "viande", "tomate", "laitue"};
    private float sandwichTimer = 30f;

    [ShowOnly] public string[] saladeIngredients = new string[] {"laitue", "tomate", "fromage"};
    private float saladeTimer = 30f;

    [ShowOnly] public string[] croqueMonsieurIngredients = new string[] {"fromage", "pain", "viande"};
    private float croqueMonsieurTimer = 30f;

    [ShowOnly] public string[] jelloIngredients = new string[] {"jus"};
    private float jelloTimer = 30f;

    //Score global
    private float scoreTotal = 0f;
    private float timerGlobal = 300f;
    private float debutDisco = 60f;
    private bool tempsGlobalEnCours = false;

    //Recette courante
    private int repasChoisi;
    private float timerRecette;
    private float recetteTimerTotal;
    private float scoreRepas;
    private bool tempsRecetteEnCours = false;
    private bool repasEstTermine = true;
    private float discoMultiplicateur = 1f;


    void Start() {
        //Scenes
        scene = SceneManager.GetActiveScene();

        if (scene.name == gameScene) {
            //Ajout repas
            repasArray.Add("burger", burgerIngredients);
            timersArray.Add("burger", burgerTimer);

            repasArray.Add("platViande", platViandeIngredients);
            timersArray.Add("platViande", platViandeTimer);

            repasArray.Add("brochette", brochetteIngredients);
            timersArray.Add("brochette", brochetteTimer);

            repasArray.Add("sandwich", sandwichIngredients);
            timersArray.Add("sandwich", sandwichTimer);

            repasArray.Add("salade", saladeIngredients);
            timersArray.Add("salade", saladeTimer);

            repasArray.Add("croqueMonsieur", croqueMonsieurIngredients);
            timersArray.Add("croqueMonsieur", croqueMonsieurTimer);

            repasArray.Add("jello", jelloIngredients);
            timersArray.Add("jello", jelloTimer);

            //Timer partie
            tempsGlobalEnCours = true;

            genererAssiette();
            choisirRepas();
        }
    }

    void choisirRepas() {
        //Choix du repas
        // repasChoisi = Random.Range(1, repasArray.Count);
        repasChoisi = 1;
        scoreRepas = timersArray.ElementAt(repasChoisi).Value;
        timerRecette = timersArray.ElementAt(repasChoisi).Value;
        recetteTimerTotal = timerRecette;
        tempsRecetteEnCours = true;
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
            string repas = repasArray.ElementAt(repasChoisi).Key;
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
                            }
                        }
                    }
            } else {
            done = "pasComplete";
            }

        if (done == "false")
            {
                Debug.Log(repas + " ne peut pas être fait"); //Changer pour output
            } else if (done == "pasComplete") {
                
                Debug.Log(repas + " n'est pas terminé, il manque:");
                foreach (var item in allNeeded)
                {
                    Debug.Log(item); //Changer pour output
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
        }
        //Timer recette
        if (tempsRecetteEnCours)
        {
            if (timerRecette> 0)
            {
                timerRecette -= Time.deltaTime;
            }
            else {
                Juger();
                timerRecette = 0;
                tempsRecetteEnCours = false;
            }
        }
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
