using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class affichageCloche : MonoBehaviour
{
    [Header("Ingrédients")]
    public RawImage fromage;
    public RawImage pain;
    public RawImage painCru;
    public RawImage viande;
    public RawImage viandeCrue;
    public RawImage laitue;
    public RawImage laitueCrue;
    public RawImage jus;
    public RawImage tomate;
    public RawImage tomateCrue;

    private float startPosX = -55;
    private float currentPosX;
    private float newPosX;
    private List<RawImage> all = new List<RawImage>();
    private float multiplicateur = 40;
    private float posY = -35;

    [Header("Clonage")]
    public GameObject parent;
    private RawImage clone;
    private RawImage current;

    void Start() {    
        all.Add(fromage);
        all.Add(pain);
        all.Add(painCru);
        all.Add(viande);
        all.Add(viandeCrue);
        all.Add(laitue);
        all.Add(laitueCrue);
        all.Add(jus);
        all.Add(tomate);
        all.Add(tomateCrue);
        
        clearCloche();
    }

    void Update() {
        currentPosX = this.GetComponent<GameManager>().hotspotAssiette.GetComponent<Hotspot_assiette>().nbIngredients;
    }

    public void ajouterDansCloche(string name) {
        newPosX = startPosX + currentPosX*multiplicateur;
        var i = name;
        switch (i)
        {
            case "pain":
                pain.enabled = true;
                current = pain;
            break;
            case "viande":
                viande.enabled = true;
                current = viande;
            break;
            case "fromage":
                fromage.enabled = true;
                current = fromage;
            break;
            case "tomate":
                tomate.enabled = true;
                current = tomate;
            break;
            case "laitue":
                laitue.enabled = true;
                current = laitue;
            break;
            case "jusCru":
                jus.enabled = true;
                current = jus;
            break;
            case "viandeCrue":
                viandeCrue.enabled = true;
                current = viandeCrue;
            break;
            case "laitueCrue":
                laitueCrue.enabled = true;
                current = laitueCrue;
            break;
            case "painCru":
                painCru.enabled = true;
                current = painCru;
            break;
            default:
            break;
        }

        Debug.Log(new Vector3(newPosX, posY, 0));
        // clone = Instantiate(current, new Vector3(0,0, 0), Quaternion.identity, parent.transform);
        // clone.RectTransform.localPosition = new Vector3(newPosX, posY, 0);
    }

    public void enleverDansCloche(string name) {
        var i = name;
        switch (i)
        {
            case "pain":
                pain.enabled = false;
            break;
            case "viande":
                viande.enabled = false;
            break;
            case "fromage":
                fromage.enabled = false;
            break;
            case "tomate":
                tomate.enabled = false;
            break;
            case "laitue":
                laitue.enabled = false;
            break;
            case "jusCru":
                jus.enabled = false;
            break;
            case "viandeCrue":
                viandeCrue.enabled = false;
            break;
            case "laitueCrue":
                laitueCrue.enabled = false;
            break;
            case "painCru":
                painCru.enabled = false;
            break;
            default:
            break;
        }
    }

    public void clearCloche() {
      foreach (var a in all)
      {
          if (a != null) {
              a.enabled = false;
          }
      }
    }
}
