using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Objets : MonoBehaviour
{
    //Scene
    [Header("Général")]
    public Scene scene;
    string gameScene = "scene_beta"; 

    [ShowOnly] public bool isCarrying = false;
    [ShowOnly] public GameObject ingredient;
    [ShowOnly] public GameObject currentParent;

    public GameObject main;
    public Vector3 offset;

    public bool click = false;
    public string repas;

    [Header("Canvas")]
    public RawImage viandeCrue;
    public RawImage viandeCuite;
    public RawImage laitue;
    public RawImage laitueEssoree;
    public RawImage painCru;
    public RawImage painCuit;
    public RawImage tomate;
    public RawImage trancheTomate;
    public RawImage jus;
    public RawImage trancheFromage;
    public RawImage burger;
    public RawImage platDeViande;
    public RawImage brochette;
    public RawImage sandwich;
    public RawImage salade;
    public RawImage croqueMonsieur;
    public RawImage jello;
    private List<RawImage> canvases = new List<RawImage>();

    void Awake() {
        scene = SceneManager.GetActiveScene();
    }

    void Start() {
         if (scene.name == gameScene) {
            canvases.Add(viandeCrue);
            canvases.Add(viandeCuite);
            canvases.Add(laitue);
            canvases.Add(laitueEssoree);
            canvases.Add(painCru);
            canvases.Add(painCuit);
            canvases.Add(tomate);
            canvases.Add(trancheTomate);
            canvases.Add(jus);
            canvases.Add(trancheFromage);
            canvases.Add(burger);
            canvases.Add(platDeViande);
            canvases.Add(brochette);
            canvases.Add(sandwich);
            canvases.Add(salade);
            canvases.Add(croqueMonsieur);
            canvases.Add(jello);
            clear();
         }
    }

    void Update() {
        if (isCarrying) {
            ingredient.transform.position = main.transform.position + offset;
        }
    }

    public void clearHand() {
        Destroy(ingredient);
        isCarrying = false;
    }

    public void checkCarry() {
        clear();
        switch (ingredient.tag)
        {
            case "viandeCrue":
            viandeCrue.enabled = true;
            break;
            case "viande":
            viandeCuite.enabled = true;
            break;
            case "pain":
            painCuit.enabled = true;
            break;
            case "painCru":
            painCru.enabled = true;
            break;
            case "fromage":
            trancheFromage.enabled = true;
            break;
            case "tomate":
            trancheTomate.enabled = true;
            break;
            case "tomateCrue":
            tomate.enabled = true;
            break;
            case "laitueCrue":
            laitue.enabled = true;
            break;
            case "laitue":
            laitueEssoree.enabled = true;
            break;
            case "jus":
            jello.enabled = true;
            break;
            case "jusCru":
            jus.enabled = true;
            break;
            case "platViande":
            platDeViande.enabled = true;
            break;
            case "burger":
            burger.enabled = true;
            break;
            case "brochette":
            brochette.enabled = true;
            break;
            case "sandwich":
            sandwich.enabled = true;
            break;
            case "salade":
            salade.enabled = true;
            break;
            case "croqueMonsieur":
            croqueMonsieur.enabled = true;
            break;
            case "jello":
            jello.enabled = true;
            break;
            default:
            break;
        }
    }

    public void clear() {
        foreach (var c in canvases)
        {
            if (c != null) {
            c.enabled = false;
        }}
    }

}
