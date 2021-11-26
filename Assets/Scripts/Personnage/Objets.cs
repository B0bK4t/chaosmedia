using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class Objets : MonoBehaviour
{
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

    void Start() {
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
