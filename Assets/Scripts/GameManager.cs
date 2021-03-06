using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class GameManager : MonoBehaviour
{
    //Scene
    [Header("Général")]
    public Scene scene;
    string gameScene = "scene_beta";

    public GameObject player;
    public GameObject hotspotAssiette;
    public GameObject frigo;

    [Header("Lights")]
    public GameObject premieresLumieres;
    public GameObject lumieresDisco;

    public GameObject video;
    private float videoIntroTime = 32f;
    private float videoOutroTime = 2f;

    //pain, viande, fromage, tomate, laitue, jus
    List<string> ingredientsChoisis = new List<string>();
    Dictionary<string, string[]> repasArray = new Dictionary<string, string[]>();
    Dictionary<string, float> timersArray = new Dictionary<string, float>();
    Dictionary<string, GameObject> objectsArray = new Dictionary<string, GameObject>();
    List<string> nomsRepas = new List<string>();

    //Burger, plat de viande, brochette, sandwich, salade, jello, croque-monsieur
    private string[] burgerIngredients = new string[] { "fromage", "pain", "viande", "laitue", "tomate" };
    private float burgerTimer = 45f;
    [Header("Game Objects des repas")]
    public GameObject burgerObject;

    private string[] platViandeIngredients = new string[] { "viande", "laitue" };
    private float platViandeTimer = 35f;
    public GameObject platViandeObject;

    private string[] brochetteIngredients = new string[] { "viande", "laitue", "tomate" };
    private float brochetteTimer = 45f;
    public GameObject brochetteObject;

    private string[] sandwichIngredients = new string[] { "pain", "viande", "tomate", "laitue" };
    private float sandwichTimer = 60f;
    public GameObject sandwichObject;

    private string[] saladeIngredients = new string[] { "laitue", "tomate", "fromage" };
    private float saladeTimer = 45f;
    public GameObject saladeObject;

    private string[] croqueMonsieurIngredients = new string[] { "fromage", "pain", "viande" };
    private float croqueMonsieurTimer = 45f;
    public GameObject croqueMonsieurObject;

    private string[] jelloIngredients = new string[] { "jus" };
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
    [ShowOnly] public bool canBeAdded = false;

    //Score global
    [ShowOnly] public static float scoreTotal = 0f;
    private float timerGlobal = 300f;
    private float debutDisco = 60f;
    private bool tempsGlobalEnCours = false;
    [Header("Score et timer")]
    [ShowOnly] public bool enPause = false;
    // public Text timerText;
    public TextMeshPro timerText;
    public TextMeshPro recetteTimerText;
    public Text scoreText;
    public Text repasText;
    public GameObject disco;

    public GameObject audio;
    public AudioSource voixFini;
    private bool voixAppel = false;
    public Image fillImage;

    private float timeAmt = 10;
    private float timeTest;

    private bool checkForDiscoLum = false;

    void Awake() {
        //Scenes
        scene = SceneManager.GetActiveScene();
        enPause = false;
    }

    void Start() {
        if (scene.name == gameScene) {
            checkForDiscoLum = true;
            fillImage = fillImage.GetComponent<Image>();
            
            //Ajout repas
            repasArray.Add("burger", burgerIngredients);
            timersArray.Add("burger", burgerTimer);
            objectsArray.Add("burger", burgerObject);
            nomsRepas.Add("Burger");

            repasArray.Add("platViande", platViandeIngredients);
            timersArray.Add("platViande", platViandeTimer);
            objectsArray.Add("platViande", platViandeObject);
            nomsRepas.Add("Plat de viande");

            repasArray.Add("brochette", brochetteIngredients);
            timersArray.Add("brochette", brochetteTimer);
            objectsArray.Add("brochette", brochetteObject);
            nomsRepas.Add("Brochette");

            repasArray.Add("sandwich", sandwichIngredients);
            timersArray.Add("sandwich", sandwichTimer);
            objectsArray.Add("sandwich", sandwichObject);
            nomsRepas.Add("Sandwich");

            repasArray.Add("salade", saladeIngredients);
            timersArray.Add("salade", saladeTimer);
            objectsArray.Add("salade", saladeObject);
            nomsRepas.Add("Salade");

            repasArray.Add("croqueMonsieur", croqueMonsieurIngredients);
            timersArray.Add("croqueMonsieur", croqueMonsieurTimer);
            objectsArray.Add("croqueMonsieur", croqueMonsieurObject);
            nomsRepas.Add("Croque-monsieur");

            repasArray.Add("jello", jelloIngredients);
            timersArray.Add("jello", jelloTimer);
            objectsArray.Add("jello", jelloObject);
            nomsRepas.Add("Jello");

            this.GetComponent<GameStart>().SendMessage("startGame");
            // this.GetComponent<GameStart>().SendMessage("bypass");
        } else if (scene.name == "Post_credit") {
            scoreText.text = scoreTotal.ToString();
        }
    }

    void debut() {
        scoreTotal = 0f;
        scoreText.text = scoreTotal.ToString();
        tempsGlobalEnCours = true;
        choisirRepas();
        player.GetComponent<Mouvement>().peutBouger = true;
    }

    void choisirRepas() {
        //Choix du repas
        repasChoisi = Random.Range(0, repasArray.Count);
        this.GetComponent<affichageRecettes>().SendMessage("newRecette", nomsRepas[repasChoisi]);
        frigo.GetComponent<Hotspot_station>().repas = nomsRepas[repasChoisi];
        scoreRepas = timersArray.ElementAt(repasChoisi).Value;
        timerRecette = timersArray.ElementAt(repasChoisi).Value;
        recetteTimerTotal = timerRecette;
        tempsRecetteEnCours = true;
        repasText.text = nomsRepas[repasChoisi];
        ingredientsChoisis.Clear();
    }

    void ajoutIngredient(string ingredient) {
        this.GetComponent<affichageRecettes>().SendMessage("checkIngredient", ingredient);
        this.GetComponent<affichageCloche>().SendMessage("ajouterDansCloche", ingredient);
        ingredientsChoisis.Add(ingredient);
        verifierRepas();
    }

    void enleverIngredient(string ingredient) {
        this.GetComponent<affichageRecettes>().SendMessage("removeIngredient", ingredient);
        this.GetComponent<affichageCloche>().SendMessage("enleverDansCloche", ingredient);
        ingredientsChoisis.Remove(ingredient);
        verifierRepas();
    }

    void verifierRepas()
    {
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
                    canBeAdded = false;
                    break;
                } else {
                    canBeAdded = true;
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
            // Debug.Log(repas + " ne peut pas être fait"); //Changer pour output
            repasEstTermine = false;
            canBeAdded = false;
        } else if (done == "pasComplete") {
            canBeAdded = true;
            // Debug.Log(repas + " n'est pas terminé, il manque:");
            foreach (var item in allNeeded)
            {
                // Debug.Log(item); //Changer pour output
                repasEstTermine = false;
            }
        } else if (done == "true") {
            // Debug.Log(repas + "est terminé"); //Changer pour output
            repasEstTermine = true;
            canBeAdded = false;
        }
    }

    void Juger(bool finished)
    {
        float tempsCourant = timerRecette / recetteTimerTotal;

        if (repasEstTermine || finished) {
            if (tempsCourant > 0.5) {
                tempsRecetteEnCours = false;
                scoreTotal += scoreRepas * 110 * discoMultiplicateur;
                repasEstTermine = false;
                Debug.Log(scoreTotal);
                if (scoreTotal <= 0) {
                    scoreTotal = 0;
                }
                if (audio != null)
                {
                    audio.SendMessage("Jouer");
                }
            }
            else if (tempsCourant > 0) {
                tempsRecetteEnCours = false;
                scoreTotal += scoreRepas * 50 * discoMultiplicateur;
                repasEstTermine = false;
                Debug.Log(scoreTotal);
                if (scoreTotal <= 0) {
                    scoreTotal = 0;
                }
                if (audio != null)
                {
                    audio.SendMessage("Jouer");
                }
            }
            else {
                tempsRecetteEnCours = false;
                scoreTotal -= scoreRepas * 110 * discoMultiplicateur;
                repasEstTermine = false;
                Debug.Log(scoreTotal);
                if (scoreTotal <= 0) {
                    scoreTotal = 0;
                }
            }

            player.GetComponent<Objets>().SendMessage("clearHand");
            player.GetComponent<Objets>().SendMessage("clear");
            this.GetComponent<affichageRecettes>().SendMessage("clear");
            this.GetComponent<affichageCloche>().SendMessage("clearCloche");
            hotspotAssiette.GetComponent<Hotspot_assiette>().SendMessage("clearAssiette");
            scoreText.text = scoreTotal.ToString();
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
        //Timer global
        if (tempsGlobalEnCours && !enPause) {
            if (timerGlobal <= debutDisco) {
                discoMultiplicateur = 3f;
                bouleDisco();
                if (checkForDiscoLum) {
                    switchLights();
                }
            }
            if (timerGlobal > 0)
            {
                timerGlobal -= Time.deltaTime;
            }
            else {
                timerGlobal = 0;
                tempsGlobalEnCours = false;
                Debug.Log("fin de la partie");
                postOutro();
            }
            if (timerGlobal > 0) {
                DisplayTime(timerGlobal, timerText);
            }
        }

        if (timerGlobal < 5f && voixAppel == false)
        {
            voixFini.Play(0);
            voixAppel = true;
        }

        //Timer recette
        if (tempsRecetteEnCours && !enPause)
        {
            if (timerRecette > 0)
            {
                timerRecette -= Time.deltaTime;
                if (recetteTimerText != null) {
                    DisplayTime(timerRecette, recetteTimerText);
                }
            }
            else {
                timerRecette = 0;
                tempsRecetteEnCours = false;
                Juger(true);
            }
        }
        if (timerRecette > 0) {

            fillImage.fillAmount = timerRecette / recetteTimerTotal;
        }

        if (scene.name == "Intro") {
            if (videoIntroTime > 0) {
                videoIntroTime -= Time.deltaTime;
            } else {
                debutCuisine();
            }
        }

        if (scene.name == "Outro") {
            if (videoOutroTime > 0) {
                videoOutroTime -= Time.deltaTime;
            } else {
                finJeu();
            }
        }
    }


    void DisplayTime(float timeToDisplay, TextMeshPro target)
    {
        timeToDisplay += 1;
        float minutes = Mathf.FloorToInt(timeToDisplay / 60);
        float seconds = Mathf.FloorToInt(timeToDisplay % 60);

        target.text = string.Format("{0:00}:{1:00}", minutes, seconds);
    }

    //Scene change
    public void accueilIntro()
    {
        SceneManager.LoadScene("Intro");
        // delaiIntro();
    }

    public void debutCuisine()
    {
        SceneManager.LoadScene(gameScene);
    }

    public void finJeu()
    {
        SceneManager.LoadScene("Credit");
    }

    public void endCredit(float delay) {
        Invoke("goToPostCredit", delay);
    }

    public void goToPostCredit() {
        SceneManager.LoadScene("Post_credit");
    }

    public void postOutro()
    {
        SceneManager.LoadScene("Outro");
    }

    public void retourHome(float delay)
    {
        Invoke("retourAfterInvoke", delay);   
    }

    void retourAfterInvoke() {
        SceneManager.LoadScene("Accueil");
        enPause = false;
    }

    void bouleDisco() {
        var pos = disco.transform.position;
        float height;
        height = pos.y;
        if (height > 2.5f) {
            height -= 0.01f;
            disco.transform.position = new Vector3(pos.x, height, pos.z);
        }
    }
    
    void switchLights() {
        checkForDiscoLum = false;
        lumieresDisco.SetActive(true);
        premieresLumieres.SetActive(false);
    }

}